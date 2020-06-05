using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace DesktopChanger
{
    class Alternate
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        // Path to image or folder containing multiple images switching after timeInterval seconds
        public static void SwitchImage(string path, float timeInterval = 2, bool loop = false, bool shuffle = false)
        {
            if (File.GetAttributes(path) == FileAttributes.Directory)
            {
                List<string> li = Directory.GetFiles(path).ToList();

                if (shuffle) 
                {
                    Random rnd = new Random();
                    for (int i = li.Count - 1; i > 1; i--)
                    {
                        int rndNum = rnd.Next(0, i);
                        var filler = li[i];
                        li[i] = li[rndNum];
                        li[rndNum] = filler;
                    }
                }

                do
                {
                    foreach (string filePath in li)
                    {
                        if (Wallpaper.Change(filePath))
                        {
                            Thread.Sleep(Convert.ToInt32(timeInterval * 1000));
                        }
                    }
                } while (loop);
            }
            else
            {
                Wallpaper.Change(path);
            }
        }
    }
}
