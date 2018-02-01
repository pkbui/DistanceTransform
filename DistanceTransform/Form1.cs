using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System.Windows.Forms;

namespace DistanceTransform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Image<Bgr, byte> img = new Image<Bgr, byte>("hand.jpg");
            //If pixel value greater than threadshold, set it to black, else set it to white
            var oldImg = img.Convert<Gray, byte>().ThresholdBinary(new Gray(210), new Gray(255));
            var newImg = new Mat();
            CvInvoke.Invert(oldImg.Mat, newImg, Emgu.CV.CvEnum.DecompMethod.LU);
            //var dst = new Mat();
            //CvInvoke.DistanceTransform(binImg.Mat, dst, null, Emgu.CV.CvEnum.DistType.L1, 3);
            //var newImg = dst.ToImage<Bgr, byte>();
            var result = newImg.ToImage<Gray, byte>();
            imageBox1.Image = result;
            imageBox1.Height = result.Height;
            imageBox1.Width = result.Width;
        }
    }
}
