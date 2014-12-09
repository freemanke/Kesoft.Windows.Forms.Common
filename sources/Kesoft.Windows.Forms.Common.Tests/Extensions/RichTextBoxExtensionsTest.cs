using System.Windows.Forms;
using NUnit.Framework;

namespace Kesoft.Common.Tests.Extensions
{
    [TestFixture]
    public class RichTextBoxExtensionsTest
    {
        [Test]
        public void AppendLine()
        {
            var tbx = new RichTextBox();

            tbx.AppendLine("a");
            Assert.AreEqual(1, tbx.Lines.Length);

            tbx.AppendLine("b");
            Assert.AreEqual(2, tbx.Lines.Length);

            tbx.AppendLine("{0}", 1);
            Assert.AreEqual(3, tbx.Lines.Length);
        }
    }
}