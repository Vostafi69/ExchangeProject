using ExchangeProject.Models.SysTables;
using ExchangeProject.Repositories._SystemTablesRepository;
using ExchangeProject.Views.SystemTablesView;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExchangeProject.Presenters
{
    public class SystemTablesPresenter
    {
        private ISystemTablesView view;
        private ISystemTablesRepository repository;
        private IEnumerable<IPg_Cast> pgCastList;
        private IEnumerable<IPg_Am> pgAmList;
        private IEnumerable<IPg_Shdepend> pgShList;
        private List<BindingSource> systemBindingSource;

        public SystemTablesPresenter(ISystemTablesView view, ISystemTablesRepository repository)
        {
            systemBindingSource = new List<BindingSource> { 
                new BindingSource(),
                new BindingSource(), 
                new BindingSource() 
            };
            this.view = view;
            this.repository = repository;
            this.view.SetSystemListBindingSource(systemBindingSource);
            LoadAllCityList();
            this.view.Show();
        }
        private void LoadAllCityList()
        {
            pgCastList = repository.GetAllPgCast();
            pgAmList = repository.GetAllPgAm();
            pgShList = repository.GetAllPgShdepend();
            systemBindingSource[0].DataSource = pgCastList;
            systemBindingSource[1].DataSource = pgAmList;
            systemBindingSource[2].DataSource = pgShList;
        }
    }
}
