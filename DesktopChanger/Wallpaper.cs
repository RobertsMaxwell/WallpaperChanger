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
    class Wallpaper
    {
        const uint SPI_SETDESKWALLPAPER = 0x14;
        const uint SPIF_UPDATEINIFILE = 0x1;

        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        static extern bool SystemParametersInfoW(uint uiAction, uint uiParam, string pvParam, uint fWinIni);

        public static bool Change(string imgPath)
        {
            Image img;
            string bmpImgPath;

            try
            {
                img = Image.FromFile(imgPath);
            }
            catch (OutOfMemoryException)
            {
                return false;
            }

            bmpImgPath = Path.Combine(Path.GetTempPath(), "image.bmp");
            img.Save(bmpImgPath, ImageFormat.Bmp);

            return SystemParametersInfoW(SPI_SETDESKWALLPAPER, 0, bmpImgPath, SPIF_UPDATEINIFILE);
        }
    }
}
