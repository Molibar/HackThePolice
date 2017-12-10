using System.Drawing;
using QRCoder;

namespace HackThePolice.QRCodeGenerator
{
    public class Generator
    {
        public Bitmap GetQRCode(string url)
        {
            var qrGenerator = new QRCoder.QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(url, QRCoder.QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
        }
    }
}
