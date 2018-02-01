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
            var binImg = img.Convert<Gray, byte>().ThresholdBinary(new Gray(210), new Gray(255));
            
            imageBox1.Image = binImg;
            imageBox1.Height = binImg.Height;
            imageBox1.Width = binImg.Width;
        }
    }
}
