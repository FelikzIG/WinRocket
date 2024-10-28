using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
    internal class win
    {

    }

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

                    Console.WriteLine("Windows Update service startup type has been set to Disabled.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }

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

                    Console.WriteLine("Windows Update service startup type has been set to Disabled.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}