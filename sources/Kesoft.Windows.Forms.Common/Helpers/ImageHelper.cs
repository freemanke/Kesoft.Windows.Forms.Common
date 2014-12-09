using System;
using System.IO;

namespace System.Drawing
{
    /// <summary>
    /// Image帮助类。
    /// </summary>
    public static class ImageHelper
    {
        /// <summary>
        /// 转换成Base64字符串。
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ToBase64String(Image image)
        {
            if (image == null) throw new ArgumentNullException("image");
            using (var stream = new MemoryStream())
            {
                image.Save(stream, image.RawFormat);
                return Convert.ToBase64String(stream.GetBuffer());
            }
        }

        /// <summary>
        /// 从Base64字符串中构造图像。
        /// </summary>
        /// <param name="base64"> Base64字符串。 </param>
        /// <returns> 构造出的图像。 </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Image FromBase64String(string base64)
        {
            if (string.IsNullOrEmpty(base64)) throw new ArgumentNullException("base64");
            using (var stream = new MemoryStream(Convert.FromBase64String(base64)))
            {
                return Image.FromStream(stream);
            }
        }

        /// <summary>
        /// 转换成PNG格式编码的字节数组。
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static byte[] ToBytes(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// 从字节数组中构造图像。
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static Image FromBytes(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }
    }
}