using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExchangeProject.Views.RegistrationView
{
    public partial class RegistrationView : Form, IRegistrationView
    {
        public RegistrationView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            txtSearchValue.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            btnAddNew.Click += delegate {
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                MessageBox.Show(Message);
            };
            btnUpdate.Click += delegate {
                UpdateEvent?.Invoke(this, EventArgs.Empty);
                MessageBox.Show(Message);
            };
            btnDelete.Click += delegate {
                var result = MessageBox.Show("Удалить выбранную запись?",
                    "Осторожно",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning
                );
                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };
            btnClose.Click += delegate { this.Close(); };
            dgvReg.DoubleClick += delegate { CopyEvent?.Invoke(this, EventArgs.Empty); };
        }

        public string MemberId { get => txtMemberID.Text; set => txtMemberID.Text = value; }
        public string JoblessId { get => txtJoblessId.Text; set => txtJoblessId.Text = value; }
        public string Registrar { get => txtRegistrar.Text; set => txtRegistrar.Text = value; }
        public string RegDate { get => txtRegDate.Text; set => txtRegDate.Text = value; }
        public string Payment { get => txtPayment.Text; set => txtPayment.Text = value; }
        public string Experience { get => cbExperience.Checked.ToString(); set => cbExperience.Checked = Convert.ToBoolean(value); }
        public string Comment { get => txtComment.Text; set => txtComment.Text = value; }
        public string SearchValue { get => txtSearchValue.Text; set => txtSearchValue.Text = value; }
        public string Message { get => message; set => message = value; }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler UpdateEvent;
        public event EventHandler CopyEvent;

        public void SetListBindingSource(BindingSource regList)
        {
            dgvReg.DataSource = regList;
        }

        private static RegistrationView instance;
        private string message;

        public static RegistrationView GetInstance(Form container)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new RegistrationView();
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

        private void RegistrationView_Load(object sender, EventArgs e)
        {

        }
    }
}
