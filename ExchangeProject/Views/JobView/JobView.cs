using System;
using System.Windows.Forms;

namespace ExchangeProject.Views.JobView
{
    public partial class JobView : Form, IJobView
    {
        private string message;

        public JobView()
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
            dgvJob.DoubleClick += delegate { CopyEvent?.Invoke(this, EventArgs.Empty); };
        }

        public string JobId { get => txtJobId.Text; set => txtJobId.Text = value; }
        public string JobGiverId { get => txtJobGiverId.Text; set => txtJobGiverId.Text = value; }
        public string JobName { get => txtJobName.Text; set => txtJobName.Text = value; }
        public string Money { get => txtMoney.Text; set => txtMoney.Text = value; }
        public string More { get => txtMore.Text; set => txtMore.Text = value; }
        public string Available { get => cbAvailable.Checked.ToString(); set => cbAvailable.Checked = Convert.ToBoolean(value); }
        public string JobType { get => txtType.Text; set => txtType.Text = value; }
        public string SearchValue { get => txtSearchValue.Text; set => txtSearchValue.Text = value; }
        public string Message { get => message; set => message = value; }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler UpdateEvent;
        public event EventHandler CopyEvent;

        public void SetListBindingSource(BindingSource jobsList)
        {
            dgvJob.DataSource = jobsList;
        }

        private static JobView instance;
        public static JobView GetInstance(Form container)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new JobView();
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

        private void JobView_Load(object sender, EventArgs e)
        {

        }
    }
}
