using System;
using System.Windows.Forms;

namespace ExchangeProject.Views.EmployedView
{
    public partial class EmplyedView : Form, IEmployedView
    {
        private string message;

        public EmplyedView()
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
            dgvEmp.DoubleClick += delegate { CopyEvent?.Invoke(this, EventArgs.Empty); };
        }

        public string JobId { get => txtJobId.Text; set => txtJobId.Text = value; }
        public string MemberId { get => txtJoblessId.Text; set => txtJoblessId.Text = value; }
        public string SearchValue { get => txtSearchValue.Text; set => txtSearchValue.Text = value; }
        public string Message { get => message; set => message = value; }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler UpdateEvent;
        public event EventHandler CopyEvent;

        public void SetListBindingSource(BindingSource empList)
        {
            dgvEmp.DataSource = empList;
        }

        private static EmplyedView instance;

        public static EmplyedView GetInstance(Form container)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new EmplyedView();
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

        private void EmplyedView_Load(object sender, EventArgs e)
        {

        }
    }
}
