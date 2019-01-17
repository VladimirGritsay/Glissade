using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForm {
    public class CoordinatesCalculator {
        private readonly Point startPoint;
        private Rectangle resultRectangle;
        public Rectangle CalculatedInstance { get { return resultRectangle; } }
        public CoordinatesCalculator(Point startPoint) {  
            this.startPoint = startPoint;
        }

        public void Calculate(Point endPoint) {
            int x = 0, y = 0, width = 0, hight = 0;
            if (startPoint.X < endPoint.X && startPoint.Y < endPoint.Y) {
                x = startPoint.X;
                y = startPoint.Y;
            } else if (startPoint.X > endPoint.X && startPoint.Y > endPoint.Y) {
                x = endPoint.X;
                y = endPoint.Y;
            } else if (startPoint.X > endPoint.X && startPoint.Y < endPoint.Y) {
                x = endPoint.X;
                y = startPoint.Y;
            } else if (startPoint.X < endPoint.X && startPoint.Y > endPoint.Y) {
                x = startPoint.X;
                y = endPoint.Y;
            }
            width = Math.Abs(startPoint.X - endPoint.X);
            hight = Math.Abs(startPoint.Y - endPoint.Y);
            resultRectangle = new Rectangle(x, y, width, hight);
            Console.WriteLine("X: {0}, Y: {1}, W: {2}, H:{3}", x, y, width, hight);
        }
    }
}
