using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IttTti
{
    public partial class Form1 : Form
    {
        Bitmap image1;
        int x;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(Object sender, EventArgs e)
        {
            image1 = new Bitmap(x, x);

            progressBar1.Maximum = richTextBox1.Text.Length;

            int i = 0;

            for (int row = 0; row < image1.Width; row++)
            {
                for (int column = 0; column < image1.Height; column++)
                {
                    int pos = (++i - 1) * 3;

                    int r = (int) richTextBox1.Text[pos];
                    int g = (int) richTextBox1.Text[++pos];
                    int b = (int) richTextBox1.Text[++pos];

                    if (r > 255) r = 0;
                    if (g > 255) g = 0;
                    if (b > 255) b = 0;

                    Color newColor = Color.FromArgb(r, g, b);
                    image1.SetPixel(column, row, newColor);

                    if (pos + 3 >= richTextBox1.Text.Length)
                    {
                        row = image1.Width;
                        column = image1.Height;
                    }

                    progressBar1.Value = pos;

                    pictureBox1.Image = image1;

                    Application.DoEvents();
                }
            }

            pictureBox1.Image = image1;
            image1.Save("myfile.bmp", ImageFormat.Bmp);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int count = richTextBox1.Text.Length;
            label1.Text = $@"Символов: {count}";

            int div = count % 3;
            if (div == 1) count += 2;
            else if (div == 2) count += 1;
            x = (int) (Math.Ceiling(Math.Sqrt(count / 3)));

            label2.Text = $@"Остаток: {div}";
            label3.Text = $"X*Y: {x}";
        }
    }
}