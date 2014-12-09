using System.Windows.Forms;
using NUnit.Framework;

namespace System.Tests.Windows.Forms
{
    [TestFixture]
    internal class SaveFileDialogHelperTest
    {
        [Test]
        public void ShowSaveTextFileDialog()
        {
            SaveFileDialogHelper.OpenSaveTextFileDialog();
        }

        [Test]
        public void ShowSaveExcelFileDialog()
        {
            SaveFileDialogHelper.OpenSaveExcelFileDialog();
        }

        [Test]
        public void ShowSaveImageFileDialog()
        {
            SaveFileDialogHelper.OpenSaveImageFileDialog();
        }
    }
}