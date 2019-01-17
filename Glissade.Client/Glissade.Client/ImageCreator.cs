using MyForm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glissade.Client {
    class ImageCreator : ILink {
        public byte[] ImageMaker() {
            using (FormSL form = new FormSL()) {
                form.ShowDialog();
                CoordinatesCalculator calculator = form.Calculator;  
                Rectangle rectangle = calculator.CalculatedInstance; 

                using (Bitmap memoryImage = new Bitmap(rectangle.Width, rectangle.Height)) {
                    Size size = new Size(memoryImage.Width, memoryImage.Height);

                    using (Graphics memoryGraphics = Graphics.FromImage(memoryImage)) {
                        memoryGraphics.CopyFromScreen(rectangle.X, rectangle.Y, 0, 0, size);

                        using (MemoryStream stream = new MemoryStream()) {  
                            memoryImage.Save(stream, ImageFormat.Png);  
                            stream.Position = 0;                        
                            byte[] result = stream.ToArray();
                            return result;
                        }
                    }
                }
            }
        }
    }
}