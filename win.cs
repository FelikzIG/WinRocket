using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    internal class win
    {

    }

    public class WinRocket
    {
        public void tempClear(string tempDir)
        {
            foreach (var name in Directory.GetFiles(tempDir))
            {
                try
                {
                    File.Delete(name);
                }
                catch (Exception)
                {
                    // Ignore the failure and continue
                }
            }
        }
    }
}
