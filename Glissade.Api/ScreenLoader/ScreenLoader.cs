using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SL {
    public static class LinkFactory {

        public static ILink GetLink() {

            return new ScreenLoader();
        }
    }

    class ScreenLoader : ILink {


        public (string, byte[]) GetLink() {
            FileHelper fileHelper = new FileHelper();
            string str = fileHelper.GetLink();
            Bitmap memoryImage = new Bitmap(1920, 1080);
            Size size = new Size(memoryImage.Width, memoryImage.Height);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);

            memoryGraphics.CopyFromScreen(0, 0, 0, 0, size);
            memoryImage.Save(str);


            byte[] ScreenBytes = fileHelper.GetScreen();

            var AllInfo = (str, ScreenBytes);

            return AllInfo;
        }
    }
}
