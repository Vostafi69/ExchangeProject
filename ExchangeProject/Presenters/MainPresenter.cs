using ExchangeProject.Models.UserDTO;
using ExchangeProject.Repositories._ApplicantRepository;
using ExchangeProject.Repositories._CityRepository;
using ExchangeProject.Repositories._DistrictRepository;
using ExchangeProject.Repositories._EmployedRepository;
using ExchangeProject.Repositories._JobGiversRepository;
using ExchangeProject.Repositories._JobsRepository;
using ExchangeProject.Repositories._StudyPlaceRepository;
using ExchangeProject.Repositories._StudyTypeRepository;
using ExchangeProject.Repositories._SystemTablesRepository;
using ExchangeProject.Views;
using ExchangeProject.Views.ApplicantView;
using ExchangeProject.Views.CItyView;
using ExchangeProject.Views.DistrictView;
using ExchangeProject.Views.EmployerView;
using ExchangeProject.Views.JobGiversView;
using ExchangeProject.Views.JobView;
using ExchangeProject.Views.LogInView;
using ExchangeProject.Views.MainView;
using ExchangeProject.Views.StudyPlaceView;
using ExchangeProject.Views.StudyTypeView;
using ExchangeProject.Views.SystemTablesView;
using System;

namespace ExchangeProject.Presenters
{
    public class MainPresenter
    {
        private IMainView mainView;
        private readonly string npgsqlConnectionString;
        private ILogInView loginview;

        public MainPresenter(IMainView mainView, IUser user, ILogInView loginview)
        {
            this.loginview = loginview;
            this.mainView = mainView;
            this.npgsqlConnectionString = user.NpgsqlConnectionString;
            this.mainView.ShowCityView += ShowCityView;
            this.mainView.ShowDistrictView += ShowDistrictView;
            this.mainView.ShowStudyPlaceView += ShowStudyPlaceView;
            this.mainView.ShowStudyTypeView += ShowStudyTypeView;
            this.mainView.ShowApplicantsView += ShowApplicantsView;
            this.mainView.ShowSystemTablesView += ShowSystemTablesView;
            this.mainView.ShowEmployd += ShowEmployedView;
            this.mainView.ChangeUser += ChangeUser;
            this.mainView.ShowJobsGivers += ShowJobGivers;
            this.mainView.ShowJobs += ShowJobs;
            mainView.Load(user.UserRole, user.UserName);
            this.mainView.Show();
        }

        private void ShowJobs(object sender, EventArgs e)
        {
            IJobView view = JobView.GetInstance((MainView)mainView);
            IJobsRepository repository = new JobsRepository(npgsqlConnectionString);
            new JobsPresenter(view, repository);
        }

        private void ShowJobGivers(object sender, EventArgs e)
        {
            IJobGiversView view = JobGiversView.GetInstance((MainView)mainView);
            IJobGiversRepository repository = new JobGiverRepository(npgsqlConnectionString);
            new JobGiversPresenter(view, repository);
        }

        private void ShowEmployedView(object sender, EventArgs e)
        {
            IEmployedView view = EmployedView.GetInstance((MainView)mainView);
            IEmployedRepository repository = new EmployedRepository(npgsqlConnectionString);
            new EmployedPresenter(view, repository);
        }

        private void ChangeUser(object sender, EventArgs e)
        {
            this.mainView.Hide();
            loginview.Show();
        }

        private void ShowSystemTablesView(object sender, EventArgs e)
        {
            ISystemTablesView view = SystemTablesView.GetInstance((MainView)mainView);
            ISystemTablesRepository repository = new SystemTablesRepository(npgsqlConnectionString);
            new SystemTablesPresenter(view, repository);
        }

        private void ShowApplicantsView(object sender, EventArgs e)
        {
            IApplicantView view = ApplicantView.GetInstance((MainView)mainView);
            IApplicantRepository repository = new ApplicantRepository(npgsqlConnectionString);
            new ApplicantPresenter(view, repository);
        }

        private void ShowStudyTypeView(object sender, EventArgs e)
        {
            IStudyTypeView view = StudyTypeView.GetInstance((MainView)mainView);
            IStudyTypeRepository repository = new StudyTypeRepository(npgsqlConnectionString);
            new StudyTypePresenter(view, repository);

        }

        private void ShowStudyPlaceView(object sender, EventArgs e)
        {
            IStudyPlaceView view = StudyPlaceView.GetInstance((MainView)mainView); ;
            IStudyPlaceRepository repository = new StudyPlaceRepository(npgsqlConnectionString);
            new StudyPlacePresenter(view, repository);
        }

        private void ShowDistrictView(object sender, EventArgs e)
        {
            IDistrictView view = DistrictView.GetInstance((MainView)mainView);
            IDistrictRepository repository = new DistrictRepository(npgsqlConnectionString);
            new DistrictPresenter(view, repository);
        }

        private void ShowCityView(object sender, EventArgs e)
        {
            ICityView view = CityView.GetInstance((MainView)mainView);
            ICityRepository repository = new CityRepository(npgsqlConnectionString);
            new CityPresenter(view, repository);
        }
    }
}
