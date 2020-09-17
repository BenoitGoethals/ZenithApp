using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace ZenithApp.helpers
{
    public static class ImageHelper
    {
        public static byte[] ConvertToByte(Bitmap bitmap)
        {
            using MemoryStream mStream = new MemoryStream();
            bitmap.Save(mStream, bitmap.RawFormat);
            return mStream.ToArray();
        }


        public static byte[] ConvertToByte(string path)
        {
            using var stream = new MemoryStream();
            ConvertToBitmap(path).Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            return stream.ToArray();
        }

        public static Bitmap ConvertToBitmap(string path)
        {
            var width = 128;
            var height = 128;
            using var pngStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            using var image = new Bitmap(pngStream);
            var resized = new Bitmap(width, height);
            using var graphics = Graphics.FromImage(resized);
            graphics.CompositingQuality = CompositingQuality.HighSpeed;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.DrawImage(image, 0, 0, width, height);

            return resized;
        }

        public static Bitmap ConvertToBitmap(byte[] bitmap)
        {
            if (bitmap == null) return default;
            using MemoryStream mStream = new MemoryStream(bitmap);
            return new Bitmap(mStream);
        }

        public static string ConvertToBas64(byte[] img)
        {
            if (img != null)
            {
                return $"data:image/png;base64,{Convert.ToBase64String(img)}";
            }

            return null;


        }
    }
}