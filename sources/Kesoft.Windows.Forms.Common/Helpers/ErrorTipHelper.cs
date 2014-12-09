using System.Drawing;

namespace System.Windows.Forms
{
    /// <summary>
    /// 错误提示类。
    /// </summary>
    /// <remarks>
    /// 该类将错误消息通过提示工具条显示到控件下方。
    /// </remarks>
    public static class ErrorTipHelper
    {
        private static readonly ToolTip Instance = new ToolTip();

        /// <summary>
        /// 构造方法。
        /// </summary>
        static ErrorTipHelper()
        {
            Instance.AutomaticDelay = 200;
            Instance.AutoPopDelay = 2000;
            Instance.ToolTipIcon = ToolTipIcon.Error;
            Instance.ToolTipTitle = "Error message";
        }

        /// <summary>
        /// 设置错误到控件，
        /// 默认情况下，提示框2秒后自动消失。
        /// </summary>
        /// <param name="control">控件。</param>
        /// <param name="message">错误消息。</param>
        public static void Set(Control control, string message)
        {
            Set(control, message, 2000);
        }

        /// <summary>
        ///  设置错误到控件，
        /// </summary>
        /// <param name="control">控件。</param>
        /// <param name="message">消息。</param>
        /// <param name="duration">持续时间，单位：毫秒。</param>
        public static void Set(Control control, string message, int duration)
        {
            if (control == null) return;

            Instance.Show(message, control, new Point(0, control.Height + 2), duration);
            control.Focus();
        }
    }
}