using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.Win32;

namespace DesktopChanger
{
    class Program
    {
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        static extern bool SystemParametersInfoW(uint uiAction, uint uiParam, string pvParam, uint fWinIni);

        static void Main(string[] args)
        {
            Console.Write("Type Absolute Image Path: ");
            string imgPath = Console.ReadLine();

            Image img = Image.FromFile(imgPath);
            string tempPath = Path.Combine(Path.GetTempPath(), "image.bmp");
            img.Save(tempPath, ImageFormat.Bmp);

            var status = SystemParametersInfoW(20, 0, tempPath, 0);
            Console.WriteLine(status);
        }
    }
}
