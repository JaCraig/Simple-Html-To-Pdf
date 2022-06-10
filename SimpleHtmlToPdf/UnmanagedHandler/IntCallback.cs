using System;
using System.Runtime.InteropServices;

namespace SimpleHtmlToPdf.UnmanagedHandler
{
    /// <summary>
    /// Int Callback delegate
    /// </summary>
    /// <param name="converter">The converter.</param>
    /// <param name="integer">The integer.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void IntCallback(IntPtr converter, int integer);
}