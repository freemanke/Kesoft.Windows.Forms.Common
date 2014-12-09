namespace System.Windows.Forms
{
    /// <summary>
    /// 打开文本文件对话框。
    /// </summary>
    public static class OpenFileDialogHelper
    {
        /// <summary>
        /// 打开对话框。
        /// </summary>
        public static DialogResult OpenTextFileDialog()
        {
            return Create("Text|*.txt").ShowDialog();
        }

        /// <summary>
        /// 打开对话框。
        /// </summary>
        public static DialogResult OpenExcelFileDialog()
        {
            return Create("Excel File|*.xlsx;*.xls").ShowDialog();
        }

        /// <summary>
        /// 打开对话框。
        /// </summary>
        public static DialogResult OpenImageFileDialog()
        {
            return Create("Image File|*.png;*.jpg;*.bmp;*.gif").ShowDialog();
        }

        private static OpenFileDialog Create(string filter)
        {
            return new OpenFileDialog
                       {
                           Filter = filter,
                           FilterIndex = 0,
                           RestoreDirectory = true,
                           InitialDirectory = Environment.CurrentDirectory,
                       };
        }
    }
}