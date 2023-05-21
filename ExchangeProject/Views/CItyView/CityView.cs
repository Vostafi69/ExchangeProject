using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExchangeProject.Views.CItyView
{
    public partial class CityView : Form, ICityView
    {
        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler UpdateEvent;
        public event EventHandler CopyEvent;

        public string CityId { get => txtCityId.Text; set => txtCityId.Text = value; }
        public string CityName { get => txtCityName.Text; set => txtCityName.Text = value; }
        public string SearchValue { get => txtSearchValue.Text; set => txtSearchValue.Text = value; }
        public string Message { get => message; set => message = value; }

        private string message;

        public CityView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            btnCityClose.Click += delegate { this.Close(); };
            dgvCities.DoubleClick += delegate { CopyEvent?.Invoke(this, EventArgs.Empty); };
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
            btnCityUpdate.Click += delegate {
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

        public void SetCityListBindingSource(BindingSource cityList)
        {
            dgvCities.DataSource = cityList;
        }

        private static CityView instance;
        public static CityView GetInstance(Form container)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new CityView();
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

        private void CityView_Load(object sender, EventArgs e)
        {

        }
    }
}
