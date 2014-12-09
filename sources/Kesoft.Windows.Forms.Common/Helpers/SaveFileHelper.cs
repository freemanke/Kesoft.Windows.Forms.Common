using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace System.Windows.Forms
{
    /// <summary>
    /// 保存文件帮助类。
    /// </summary>
    public static class SaveFileHelper
    {
        /// <summary>
        /// 保存图片文件。
        /// </summary>
        /// <param name="image">图像。 </param>
        public static void SaveImageFileWithDialog(Image image)
        {
            var dialog = SaveFileDialogHelper.OpenSaveImageFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var format = ImageFormat.Png;
                switch (dialog.FilterIndex)
                {
                    case 0:
                        format = ImageFormat.Png;
                        break;
                    case 1:
                        format = ImageFormat.Jpeg;
                        break;
                    case 2:
                        format = ImageFormat.Bmp;
                        break;
                    case 3:
                        format = ImageFormat.Gif;
                        break;
                }
                try
                {
                    image.Save(dialog.FileName, format);
                }
                catch (Exception e)
                {
                    MessageBoxHelper.Error(e.Message);
                }
            }
        }


        /// <summary>
        /// 保存文本文件。
        /// </summary>
        /// <param name="sb"> </param>
        public static void SaveTextFileWithDialog(StringBuilder sb)
        {
            var dialog = SaveFileDialogHelper.OpenSaveTextFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = null;
                try
                {
                    fs = File.Open(dialog.FileName, FileMode.OpenOrCreate);
                    var buffer = Encoding.UTF8.GetBytes(sb.ToString());
                    fs.Write(buffer, 0, buffer.Length);
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.Error(ex.Message);
                }
                finally
                {
                    if (fs != null) fs.Close();
                }
            }
        }
    }
}