using System;
using System.Windows.Forms;

namespace ExchangeProject.Views.MainView
{
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
            btnShowCity.Click += delegate { ShowCityView?.Invoke(this, EventArgs.Empty); };
            btnShowDistricts.Click += delegate { ShowDistrictView?.Invoke(this, EventArgs.Empty); };
            btnStudyPlace.Click += delegate { ShowStudyPlaceView?.Invoke(this, EventArgs.Empty); };
            btnStudyType.Click += delegate { ShowStudyTypeView?.Invoke(this, EventArgs.Empty); };
            btnApplicants.Click += delegate { ShowApplicantsView?.Invoke(this, EventArgs.Empty); };
            btnSysTb.Click += delegate { ShowSystemTablesView?.Invoke(this, EventArgs.Empty); };
            btnChangeUser.Click += delegate {
                var result = MessageBox.Show("Несохраненные данные могут быть утеряны",
                    "Выйти?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question
                );
                if (result == DialogResult.Yes)
                {
                    ChangeUser?.Invoke(this, EventArgs.Empty);
                }
            };
            btnRegistration.Click += delegate { ShowRegistration?.Invoke(this, EventArgs.Empty); };
            btnJobs.Click += delegate { ShowJobs?.Invoke(this, EventArgs.Empty); };
            btnJobGivers.Click += delegate { ShowJobsGivers?.Invoke(this, EventArgs.Empty); };
            btnWorkers.Click += delegate { ShowWorkers?.Invoke(this, EventArgs.Empty); };
            btnArchive.Click += delegate { ShowArchive?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler ShowCityView;
        public event EventHandler ShowDistrictView;
        public event EventHandler ShowStudyTypeView;
        public event EventHandler ShowStudyPlaceView;
        public event EventHandler ShowApplicantsView;
        public event EventHandler ShowSystemTablesView;
        public event EventHandler ChangeUser;
        public event EventHandler ShowRegistration;
        public event EventHandler ShowJobs;
        public event EventHandler ShowJobsGivers;
        public event EventHandler ShowWorkers;
        public event EventHandler ShowArchive;

        protected override void OnClosed(EventArgs e)
        {
            Application.Exit();
        }

        void IMainView.Load(string userRole, string userName)
        {
            if (userRole != "birzha_admin")
                tabPage3.Parent = null;
            txtUser.Text = txtUser.Text + " " + userName;
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            
        }
    }
}
