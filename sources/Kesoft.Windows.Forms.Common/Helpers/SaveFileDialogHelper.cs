using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace System.Windows.Forms
{
    public static class SaveFileDialogHelper
    {
        /// <summary>
        /// 创建保存文件对话框。
        /// </summary>
        /// <returns>保存文件对话框。</returns>
        public static SaveFileDialog OpenSaveExcelFileDialog()
        {
            return CreateSaveFileDialog(@"Excel File|*.xlsx;*.xls");
        }

        /// <summary>
        /// 创建保存文件对话框。
        /// </summary>
        /// <returns>保存文件对话框。</returns>
        public static SaveFileDialog OpenSaveTextFileDialog()
        {
            return CreateSaveFileDialog(@"Text File|*.txt");
        }

        /// <summary>
        /// 创建保存文件对话框。
        /// </summary>
        /// <returns>保存文件对话框。</returns>
        public static SaveFileDialog OpenSaveImageFileDialog()
        {
            return CreateSaveFileDialog(@"Image |*.png;*.jpg;*.bmp;*.gif");
        }

        /// <summary>
        /// 创建保存文件对话框。
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        private static SaveFileDialog CreateSaveFileDialog(string filter)
        {
            var dialog = new SaveFileDialog
                             {
                                 Filter = filter,
                                 FilterIndex = 0,
                                 CreatePrompt = false,
                                 RestoreDirectory = true,
                                 InitialDirectory = Environment.CurrentDirectory,
                                 FileName = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"),
                             };

            return dialog;
        }
    }
}