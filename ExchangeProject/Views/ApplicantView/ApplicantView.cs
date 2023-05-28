using System;
using System.Windows.Forms;

namespace ExchangeProject.Views.ApplicantView
{
    public partial class ApplicantView : Form, IApplicantView
    {
        public ApplicantView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            btnClose.Click += delegate { this.Close(); };
            dgvApplicants.DoubleClick += delegate { CopyEvent?.Invoke(this, EventArgs.Empty); };
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
        }

        public string ApplicantName { get => txtApplicantName.Text; set => txtApplicantName.Text = value; }
        public string JoblessId { get => txtApplicantId.Text; set => txtApplicantId.Text = value; }
        public string Lastname { get => txtApplicantLastname.Text; set => txtApplicantLastname.Text = value; }
        public string Surname { get => txtApplicantSurname.Text; set => txtApplicantSurname.Text = value; }
        public string StudyTypeID { get => txtApplicantStudyType.Text; set => txtApplicantStudyType.Text = value; }
        public string CityId { get => txtApplicantCity.Text; set => txtApplicantCity.Text = value; }
        public string DistrictId { get => txtApplicantDistrict.Text; set => txtApplicantDistrict.Text = value; }
        public string StudyPlace { get => txtStudy.Text; set => txtStudy.Text = value; }
        public string Age { get => txtAge.Text; set => txtAge.Text = value; }
        public string Passport { get => txtPassport.Text; set => txtPassport.Text = value; }
        public string PassportDate { get => txtDate.Text; set => txtDate.Text = value; }
        public string PassportRegion { get => txtRegion.Text; set => txtRegion.Text = value; }
        public string Phone { get => txtPhone.Text; set => txtPhone.Text = value; }
        public string Deleted { get => txtDelete.Checked.ToString(); set => txtDelete.Checked = Convert.ToBoolean(value); }
        public string Message { get => message; set => message = value; }
        public string SearchValue { get => txtSearchValue.Text; set => txtSearchValue.Text = value; }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler UpdateEvent;
        public event EventHandler CopyEvent;

        public void SetCityListBindingSource(BindingSource applicantsList)
        {
            dgvApplicants.DataSource = applicantsList;
        }

        private static ApplicantView instance;
        private string message;

        public static ApplicantView GetInstance(Form container)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ApplicantView();
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

        private void ApplicantView_Load(object sender, EventArgs e)
        {

        }
    }
}
