using System;
using System.Runtime.InteropServices;

namespace SimpleHtmlToPdf.UnmanagedHandler.Interfaces
{
    /// <summary>
    /// WKHTML Module interface
    /// </summary>
    public interface IWkHtmlModule
    {
        /// <summary>
        /// Wkhtmltopdfs the add object.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <param name="objectSettings">The object settings.</param>
        /// <param name="data">The data.</param>
        void wkhtmltopdf_add_object(IntPtr converter,
            IntPtr objectSettings,
            byte[] data);

        /// <summary>
        /// Wkhtmltopdfs the add object.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <param name="objectSettings">The object settings.</param>
        /// <param name="data">The data.</param>
        void wkhtmltopdf_add_object(IntPtr converter,
            IntPtr objectSettings,
            [MarshalAs((short)CustomUnmanagedType.LPUTF8Str)] string data);

        /// <summary>
        /// Wkhtmltopdfs the convert.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <returns></returns>
        bool wkhtmltopdf_convert(IntPtr converter);

        /// <summary>
        /// Wkhtmltopdfs the create converter.
        /// </summary>
        /// <param name="globalSettings">The global settings.</param>
        /// <returns></returns>
        IntPtr wkhtmltopdf_create_converter(IntPtr globalSettings);

        /// <summary>
        /// Wkhtmltopdfs the create global settings.
        /// </summary>
        /// <returns></returns>
        IntPtr wkhtmltopdf_create_global_settings();

        /// <summary>
        /// Wkhtmltopdfs the create object settings.
        /// </summary>
        /// <returns></returns>
        IntPtr wkhtmltopdf_create_object_settings();

        /// <summary>
        /// Wkhtmltopdfs the current phase.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <returns></returns>
        int wkhtmltopdf_current_phase(IntPtr converter);

        /// <summary>
        /// Wkhtmltopdfs the deinit.
        /// </summary>
        /// <returns></returns>
        int wkhtmltopdf_deinit();

        /// <summary>
        /// Wkhtmltopdfs the destroy converter.
        /// </summary>
        /// <param name="converter">The converter.</param>
        void wkhtmltopdf_destroy_converter(IntPtr converter);

        /// <summary>
        /// Wkhtmltopdfs the destroy global settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns></returns>
        int wkhtmltopdf_destroy_global_settings(IntPtr settings);

        /// <summary>
        /// Wkhtmltopdfs the destroy object settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns></returns>
        int wkhtmltopdf_destroy_object_settings(IntPtr settings);

        /// <summary>
        /// Wkhtmltopdfs the extended qt.
        /// </summary>
        /// <returns></returns>
        int wkhtmltopdf_extended_qt();

        /// <summary>
        /// Wkhtmltopdfs the get global setting.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="name">The name.</param>
        /// <param name="array">The array.</param>
        /// <returns></returns>
        int wkhtmltopdf_get_global_setting(IntPtr settings,
            [MarshalAs((short)CustomUnmanagedType.LPUTF8Str)]
            string name,
            byte[] array);

        /// <summary>
        /// Wkhtmltopdfs the get object setting.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="name">The name.</param>
        /// <param name="array">The array.</param>
        /// <returns></returns>
        int wkhtmltopdf_get_object_setting(IntPtr settings,
            [MarshalAs((short)CustomUnmanagedType.LPUTF8Str)]
            string name,
            byte[] array);

        /// <summary>
        /// Wkhtmltopdfs the get output.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        int wkhtmltopdf_get_output(IntPtr converter, out IntPtr data);

        /// <summary>
        /// Wkhtmltopdfs the HTTP error code.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <returns></returns>
        int wkhtmltopdf_http_error_code(IntPtr converter);

        /// <summary>
        /// Wkhtmltopdfs the initialize.
        /// </summary>
        /// <param name="useGraphics">The use graphics.</param>
        /// <returns></returns>
        int wkhtmltopdf_init(int useGraphics);

        /// <summary>
        /// Wkhtmltopdfs the phase count.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <returns></returns>
        int wkhtmltopdf_phase_count(IntPtr converter);

        /// <summary>
        /// Wkhtmltopdfs the phase description.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <param name="phase">The phase.</param>
        /// <returns></returns>
        IntPtr wkhtmltopdf_phase_description(IntPtr converter, int phase);

        /// <summary>
        /// Wkhtmltopdfs the progress string.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <returns></returns>
        IntPtr wkhtmltopdf_progress_string(IntPtr converter);

        /// <summary>
        /// Wkhtmltopdfs the set error callback.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <param name="callback">The callback.</param>
        /// <returns></returns>
        int wkhtmltopdf_set_error_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] StringCallback callback);

        /// <summary>
        /// Wkhtmltopdfs the set finished callback.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <param name="callback">The callback.</param>
        /// <returns></returns>
        int wkhtmltopdf_set_finished_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] IntCallback callback);

        /// <summary>
        /// Wkhtmltopdfs the set global setting.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        int wkhtmltopdf_set_global_setting(IntPtr settings,
            [MarshalAs((short)CustomUnmanagedType.LPUTF8Str)]
            string name,
            [MarshalAs((short)CustomUnmanagedType.LPUTF8Str)]
            string value);

        /// <summary>
        /// Wkhtmltopdfs the set object setting.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        int wkhtmltopdf_set_object_setting(IntPtr settings,
            [MarshalAs((short)CustomUnmanagedType.LPUTF8Str)]
            string name,
            [MarshalAs((short)CustomUnmanagedType.LPUTF8Str)]
            string value);

        /// <summary>
        /// Wkhtmltopdfs the set phase changed callback.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <param name="callback">The callback.</param>
        /// <returns></returns>
        int wkhtmltopdf_set_phase_changed_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] VoidCallback callback);

        /// <summary>
        /// Wkhtmltopdfs the set progress changed callback.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <param name="callback">The callback.</param>
        /// <returns></returns>
        int wkhtmltopdf_set_progress_changed_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] VoidCallback callback);

        /// <summary>
        /// Wkhtmltopdfs the set warning callback.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <param name="callback">The callback.</param>
        /// <returns></returns>
        int wkhtmltopdf_set_warning_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)] StringCallback callback);

        /// <summary>
        /// Wkhtmltopdfs the version.
        /// </summary>
        /// <returns></returns>
        IntPtr wkhtmltopdf_version();
    }
}