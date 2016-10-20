using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace CommonLibrary
{
    public class Images
    {
        public static byte[] ImageToByteArray(Image imageIn)
        {
            var ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }
        public static string ImageToBase64(Image imageIn)
        {
            var ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Jpeg);
            var imageBytes = ms.ToArray();
            return Convert.ToBase64String(imageBytes);
        }
        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            var ms = new MemoryStream(byteArrayIn);
            var returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static Image ResizeImage(Image img, int maxWidth, int maxHeight)
        {
            double w = 0;
            double h = 0;

            if (img.Width > img.Height)
            {
                w = 1;
                h = img.Height / (double)img.Width;
            }
            else if (img.Width < img.Height)
            {
                w = img.Width / (double)img.Height;
                h = 1;
            }
            else if (img.Width == img.Height)
            {
                w = 1;
                h = 1;
            }

            return new Bitmap(img, new Size((int)Math.Round(maxWidth * w), (int)Math.Round(maxHeight * h)));
        }
    }
}
