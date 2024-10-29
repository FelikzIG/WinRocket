using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class
{
    public class WinRocket
    {
        //Clears the inputed directory
        public void dirClear(string directory)
        {
            foreach (var files in Directory.GetFiles(directory))
            {
                try
                {
                    File.Delete(files);
                }
                catch (Exception)
                {
                    // Ignore the failure and continue
                }
            }
        }

        //Disable Windows Update
        public void disableWinUpdate()
        {
            //0 = Boot
            //1 = System
            //2 = Automatic
            //3 = Manual
            //4 = Disabled

            try
            {
                // Define the service name
                string serviceName = "wuauserv"; // Windows Update service

                // Create a ServiceController instance
                using (ServiceController service = new ServiceController(serviceName))
                {
                    // Stop the service if it is running
                    if (service.Status == ServiceControllerStatus.Running)
                    {
                        service.Stop();
                        service.WaitForStatus(ServiceControllerStatus.Stopped);
                    }

                    // Change the startup type to Disabled
                    using (var managementObject = new System.Management.ManagementObject($"Win32_Service.Name='{serviceName}'"))
                    {
                        managementObject["StartMode"] = "Disabled";
                        managementObject.Put();
                    }

                    
                }
            }
            catch (Exception ex)
            {
                //report eeror if wanted
            }

        }

        //Enable Windows Update
        public void enableWinUpdate()
        {
            //0 = Boot
            //1 = System
            //2 = Automatic
            //3 = Manual
            //4 = Disabled

            try
            {
                // Define the service name
                string serviceName = "wuauserv"; // Windows Update service

                // Create a ServiceController instance
                using (ServiceController service = new ServiceController(serviceName))
                {
                        service.Start();
                        service.WaitForStatus(ServiceControllerStatus.Running);

                    // Change the startup type to Disabled
                    using (var managementObject = new System.Management.ManagementObject($"Win32_Service.Name='{serviceName}'"))
                    {
                        managementObject["StartMode"] = "Automatic";
                        managementObject.Put();
                    }

                    
                }
            }
            catch (Exception ex)
            {
                //report eeror if wanted
            }
        }

        //Disable Windows Defender (Realtime protection)
        public void disableWinDefender()
        {
            try
            {
                // PowerShell command to disable Windows Defender
                string command = "Set-MpPreference -DisableRealtimeMonitoring $true";

                // Create a new process to run PowerShell
                ProcessStartInfo processInfo = new ProcessStartInfo("powershell.exe", command)
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(processInfo))
                {
                    // Read the output and error
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                //report eeror if wanted
            }
        }

        //Enable Windows Defender (Realtime protection)
        public void enableWinDefender()
        {
            try
            {
                // PowerShell command to enable Windows Defender
                string command = "Set-MpPreference -DisableRealtimeMonitoring $false; Start-Service -Name WinDefend";

                // Create a new process to run PowerShell
                ProcessStartInfo processInfo = new ProcessStartInfo("powershell.exe", command)
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(processInfo))
                {
                    // Read the output and error
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                //report eeror if wanted
            }
        }

        //Disable Windows Game Mode
        public void disableWinGM()
        {
            try
            {
                // Open the GameBar key
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\GameBar", true))
                {
                    if (key != null)
                    {
                        // Set the GameModeEnabled value to 0 (disabled)
                        key.SetValue("GameModeEnabled", 0, RegistryValueKind.DWord);
                    }
                    else
                    {
                        
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }


        //Enable Windows Game Mode
        public void enableWinGM()
        {
            try
            {
                // Open the GameBar key
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\GameBar", true))
                {
                    if (key != null)
                    {
                        // Set the GameModeEnabled value to 1 (enabled)
                        key.SetValue("GameModeEnabled", 1, RegistryValueKind.DWord);
                    }
                    else
                    {
                        
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        //Uninstall Microsoft One Drive
        public void removeWinOD()
        {
            try
            {
                // Determine the architecture of the system
                string uninstallCommand;

                if (Environment.Is64BitOperatingSystem)
                {
                    // Use the 64-bit uninstall command
                    uninstallCommand = @"%SystemRoot%\System32\OneDriveSetup.exe /uninstall";
                }
                else
                {
                    // Use the 32-bit uninstall command
                    uninstallCommand = @"%SystemRoot%\SysWOW64\OneDriveSetup.exe /uninstall";
                }

                // Create a process to execute the uninstall command
                ProcessStartInfo processInfo = new ProcessStartInfo("cmd.exe", "/c " + uninstallCommand)
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(processInfo))
                {
                    // Read the output and error
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}