﻿using System;
using System.Runtime.InteropServices;

namespace SimpleHtmlToPdf.UnmanagedHandler
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void VoidCallback(IntPtr converter);
}