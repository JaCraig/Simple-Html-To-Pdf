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
        /// <summary>
        /// Initializes a new instance of the <see cref="BindingWrapper"/> class.
        /// </summary>
        public BindingWrapper()
        {
            IsLoaded = false;
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        /// <summary>
        /// Finalizes an instance of the <see cref="BindingWrapper"/> class.
        /// </summary>
        ~BindingWrapper()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        /// <summary>
        /// Gets a value indicating whether this instance is loaded.
        /// </summary>
        /// <value><c>true</c> if this instance is loaded; otherwise, <c>false</c>.</value>
        public bool IsLoaded { get; private set; }

        //used to maintain a reference to delegates to prevent them being garbage collected...
        /// <summary>
        /// The delegates
        /// </summary>
        private readonly List<object> delegates = new List<object>();

        /// <summary>
        /// The disposed value
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// The module
        /// </summary>
        private IWkHtmlModule module;

        /// <summary>
        /// Adds the object.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <param name="objectSettings">The object settings.</param>
        /// <param name="data">The data.</param>
        public void AddObject(IntPtr converter, IntPtr objectSettings, byte[] data)
        {
            module.wkhtmltopdf_add_object(converter, objectSettings, data);
        }

        /// <summary>
        /// Adds the object.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <param name="objectSettings">The object settings.</param>
        /// <param name="data">The data.</param>
        public void AddObject(IntPtr converter, IntPtr objectSettings, string data)
        {
            module.wkhtmltopdf_add_object(converter, objectSettings, data);
        }

        /// <summary>
        /// Creates the converter.
        /// </summary>
        /// <param name="globalSettings">The global settings.</param>
        /// <returns></returns>
        public IntPtr CreateConverter(IntPtr globalSettings)
        {
            return module.wkhtmltopdf_create_converter(globalSettings);
        }

        /// <summary>
        /// Creates the global settings.
        /// </summary>
        /// <returns></returns>
        public IntPtr CreateGlobalSettings()
        {
            return module.wkhtmltopdf_create_global_settings();
        }

        /// <summary>
        /// Creates the object settings.
        /// </summary>
        /// <returns></returns>
        public IntPtr CreateObjectSettings()
        {
            return module.wkhtmltopdf_create_object_settings();
        }

        /// <summary>
        /// Destroys the converter.
        /// </summary>
        /// <param name="converter">The converter.</param>
        public void DestroyConverter(IntPtr converter)
        {
            module.wkhtmltopdf_destroy_converter(converter);
        }

        /// <summary>
        /// Destroys the global setting.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void DestroyGlobalSetting(IntPtr settings)
        {
            module.wkhtmltopdf_destroy_global_settings(settings);
        }

        /// <summary>
        /// Destroys the object setting.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void DestroyObjectSetting(IntPtr settings)
        {
            module.wkhtmltopdf_destroy_object_settings(settings);
        }

        // This code added to correctly implement the disposable pattern.
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting
        /// unmanaged resources.
        /// </summary>
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Does the conversion.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <returns></returns>
        public bool DoConversion(IntPtr converter)
        {
            return module.wkhtmltopdf_convert(converter);
        }

        /// <summary>
        /// Extendeds the qt.
        /// </summary>
        /// <returns></returns>
        public bool ExtendedQt()
        {
            return module.wkhtmltopdf_extended_qt() == 1;
        }

        /// <summary>
        /// Gets the conversion result.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <returns></returns>
        public byte[] GetConversionResult(IntPtr converter)
        {
            int length = module.wkhtmltopdf_get_output(converter, out IntPtr resultPointer);
            var result = new byte[length];
            Marshal.Copy(resultPointer, result, 0, length);

            return result;
        }

        /// <summary>
        /// Gets the current phase.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <returns></returns>
        public int GetCurrentPhase(IntPtr converter)
        {
            return module.wkhtmltopdf_current_phase(converter);
        }

        /// <summary>
        /// Gets the global setting.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public string GetGlobalSetting(IntPtr settings, string name)
        {
            //default const char * size is 2048 bytes
            byte[] buffer = new byte[2048];

            module.wkhtmltopdf_get_global_setting(settings, name, buffer);

            return GetString(buffer);
        }

        /// <summary>
        /// Gets the library version.
        /// </summary>
        /// <returns></returns>
        public string GetLibraryVersion()
        {
            return Marshal.PtrToStringAnsi(module.wkhtmltopdf_version());
        }

        /// <summary>
        /// Gets the object setting.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public string GetObjectSetting(IntPtr settings, string name)
        {
            //default const char * size is 2048 bytes
            byte[] buffer = new byte[2048];

            module.wkhtmltopdf_get_object_setting(settings, name, buffer);

            return GetString(buffer);
        }

        /// <summary>
        /// Gets the phase count.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <returns></returns>
        public int GetPhaseCount(IntPtr converter)
        {
            return module.wkhtmltopdf_phase_count(converter);
        }

        /// <summary>
        /// Gets the phase description.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <param name="phase">The phase.</param>
        /// <returns></returns>
        public string GetPhaseDescription(IntPtr converter, int phase)
        {
            return Marshal.PtrToStringAnsi(module.wkhtmltopdf_phase_description(converter, phase));
        }

        /// <summary>
        /// Gets the progress string.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <returns></returns>
        public string GetProgressString(IntPtr converter)
        {
            return Marshal.PtrToStringAnsi(module.wkhtmltopdf_progress_string(converter));
        }

        /// <summary>
        /// Loads this instance.
        /// </summary>
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

        /// <summary>
        /// Sets the error callback.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <param name="callback">The callback.</param>
        /// <returns></returns>
        public int SetErrorCallback(IntPtr converter, StringCallback callback)
        {
            delegates.Add(callback);

            return module.wkhtmltopdf_set_error_callback(converter, callback);
        }

        /// <summary>
        /// Sets the finished callback.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <param name="callback">The callback.</param>
        /// <returns></returns>
        public int SetFinishedCallback(IntPtr converter, IntCallback callback)
        {
            delegates.Add(callback);

            return module.wkhtmltopdf_set_finished_callback(converter, callback);
        }

        /// <summary>
        /// Sets the global setting.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int SetGlobalSetting(IntPtr settings, string name, string value)
        {
            return module.wkhtmltopdf_set_global_setting(settings, name, value);
        }

        /// <summary>
        /// Sets the object setting.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int SetObjectSetting(IntPtr settings, string name, string value)
        {
            return module.wkhtmltopdf_set_object_setting(settings, name, value);
        }

        /// <summary>
        /// Sets the phase changed callback.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <param name="callback">The callback.</param>
        /// <returns></returns>
        public int SetPhaseChangedCallback(IntPtr converter, VoidCallback callback)
        {
            delegates.Add(callback);

            return module.wkhtmltopdf_set_phase_changed_callback(converter, callback);
        }

        /// <summary>
        /// Sets the progress changed callback.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <param name="callback">The callback.</param>
        /// <returns></returns>
        public int SetProgressChangedCallback(IntPtr converter, VoidCallback callback)
        {
            delegates.Add(callback);

            return module.wkhtmltopdf_set_progress_changed_callback(converter, callback);
        }

        /// <summary>
        /// Sets the warning callback.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <param name="callback">The callback.</param>
        /// <returns></returns>
        public int SetWarningCallback(IntPtr converter, StringCallback callback)
        {
            delegates.Add(callback);

            return module.wkhtmltopdf_set_warning_callback(converter, callback);
        }

        // To detect redundant calls

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        /// <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release
        /// only unmanaged resources.
        /// </param>
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

        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <returns></returns>
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