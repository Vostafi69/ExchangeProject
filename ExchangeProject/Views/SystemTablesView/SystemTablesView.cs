using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExchangeProject.Views.SystemTablesView
{
    public partial class SystemTablesView : Form, ISystemTablesView
    {
        public SystemTablesView()
        {
            InitializeComponent();
            btnSysTablesClose.Click += delegate { this.Close(); };
        }

        public void SetSystemListBindingSource(List<BindingSource> systemlist)
        {
            dgvPgAm.DataSource = systemlist[0];
            dgvPgCast.DataSource = systemlist[1];
            dgvShdepend.DataSource = systemlist[2];
        }

        private void SystemTablesView_Load(object sender, EventArgs e)
        {

        }

        private static SystemTablesView instance;
        public static SystemTablesView GetInstance(Form container)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new SystemTablesView();
                instance.MdiParent = container;
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }

    }
}
