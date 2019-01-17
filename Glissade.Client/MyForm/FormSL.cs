using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyForm {
    public partial class FormSL : Form {
        Pen pen = new Pen(Brushes.LawnGreen, 1);
        private CoordinatesCalculator calculator = null;
        public CoordinatesCalculator Calculator { get { return calculator; } }
        public FormSL() {
            InitializeComponent();
        }

        void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
            calculator = new CoordinatesCalculator(e.Location);      
        }

        void pictureBox1_MouseUp(object sender, MouseEventArgs e) {
            calculator.Calculate(e.Location);
            pictureBox1.Paint -= Selection_Paint;
            pictureBox1.Invalidate();
            Close();
        }

        private void Selection_Paint(object sender, PaintEventArgs e) {
            if (calculator != null) {
                e.Graphics.DrawRectangle(pen, calculator.CalculatedInstance);
            }
        }

        void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            if (calculator != null) {
                calculator.Calculate(e.Location);
                if (e.Button == MouseButtons.Left)
                    (sender as PictureBox).Refresh();
            }
        }
    }
}
