using System.Windows.Forms;
using Kesoft.Common.Tests.Windows.Forms;

namespace Kesoft.Windows.Forms.Common.Tests
{
    public class Program
    {
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormCustomToolStripStatusLabel());
        }
    }
}
