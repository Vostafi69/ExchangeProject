using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExchangeProject.Views.MainView
{
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
            btnShowCity.Click += delegate { ShowCityView?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler ShowCityView;
        protected override void OnClosed(EventArgs e)
        {
            Application.Exit();
        }

        private void MainView_Load(object sender, EventArgs e)
        {

        }
    }
}
