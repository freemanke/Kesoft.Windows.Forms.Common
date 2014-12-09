using System.Windows.Forms;
using NUnit.Framework;

namespace System.Tests.Windows.Forms
{
    [TestFixture]
    internal class OpenFileDialogHelperTest
    {
        [Test]
        public void OpenTextFileDialog()
        {
            OpenFileDialogHelper.OpenTextFileDialog();
        }

        [Test]
        public void OpenExcelFileDialog()
        {
            OpenFileDialogHelper.OpenExcelFileDialog();
        }

        [Test]
        public void OpenImageFileDialog()
        {
            OpenFileDialogHelper.OpenImageFileDialog();
        }
    }
}