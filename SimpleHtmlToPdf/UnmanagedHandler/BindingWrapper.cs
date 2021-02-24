using SimpleHtmlToPdf.UnmanagedHandler.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SimpleHtmlToPdf.UnmanagedHandler
{
    /// <summary>
    /// Binding wrapper
    /// </summary>
    /// <seealso cref="System.IDisposable"/>
    public class BindingWrapper : IDisposable
    {
        public BindingWrapper()
        {
            IsLoaded = false;
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~BindingWrapper()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        public bool IsLoaded { get; private set; }

        //used to maintain a reference to delegates to prevent them being garbage collected...
        private readonly List<object> delegates = new List<object>();

        private bool disposedValue = false;
        private IWkHtmlModule module;

        public void AddObject(IntPtr converter, IntPtr objectSettings, byte[] data)
        {
            module.wkhtmltopdf_add_object(converter, objectSettings, data);
        }

        public void AddObject(IntPtr converter, IntPtr objectSettings, string data)
        {
            module.wkhtmltopdf_add_object(converter, objectSettings, data);
        }

        public IntPtr CreateConverter(IntPtr globalSettings)
        {
            return module.wkhtmltopdf_create_converter(globalSettings);
        }

        public IntPtr CreateGlobalSettings()
        {
            return module.wkhtmltopdf_create_global_settings();
        }

        public IntPtr CreateObjectSettings()
        {
            return module.wkhtmltopdf_create_object_settings();
        }

        public void DestroyConverter(IntPtr converter)
        {
            module.wkhtmltopdf_destroy_converter(converter);
        }

        public void DestroyGlobalSetting(IntPtr settings)
        {
            module.wkhtmltopdf_destroy_global_settings(settings);
        }

        public void DestroyObjectSetting(IntPtr settings)
        {
            module.wkhtmltopdf_destroy_object_settings(settings);
        }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }

        public bool DoConversion(IntPtr converter)
        {
            return module.wkhtmltopdf_convert(converter);
        }

        public bool ExtendedQt()
        {
            return module.wkhtmltopdf_extended_qt() == 1;
        }

        public byte[] GetConversionResult(IntPtr converter)
        {
            int length = module.wkhtmltopdf_get_output(converter, out IntPtr resultPointer);
            var result = new byte[length];
            Marshal.Copy(resultPointer, result, 0, length);

            return result;
        }

        public int GetCurrentPhase(IntPtr converter)
        {
            return module.wkhtmltopdf_current_phase(converter);
        }

        public string GetGlobalSetting(IntPtr settings, string name)
        {
            //default const char * size is 2048 bytes
            byte[] buffer = new byte[2048];

            module.wkhtmltopdf_get_global_setting(settings, name, buffer);

            return GetString(buffer);
        }

        public string GetLibraryVersion()
        {
            return Marshal.PtrToStringAnsi(module.wkhtmltopdf_version());
        }

        public string GetObjectSetting(IntPtr settings, string name)
        {
            //default const char * size is 2048 bytes
            byte[] buffer = new byte[2048];

            module.wkhtmltopdf_get_object_setting(settings, name, buffer);

            return GetString(buffer);
        }

        public int GetPhaseCount(IntPtr converter)
        {
            return module.wkhtmltopdf_phase_count(converter);
        }

        public string GetPhaseDescription(IntPtr converter, int phase)
        {
            return Marshal.PtrToStringAnsi(module.wkhtmltopdf_phase_description(converter, phase));
        }

        public string GetProgressString(IntPtr converter)
        {
            return Marshal.PtrToStringAnsi(module.wkhtmltopdf_progress_string(converter));
        }

        public void Load()
        {
            if (IsLoaded)
            {
                return;
            }

            module = new WkHtmlModule();

            if (module.wkhtmltopdf_init(0) == 1)
            {
                IsLoaded = true;
            }
        }

        public int SetErrorCallback(IntPtr converter, StringCallback callback)
        {
            delegates.Add(callback);

            return module.wkhtmltopdf_set_error_callback(converter, callback);
        }

        public int SetFinishedCallback(IntPtr converter, IntCallback callback)
        {
            delegates.Add(callback);

            return module.wkhtmltopdf_set_finished_callback(converter, callback);
        }

        public int SetGlobalSetting(IntPtr settings, string name, string value)
        {
            return module.wkhtmltopdf_set_global_setting(settings, name, value);
        }

        public int SetObjectSetting(IntPtr settings, string name, string value)
        {
            return module.wkhtmltopdf_set_object_setting(settings, name, value);
        }

        public int SetPhaseChangedCallback(IntPtr converter, VoidCallback callback)
        {
            delegates.Add(callback);

            return module.wkhtmltopdf_set_phase_changed_callback(converter, callback);
        }

        public int SetProgressChangedCallback(IntPtr converter, VoidCallback callback)
        {
            delegates.Add(callback);

            return module.wkhtmltopdf_set_progress_changed_callback(converter, callback);
        }

        public int SetWarningCallback(IntPtr converter, StringCallback callback)
        {
            delegates.Add(callback);

            return module.wkhtmltopdf_set_warning_callback(converter, callback);
        }

        // To detect redundant calls

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                //free unmanaged resources (unmanaged objects) and override a finalizer below.
                module?.wkhtmltopdf_deinit();
                module = null;
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        private string GetString(byte[] buffer)
        {
            int walk = 0;

            while (walk < buffer.Length && buffer[walk] != 0)
            {
                walk++;
            }

            return Encoding.UTF8.GetString(buffer, 0, walk);
        }
    }
}