using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VolumeMixerPlus.Win32
{
    public class Registry
    {
        /// <summary>
        /// Add/Remove registry entries for windows startup.
        /// </summary>
        /// <param name="AppName">Name of the application.</param>
        /// <param name="enable">if set to <c>true</c> [enable].</param>
        public static void SetStartup(string AppName, bool enable)
        {
            string runKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

            Microsoft.Win32.RegistryKey startupKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(runKey);

            if (enable)
            {
                if (startupKey.GetValue(AppName) == null)
                {
                    startupKey.Close();
                    startupKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(runKey, true);
                    // Add startup reg key
                    startupKey.SetValue(AppName, Application.ExecutablePath.ToString());
                    startupKey.Close();
                }
            }
            else
            {
                // remove startup
                startupKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(runKey, true);
                startupKey.DeleteValue(AppName, false);
                startupKey.Close();
            }
        }

        /// <summary>
        /// Check if the app is registered to auto start with the OS.
        /// </summary>
        /// <param name="AppName">Name of the application</param>
        /// <returns>Returns <c>true</c>, if the app named [AppName] starts with the OS.</returns>
        public static bool GetStartup(string AppName)
        {
            string runKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

            Microsoft.Win32.RegistryKey startupKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(runKey);

            if (startupKey.GetValue(AppName) != null)
            {
                startupKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(runKey, true);
                if (startupKey != null)
                    return startupKey.GetValue(AppName) as string == Application.ExecutablePath.ToString();
            }
            return false;
        }
    }
}
