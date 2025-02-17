﻿using System;
using System.Runtime.InteropServices;
using DuckDB.NET.Linux;
using DuckDB.NET.MacOS;
using DuckDB.NET.Windows;

namespace DuckDB.NET
{
    public static class PlatformIndependentBindings
    {
        static PlatformIndependentBindings()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                NativeMethods = new WindowsBindNativeMethods();
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                NativeMethods = new MacOSBindNativeMethods();
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                NativeMethods = new LinuxBindNativeMethods();
            }

            if (NativeMethods == null)
            {
                throw new PlatformNotSupportedException($"{RuntimeInformation.OSDescription} not supported");
            }
        }

        public static IBindNativeMethods NativeMethods { get; }
    }
}