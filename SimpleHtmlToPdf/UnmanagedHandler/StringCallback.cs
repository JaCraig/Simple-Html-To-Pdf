using System;
using System.Runtime.InteropServices;

namespace SimpleHtmlToPdf.UnmanagedHandler
{
    /// <summary>
    /// String call back delegate
    /// </summary>
    /// <param name="converter">The converter.</param>
    /// <param name="str">The string.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void StringCallback(IntPtr converter, [MarshalAs(UnmanagedType.LPStr)] string str);
}