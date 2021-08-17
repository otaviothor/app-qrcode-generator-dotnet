using System.Drawing;
using System.IO;
using QRCoder;

namespace QrWeb
{
  public static class QrCodeGenerator
  {
    public static Bitmap GenerateImage(string url)
    {
      var qrGerenator = new QRCodeGenerator();
      var qrCodeData = qrGerenator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
      var qrCode = new QRCode(qrCodeData);
      var qrCodeImage = qrCode.GetGraphic(10);
      return qrCodeImage;
    }

    private static byte[] ImageToByte(Image image)
    {
      using var stream = new MemoryStream();
      image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
      return stream.ToArray();
    }

    public static byte[] GenerateByteArray(string url)
    {
      var image = GenerateImage(url);
      return ImageToByte(image);
    }
  }
}