using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1qweasdyxc.Properties;

namespace WindowsFormsApp1qweasdyxc
{
    public partial class Form1 : Form
    {
        int[] puvodniRozmery = new int[2];
        string path = (new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName) + "\\Properties\\images-_2_.jpg";
        Image imgPuvodni;
        Image img;
        Image zmensovanejImg;
        bool cernobile_predtim = false;

        public Form1()
        {
            imgPuvodni = Image.FromFile(path);
            img = new Bitmap(imgPuvodni);
            puvodniRozmery[0] = img.Width; puvodniRozmery[1] = img.Height;
            InitializeComponent();
            pictureBox1.Paint += pictureBox1_Paint;
            Kresleni(0.3333333, false);
        }

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this);
            f2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            g.DrawImage(zmensovanejImg, pictureBox1.Width / 2 - zmensovanejImg.Width / 2, pictureBox1.Height / 2 - zmensovanejImg.Height / 2/*, pictureBox1.Width, pictureBox1.Height*/); // Vykreslení obrázku na pozici (0, 0) s rozměry pictureBox1
        }

        public void Kresleni(double zoom, bool gs)
        {
            if (gs && !cernobile_predtim)
                img = ConvertToGrayScale(img);
            else if (!gs && cernobile_predtim)
                img = new Bitmap(imgPuvodni);
            zmensovanejImg = new Bitmap(img, (int)(puvodniRozmery[0] * zoom), (int)(puvodniRozmery[1] * zoom));
            pictureBox1.Invalidate();
            cernobile_predtim = gs;
        }

        private Image ConvertToGrayScale(Image originalImage)
        {
            Bitmap grayScaleImage = new Bitmap(originalImage.Width, originalImage.Height);

            // Procházení každého pixelu obrázku a nastavení jeho barvy na odstín šedi
            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color pixelColor = ((Bitmap)originalImage).GetPixel(x, y);
                    int grayScaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B); // Převod na odstín šedi

                    Color newColor = Color.FromArgb(grayScaleValue, grayScaleValue, grayScaleValue);
                    grayScaleImage.SetPixel(x, y, newColor);
                }
            }
            return grayScaleImage;
        }


    }
}
