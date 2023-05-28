using System;
using System.Windows.Forms;

namespace ExchangeProject.Views.StudyTypeView
{
    public partial class StudyTypeView : Form, IStudyTypeView
    {
        public StudyTypeView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            btnStudyTypeClose.Click += delegate { this.Close(); };
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            dgvStudyTypes.DoubleClick += delegate { CopyEvent?.Invoke(this, EventArgs.Empty); };
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
        }

        public string StudyTypeID { get => txtStudyTypeId.Text; set => txtStudyTypeId.Text = value; }
        public string StudyTypeName { get => txtStudyTypeName.Text; set => txtStudyTypeName.Text = value; }
        public string SearchValue { get => txtSearchValue.Text; set => txtSearchValue.Text = value; }
        public string Message { get => message; set => message = value; }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler UpdateEvent;
        public event EventHandler CopyEvent;

        public void SetStudyTypeListBindingSource(BindingSource studytypelist)
        {
            dgvStudyTypes.DataSource = studytypelist;
        }

        private static StudyTypeView instance;
        private string message;

        public static StudyTypeView GetInstance(Form container)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new StudyTypeView();
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

        private void StudyTypeView_Load(object sender, EventArgs e)
        {

        }
    }
}
