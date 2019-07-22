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
        /// Informations about OS.
        /// </summary>
        private static class OSVersion
        {
            /// <summary>
            /// Init values of properties.
            /// </summary>
            private static void Init()
            {
                RegistryKey reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");

                string productName = (string)reg.GetValue("ProductName");
                string currentVersion = (string)reg.GetValue("CurrentVersion");
                string currentBuild = (string)reg.GetValue("CurrentBuild");
                string releaseId = (string)reg.GetValue("ReleaseId");
                caption = string.IsNullOrEmpty(productName) ? "Unknown" : productName;
                id = string.IsNullOrEmpty(releaseId) ? string.Empty : releaseId;
                version = new Version((string.IsNullOrEmpty(currentVersion) ? "0.0" : currentVersion + "." + (string.IsNullOrEmpty(currentBuild) ? "0" : currentBuild) + ".0"));
            }

            static string id = null;
            static string caption = null;
            static Version version = null;

            /// <summary>
            /// The name of Operating system.
            /// </summary>
            public static string Caption {
                get {
                    if (caption == null)
                        Init();
                    return caption;
                }
            }

            /// <summary>
            /// Versionsnumber of OS.
            /// </summary>
            public static Version Version {
                get {
                    if (version == null)
                        Init();
                    return version;
                }
            }

            /// <summary>
            /// ReleaseId of OS. (Example Id = 1803 = Win10 Build in 03.2018)
            /// </summary>
            public static string ReleaseId {
                get {
                    if (id == null)
                        Init();
                    return id;
                }
            }
        }

        #endregion

        /// <summary>
        /// Gets if the current OS is Windows NT or later
        /// </summary>
        public static bool IsWindows => Environment.OSVersion.Platform == PlatformID.Win32NT;

        /// <summary>
        /// Gets a value indicating if operating system is vista or higher
        /// </summary>
        public static bool IsVista => IsWindows && Environment.OSVersion.Version.Major >= 6;

        /// <summary>
        /// Gets a value indicating if operating system is xp or higher
        /// </summary>
        public static bool IsXP => IsWindows && Environment.OSVersion.Version.Major >= 5;

        /// <summary>
        /// Gets a value indicating ReleaseId
        /// </summary>
        public static string ReleaseID => OSVersion.ReleaseId;

        /// <summary>
        /// Gets a value indicating if operating system is Win10
        /// </summary>
        public static bool IsWin10 => IsWindows && OSVersion.Version.Major == 6 && OSVersion.Version.Minor == 3;
    }
}
