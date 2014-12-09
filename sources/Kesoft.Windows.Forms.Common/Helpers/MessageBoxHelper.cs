using R = Kesoft.Windows.Forms.Common.Properties.Resources;

namespace System.Windows.Forms
{
    /// <summary>
    /// 系统消息框。
    /// </summary>
    public static class MessageBoxHelper
    {
        /// <summary>
        /// 询问消息。
        /// </summary>
        public static bool Question(string format, params object[] args)
        {
            return MessageBox.Show(
                string.Format(format, args),
                R.MBOX_TEXT_QUESTION,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.OK;
        }

        /// <summary>
        /// 通知消息。
        /// </summary>
        public static void Inform(string message, params object[] args)
        {
            MessageBox.Show(
                 string.Format(message, args),
                R.MBOX_TEXT_INFO,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 警告消息。
        /// </summary>
        public static bool Warning(string format, params object[] args)
        {
            return MessageBox.Show(
                 string.Format(format, args),
                R.MBOX_TEXT_WARNING,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1) == DialogResult.OK;
        }


        /// <summary>
        /// 错误消息。
        /// </summary>
        public static void Error(string format, params object[] args)
        {
            MessageBox.Show(
                 string.Format(format, args),
                R.MBOX_TEXT_ERROR,
                MessageBoxButtons.OK,
                MessageBoxIcon.Stop,
                MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 错误消息。
        /// </summary>
        public static void Error(Exception e)
        {
            Error(e.Message);
        }
    }
}