using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExchangeProject.Views.LogInView
{
    public partial class LogInView : Form, ILogInView
    {
        public event EventHandler EventLogIn;

        public string UserLogin { get => txtUserLogin.Text; set => txtUserLogin.Text = value; }
        public string UserPassword { get => txtUserPassword.Text; set => txtUserPassword.Text = value; }
        
        public LogInView()
        {
            InitializeComponent();
            btnLogIn.Click += delegate { EventLogIn?.Invoke(this, EventArgs.Empty); };
        }

        private void LogInView_Load(object sender, EventArgs e)
        {

        }
    }
}
