using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExchangeProject.Views.JobGiversView
{
    public partial class JobGiversView : Form, IJobGiversView
    {
        public JobGiversView()
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
            dgvJobGivers.DoubleClick += delegate { CopyEvent?.Invoke(this, EventArgs.Empty); };
        }

        public string JobGiverId { get => txtJobGiverId.Text; set => txtJobGiverId.Text = value; }
        public string JobGiver { get => txtJobGiver.Text; set => txtJobGiver.Text = value; }
        public string CityId { get => txtCity.Text; set => txtCity.Text = value; }
        public string DistrictId { get => txtDistrict.Text; set => txtDistrict.Text = value; }
        public string Mobile { get => txtMobile.Text; set => txtMobile.Text = value; }
        public string SearchValue { get => txtSearchValue.Text; set => txtSearchValue.Text = value; }
        public string Message { get => message; set => message = value; }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler UpdateEvent;
        public event EventHandler CopyEvent;

        public void SetListBindingSource(BindingSource jobGiversList)
        {
            dgvJobGivers.DataSource = jobGiversList;
        }

        private static JobGiversView instance;
        private string message;

        public static JobGiversView GetInstance(Form container)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new JobGiversView();
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

        private void JobGivers_Load(object sender, EventArgs e)
        {

        }
    }
}
