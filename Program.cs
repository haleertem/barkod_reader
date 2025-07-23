using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace barkod_reader
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

//using System;
//using System.Drawing;
//using System.Drawing.Printing;
//using System.IO;
//using System.Text;

//class Program
//{
//    static void Main()
//    {
//        // 1. Yazıcının sistemdeki adını yaz
//        string printerName = "Xprinter XP-490B";

//        // 2. Rastgele barkod verisi üret
//        string barcodeData = GenerateRandomCode(8);

//        // 3. TSPL komutlarını hazırla
//        string tspl = $@"
//SIZE 70 mm, 50 mm
//GAP 3 mm, 0 mm
//DENSITY 8
//CLS
//CODE128 50,50,{barcodeData},100,1
//TEXT 50,160,""3"",0,1,1,""{barcodeData}""
//PRINT 1
//";

//        // 4. Yazıcıya gönder
//        SendRawStringToPrinter(printerName, tspl);
//        Console.WriteLine($"Yazdırıldı: {barcodeData}");
//    }

//    static string GenerateRandomCode(int length)
//    {
//        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
//        var random = new Random();
//        var result = new char[length];
//        for (int i = 0; i < length; i++)
//            result[i] = chars[random.Next(chars.Length)];
//        return new string(result);
//    }

//    static void SendRawStringToPrinter(string printerName, string data)
//    {
//        var printerSettings = new PrinterSettings { PrinterName = printerName };

//        if (!printerSettings.IsValid)
//        {
//            Console.WriteLine($"Yazıcı bulunamadı: {printerName}");
//            return;
//        }

//        var doc = new PrintDocument
//        {
//            PrinterSettings = printerSettings,
//            DocumentName = "XP-490B Barkod",
//        };

//        doc.PrintPage += (sender, e) =>
//        {
//            // Yazıcıya byte olarak TSPL komutlarını gönder
//            var bytes = Encoding.ASCII.GetBytes(data);
//            e.Graphics.DrawString("", new Font("Arial", 1), Brushes.Black, 0, 0); // boş çizim, zorunlu
//            e.Graphics.Dispose(); // çizim tamamlandı
//        };

//        doc.Print(); // yazdırmayı tetikle
//    }
//}

