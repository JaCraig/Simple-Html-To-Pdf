using SimpleHtmlToPdf.UnmanagedHandler.Interfaces;
using System;
using System.Runtime.InteropServices;

namespace SimpleHtmlToPdf.UnmanagedHandler
{
    /// <summary>
    /// WKHTML module
    /// </summary>
    /// <seealso cref="SimpleHtmlToPdf.UnmanagedHandler.Interfaces.IWkHtmlModule"/>
    public class WkHtmlModule : IWkHtmlModule
    {
        /// <summary>
        /// Wkhtmltopdfs the add object.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <param name="objectSettings">The object settings.</param>
        /// <param name="data">The data.</param>
        public void wkhtmltopdf_add_object(IntPtr converter,
            IntPtr objectSettings,
            byte[] data) => WkHtmlBindings.wkhtmltopdf_add_object(converter, objectSettings, data);

        /// <summary>
        /// Wkhtmltopdfs the add object.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <param name="objectSettings">The object settings.</param>
        /// <param name="data">The data.</param>
        public void wkhtmltopdf_add_object(IntPtr converter,
            IntPtr objectSettings,
            [MarshalAs((short)CustomUnmanagedType.LPUTF8Str)] string data) => WkHtmlBindings.wkhtmltopdf_add_object(converter, objectSettings, data);

        /// <summary>
        /// Wkhtmltopdfs the convert.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <returns></returns>
        public bool wkhtmltopdf_convert(IntPtr converter) => WkHtmlBindings.wkhtmltopdf_convert(converter);

        /// <summary>
        /// Wkhtmltopdfs the create converter.
        /// </summary>
        /// <param name="globalSettings">The global settings.</param>
        /// <returns></returns>
        public IntPtr wkhtmltopdf_create_converter(IntPtr globalSettings) => WkHtmlBindings.wkhtmltopdf_create_converter(globalSettings);

        /// <summary>
        /// Wkhtmltopdfs the create global settings.
        /// </summary>
        /// <returns></returns>
        public IntPtr wkhtmltopdf_create_global_settings() => WkHtmlBindings.wkhtmltopdf_create_global_settings();

        /// <summary>
        /// Wkhtmltopdfs the create object settings.
        /// </summary>
        /// <returns></returns>
        public IntPtr wkhtmltopdf_create_object_settings() => WkHtmlBindings.wkhtmltopdf_create_object_settings();

        /// <summary>
        /// Wkhtmltopdfs the current phase.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <returns></returns>
        public int wkhtmltopdf_current_phase(IntPtr converter) => WkHtmlBindings.wkhtmltopdf_current_phase(converter);

        /// <summary>
        /// Wkhtmltopdfs the deinit.
        /// </summary>
        /// <returns></returns>
        public int wkhtmltopdf_deinit() => WkHtmlBindings.wkhtmltopdf_deinit();

        /// <summary>
        /// Wkhtmltopdfs the destroy converter.
        /// </summary>
        /// <param name="converter">The converter.</param>
        public void wkhtmltopdf_destroy_converter(IntPtr converter) => WkHtmlBindings.wkhtmltopdf_destroy_converter(converter);

        /// <summary>
        /// Wkhtmltopdfs the destroy global settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns></returns>
        public int wkhtmltopdf_destroy_global_settings(IntPtr settings) => WkHtmlBindings.wkhtmltopdf_destroy_global_settings(settings);

        /// <summary>
        /// Wkhtmltopdfs the destroy object settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns></returns>
        public int wkhtmltopdf_destroy_object_settings(IntPtr settings) => WkHtmlBindings.wkhtmltopdf_destroy_object_settings(settings);

        /// <summary>
        /// Wkhtmltopdfs the extended qt.
        /// </summary>
        /// <returns></returns>
        public int wkhtmltopdf_extended_qt() => WkHtmlBindings.wkhtmltopdf_extended_qt();

        /// <summary>
        /// Wkhtmltopdfs the get global setting.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="name">The name.</param>
        /// <param name="array">The array.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Wkhtmltopdfs the get object setting.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="name">The name.</param>
        /// <param name="array">The array.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Wkhtmltopdfs the get output.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public int wkhtmltopdf_get_output(IntPtr converter, out IntPtr data) => WkHtmlBindings.wkhtmltopdf_get_output(converter, out data);

        /// <summary>
        /// Wkhtmltopdfs the HTTP error code.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <returns></returns>
        public int wkhtmltopdf_http_error_code(IntPtr converter) => WkHtmlBindings.wkhtmltopdf_http_error_code(converter);

        /// <summary>
        /// Wkhtmltopdfs the initialize.
        /// </summary>
        /// <param name="useGraphics">The use graphics.</param>
        /// <returns></returns>
        public int wkhtmltopdf_init(int useGraphics) => WkHtmlBindings.wkhtmltopdf_init(useGraphics);

        /// <summary>
        /// Wkhtmltopdfs the phase count.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <returns></returns>
        public int wkhtmltopdf_phase_count(IntPtr converter) => WkHtmlBindings.wkhtmltopdf_phase_count(converter);

        /// <summary>
        /// Wkhtmltopdfs the phase description.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <param name="phase">The phase.</param>
        /// <returns></returns>
        public IntPtr wkhtmltopdf_phase_description(IntPtr converter, int phase) => WkHtmlBindings.wkhtmltopdf_phase_description(converter, phase);

        /// <summary>
        /// Wkhtmltopdfs the progress string.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <returns></returns>
        public IntPtr wkhtmltopdf_progress_string(IntPtr converter) => WkHtmlBindings.wkhtmltopdf_progress_string(converter);

        /// <summary>
        /// Wkhtmltopdfs the set error callback.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <param name="callback">The callback.</param>
        /// <returns></returns>
        public int wkhtmltopdf_set_error_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] StringCallback callback) => WkHtmlBindings.wkhtmltopdf_set_error_callback(converter, callback);

        /// <summary>
        /// Wkhtmltopdfs the set finished callback.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <param name="callback">The callback.</param>
        /// <returns></returns>
        public int wkhtmltopdf_set_finished_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] IntCallback callback) => WkHtmlBindings.wkhtmltopdf_set_finished_callback(converter, callback);

        /// <summary>
        /// Wkhtmltopdfs the set global setting.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int wkhtmltopdf_set_global_setting(IntPtr settings,
            [MarshalAs((short)CustomUnmanagedType.LPUTF8Str)]
            string name,
            [MarshalAs((short)CustomUnmanagedType.LPUTF8Str)]
            string value) => WkHtmlBindings.wkhtmltopdf_set_global_setting(settings, name, value);

        /// <summary>
        /// Wkhtmltopdfs the set object setting.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int wkhtmltopdf_set_object_setting(IntPtr settings,
            [MarshalAs((short)CustomUnmanagedType.LPUTF8Str)]
            string name,
            [MarshalAs((short)CustomUnmanagedType.LPUTF8Str)]
            string value) => WkHtmlBindings.wkhtmltopdf_set_object_setting(settings, name, value);

        /// <summary>
        /// Wkhtmltopdfs the set phase changed callback.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <param name="callback">The callback.</param>
        /// <returns></returns>
        public int wkhtmltopdf_set_phase_changed_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] VoidCallback callback) => WkHtmlBindings.wkhtmltopdf_set_phase_changed_callback(converter, callback);

        /// <summary>
        /// Wkhtmltopdfs the set progress changed callback.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <param name="callback">The callback.</param>
        /// <returns></returns>
        public int wkhtmltopdf_set_progress_changed_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] VoidCallback callback) => WkHtmlBindings.wkhtmltopdf_set_progress_changed_callback(converter, callback);

        /// <summary>
        /// Wkhtmltopdfs the set warning callback.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <param name="callback">The callback.</param>
        /// <returns></returns>
        public int wkhtmltopdf_set_warning_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] StringCallback callback) => WkHtmlBindings.wkhtmltopdf_set_warning_callback(converter, callback);

        /// <summary>
        /// Wkhtmltopdfs the version.
        /// </summary>
        /// <returns></returns>
        public IntPtr wkhtmltopdf_version() => WkHtmlBindings.wkhtmltopdf_version();
    }
}