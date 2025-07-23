//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace barkod_reader
//{
//    public partial class Form1 : Form
//    {
//        public Form1()
//        {
//            InitializeComponent();
//        }

//        private void Form1_Load(object sender, EventArgs e)
//        {

//        }

//        private void button1_Click(object sender, EventArgs e)
//        {

//        }
//    }
//}

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;

namespace barkod_reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private string GenerateRandomBarcode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string barkodVerisi = GenerateRandomBarcode(10);
            string dosyaYolu = "barkod.png";

            // Barkodu oluştur ve dosyaya kaydet
            var yazar = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new EncodingOptions { Width = 300, Height = 100 },
                Renderer = new ZXing.Rendering.BitmapRenderer()
            };

            using (var bitmap = yazar.Write(barkodVerisi))
            {
                bitmap.Save(dosyaYolu, ImageFormat.Png);
            }

            // Barkod görselini yazdır
            Image image = Image.FromFile(dosyaYolu);
            PrintDocument pd = new PrintDocument();

            // Yazıcı adını belirtmek istersen buraya yaz:
            // pd.PrinterSettings.PrinterName = "XP-80";

            pd.PrintPage += (s, ev) =>
            {
                ev.Graphics.DrawImage(image, new PointF(0, 0));
            };

            pd.Print();

            MessageBox.Show("Barkod yazdırıldı.");
        }
    }
}

