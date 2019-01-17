using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL {
    public class ScreenLoader {
       public string GetScreen() {
            FileHelper fileHelper = new FileHelper();
            string str = fileHelper.NameGeneration();
            Bitmap memoryImage = new Bitmap(1920, 1080);
            Size size = new Size(memoryImage.Width, memoryImage.Height);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);

            memoryGraphics.CopyFromScreen(0, 0, 0, 0, size);
            memoryImage.Save(str);
            return str;
        }
    }
}

