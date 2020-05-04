using SimpleHtmlToPdf.UnmanagedHandler.Interfaces;
using System;
using System.Runtime.InteropServices;

namespace SimpleHtmlToPdf.UnmanagedHandler
{
    public class WkHtmlModule : IWkHtmlModule
    {
        public void wkhtmltopdf_add_object(IntPtr converter,
            IntPtr objectSettings,
            byte[] data) => WkHtmlBindings.wkhtmltopdf_add_object(converter, objectSettings, data);

        public void wkhtmltopdf_add_object(IntPtr converter,
            IntPtr objectSettings,
            [MarshalAs((short)CustomUnmanagedType.LPUTF8Str)] string data) => WkHtmlBindings.wkhtmltopdf_add_object(converter, objectSettings, data);

        public bool wkhtmltopdf_convert(IntPtr converter) => WkHtmlBindings.wkhtmltopdf_convert(converter);

        public IntPtr wkhtmltopdf_create_converter(IntPtr globalSettings) => WkHtmlBindings.wkhtmltopdf_create_converter(globalSettings);

        public IntPtr wkhtmltopdf_create_global_settings() => WkHtmlBindings.wkhtmltopdf_create_global_settings();

        public IntPtr wkhtmltopdf_create_object_settings() => WkHtmlBindings.wkhtmltopdf_create_object_settings();

        public int wkhtmltopdf_current_phase(IntPtr converter) => WkHtmlBindings.wkhtmltopdf_current_phase(converter);

        public int wkhtmltopdf_deinit() => WkHtmlBindings.wkhtmltopdf_deinit();

        public void wkhtmltopdf_destroy_converter(IntPtr converter) => WkHtmlBindings.wkhtmltopdf_destroy_converter(converter);

        public int wkhtmltopdf_destroy_global_settings(IntPtr settings) => WkHtmlBindings.wkhtmltopdf_destroy_global_settings(settings);

        public int wkhtmltopdf_destroy_object_settings(IntPtr settings) => WkHtmlBindings.wkhtmltopdf_destroy_object_settings(settings);

        public int wkhtmltopdf_extended_qt() => WkHtmlBindings.wkhtmltopdf_extended_qt();

        public int wkhtmltopdf_get_global_setting(IntPtr settings,
            [MarshalAs((short)CustomUnmanagedType.LPUTF8Str)]
            string name,
            byte[] array)
        {
            int size = Marshal.SizeOf(array[0]) * array.Length;
            IntPtr pnt = Marshal.AllocHGlobal(size);

            try
            {
                // Copy the array to unmanaged memory.
                Marshal.Copy(array, 0, pnt, array.Length);

                return WkHtmlBindings.wkhtmltopdf_get_global_setting(settings, name, pnt, size);
            }
            finally
            {
                // Free the unmanaged memory.
                Marshal.FreeHGlobal(pnt);
            }
        }

        public int wkhtmltopdf_get_object_setting(IntPtr settings,
            [MarshalAs((short)CustomUnmanagedType.LPUTF8Str)]
            string name,
            byte[] array)
        {
            int size = Marshal.SizeOf(array[0]) * array.Length;
            IntPtr pnt = Marshal.AllocHGlobal(size);

            try
            {
                // Copy the array to unmanaged memory.
                Marshal.Copy(array, 0, pnt, array.Length);

                return WkHtmlBindings.wkhtmltopdf_get_object_setting(settings, name, pnt, size);
            }
            finally
            {
                // Free the unmanaged memory.
                Marshal.FreeHGlobal(pnt);
            }
        }

        public int wkhtmltopdf_get_output(IntPtr converter, out IntPtr data) => WkHtmlBindings.wkhtmltopdf_get_output(converter, out data);

        public int wkhtmltopdf_http_error_code(IntPtr converter) => WkHtmlBindings.wkhtmltopdf_http_error_code(converter);

        public int wkhtmltopdf_init(int useGraphics) => WkHtmlBindings.wkhtmltopdf_init(useGraphics);

        public int wkhtmltopdf_phase_count(IntPtr converter) => WkHtmlBindings.wkhtmltopdf_phase_count(converter);

        public IntPtr wkhtmltopdf_phase_description(IntPtr converter, int phase) => WkHtmlBindings.wkhtmltopdf_phase_description(converter, phase);

        public IntPtr wkhtmltopdf_progress_string(IntPtr converter) => WkHtmlBindings.wkhtmltopdf_progress_string(converter);

        public int wkhtmltopdf_set_error_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] StringCallback callback) => WkHtmlBindings.wkhtmltopdf_set_error_callback(converter, callback);

        public int wkhtmltopdf_set_finished_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] IntCallback callback) => WkHtmlBindings.wkhtmltopdf_set_finished_callback(converter, callback);

        public int wkhtmltopdf_set_global_setting(IntPtr settings,
            [MarshalAs((short)CustomUnmanagedType.LPUTF8Str)]
            string name,
            [MarshalAs((short)CustomUnmanagedType.LPUTF8Str)]
            string value) => WkHtmlBindings.wkhtmltopdf_set_global_setting(settings, name, value);

        public int wkhtmltopdf_set_object_setting(IntPtr settings,
            [MarshalAs((short)CustomUnmanagedType.LPUTF8Str)]
            string name,
            [MarshalAs((short)CustomUnmanagedType.LPUTF8Str)]
            string value) => WkHtmlBindings.wkhtmltopdf_set_object_setting(settings, name, value);

        public int wkhtmltopdf_set_phase_changed_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] VoidCallback callback) => WkHtmlBindings.wkhtmltopdf_set_phase_changed_callback(converter, callback);

        public int wkhtmltopdf_set_progress_changed_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] VoidCallback callback) => WkHtmlBindings.wkhtmltopdf_set_progress_changed_callback(converter, callback);

        public int wkhtmltopdf_set_warning_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] StringCallback callback) => WkHtmlBindings.wkhtmltopdf_set_warning_callback(converter, callback);

        public IntPtr wkhtmltopdf_version() => WkHtmlBindings.wkhtmltopdf_version();
    }
}