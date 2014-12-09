using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Kesoft.Windows.Forms.Common.Properties;

namespace Kesoft.Common.Windows.Forms
{
    public partial class CustomToolStripStatusLabel : ToolStripStatusLabel
    {
        public CustomToolStripStatusLabel()
        {
            InitializeComponent();

            base.Image = Resources.Success;
            base.Text = @"Ready.";
            ImageAlign = ContentAlignment.MiddleLeft;
            base.TextAlign = ContentAlignment.MiddleLeft;
            Spring = true;
        }

        public CustomToolStripStatusLabel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            base.Image = Resources.Success;
            base.Text = @"Ready";
        }

        /// <summary>
        /// 设置成功消息。
        /// </summary>
        public void SetSuccessText(string format, params object[] args)
        {
            SetText(TextType.Success, format, args);
        }

        /// <summary>
        /// 设置失败消息。
        /// </summary>
        public void SetFailureText(string format, params object[] args)
        {
            SetText(TextType.Failure, format, args);
        }

        /// <summary>
        /// 设置加载消息。
        /// </summary>
        public void SetLoadingText(string format, params object[] args)
        {
            SetText(TextType.Loading, format, args);
        }

        /// <summary>
        /// 设置消息。
        /// </summary>
        /// <param name="type">消息类型。</param>
        /// <param name="format">格式。</param>
        /// <param name="args">参数。</param>
        private void SetText(TextType type, string format, params object[] args)
        {
            switch (type)
            {
                case TextType.Failure:
                    base.Image = Resources.Failure;
                    base.Text = string.Format(format, args);
                    break;
                case TextType.Loading:
                    base.Image = Resources.Loading;
                    base.Text = string.Format(format, args);
                    break;
                case TextType.Success:
                    base.Image = Resources.Success;
                    base.Text = string.Format(format, args);
                    break;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Image Image
        {
            get { return base.Image; }
        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string Text
        {
            get { return base.Text; }
        }
    }

    public enum TextType
    {
        Success,
        Failure,
        Loading,
    }
}