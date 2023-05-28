using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExchangeProject.Views.MainView
{
    public interface IMainView
    {
        event EventHandler ShowCityView;
        event EventHandler ShowDistrictView;
        event EventHandler ShowStudyTypeView;
        event EventHandler ShowStudyPlaceView;
        event EventHandler ShowApplicantsView;
        event EventHandler ShowSystemTablesView;
        event EventHandler ChangeUser;
        event EventHandler ShowRegistration;
        event EventHandler ShowJobs;
        event EventHandler ShowJobsGivers;
        event EventHandler ShowWorkers;
        event EventHandler ShowArchive;

        void Show();
        void Hide();
        void Load(string userRole, string userName);
    }
}
