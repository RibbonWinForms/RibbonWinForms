// *********************************
// Message from Original Author:
//
// 2008 Jose Menendez Poo
// Please give me credit if you use this code. It's all I ask.
// Contact me for more info: menendezpoo@gmail.com
// *********************************
//
// Original project from http://ribbon.codeplex.com/
// Continue to support and maintain by http://officeribbon.codeplex.com/


using Microsoft.Win32;

namespace System.Windows.Forms.RibbonHelpers
{
    public static partial class WinApi
    {
        #region OsVersion class

        /// <summary>
        /// Static class that mimics <see href="https://docs.microsoft.com/de-de/windows/win32/sysinfo/version-helper-apis">
        /// Version Helper APIs</see> the get the operating system version the application is running under.
        /// 
        /// Note by @tajbender: However, as far as I can see for now (07/27/19), there is currently no reliable way to
        /// distinguish Windows 8.1 and 10 versions (and above) without adding a manifest file and/or read out registry values.
        /// 
        /// That's why the test for windows 10 checks for version 6.3 what in fact means to test for v8.1 and above. Take a
        /// look at <seealso href="https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-_osversioninfoexa">
        /// OSVERSIONINFOEXA structure</seealso>.
        /// 
        /// So, someone should care and take a look at this in the future.
        /// </summary>
        public static class OSVersion
        {
            /// <summary>
            /// Init values of properties.
            /// </summary>
            static OSVersion()
            {
                using (RegistryKey reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
                {
                    string productName = (string)reg.GetValue("ProductName");
                    string currentVersion = (string)reg.GetValue("CurrentVersion");
                    string currentBuild = (string)reg.GetValue("CurrentBuild");
                    string releaseId = (string)reg.GetValue("ReleaseId");
                    Caption = string.IsNullOrEmpty(productName) ? "Unknown" : productName;
                    ReleaseId = string.IsNullOrEmpty(releaseId) ? string.Empty : releaseId;
                    Version = new Version((string.IsNullOrEmpty(currentVersion) ? "0.0" : currentVersion + "." + (string.IsNullOrEmpty(currentBuild) ? "0" : currentBuild) + ".0"));
                }
            }

            /// <summary>
            /// The name of Operating system.
            /// </summary>
            public static string Caption { get; private set; } = null;

            /// <summary>
            /// Versionsnumber of OS.
            /// </summary>
            public static Version Version { get; private set; } = null;

            /// <summary>
            /// ReleaseId of OS. (Example Id = 1803 = Win10 Build in 03.2018)
            /// </summary>
            public static string ReleaseId { get; private set; } = null;
        }

        #endregion

        /// <summary>
        /// Gets if the current OS is Windows NT or later
        /// </summary>
        public static bool IsWindows => Environment.OSVersion.Platform == PlatformID.Win32NT;

        /// <summary>
        /// Gets a value indicating if operating system is Windows XP or higher
        /// </summary>
        public static bool IsWindowsXPOrGreater => IsWindows && Environment.OSVersion.Version.Major >= 5;

        /// <summary>
        /// Gets a value indicating if operating system is Windows Vista or higher
        /// </summary>
        public static bool IsWindowsVistaOrGreater => IsWindows && Environment.OSVersion.Version.Major >= 6;

        /// <summary>
        /// Gets a value indicating if operating system is Windows 8 or higher
        /// </summary>
        public static bool IsWindows8OrGreater => IsWindows && ((Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor >= 2) || (Environment.OSVersion.Version.Major > 6));

        /// <summary>
        /// Gets a value indicating if operating system is Windows 10 or higher
        /// </summary>
        public static bool IsWindows10OrGreater => IsWindows && ((OSVersion.Version.Major == 6 && OSVersion.Version.Minor == 3) || (OSVersion.Version.Major > 6));    // TODO: Do we really need to go through registry hacks for windows 10?

        /// <summary>
        /// Gets a value indicating ReleaseId
        /// </summary>
        public static string ReleaseID => OSVersion.ReleaseId;

    }
}
