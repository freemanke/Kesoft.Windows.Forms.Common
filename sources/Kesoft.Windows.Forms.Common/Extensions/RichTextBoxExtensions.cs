namespace System.Windows.Forms
{
    /// <summary>
    /// RichText控件扩展。
    /// </summary>
    public static class RichTextBoxExtensions
    {
        /// <summary>
        /// 追加一行文本。
        /// </summary>
        /// <param name="t"></param>
        /// <param name="format">格式消息。</param>
        /// <param name="args">可选参数。</param>
        public static void AppendLine(this RichTextBox t, string format, params object[] args)
        {
            var line = string.Format(format, args);
            if (!string.IsNullOrEmpty(format))
            {
                t.AppendText((t.Lines.Length == 0 ? "" : "\r\n") + line);
            }
        }
    }
}