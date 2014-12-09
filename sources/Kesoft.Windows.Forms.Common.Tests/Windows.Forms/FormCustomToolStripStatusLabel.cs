using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kesoft.Common.Windows.Forms;

namespace Kesoft.Common.Tests.Windows.Forms
{
    public partial class FormCustomToolStripStatusLabel : Form
    {
        public FormCustomToolStripStatusLabel()
        {
            InitializeComponent();

            btnError.Click += (a, b) => customToolStripStatusLabel1.SetFailureText("Failure");
            btnOk.Click += (a, b) => customToolStripStatusLabel1.SetSuccessText("Success");
            btnLoading.Click += (a, b) => customToolStripStatusLabel1.SetLoadingText("Loading...");
        }
    }
}