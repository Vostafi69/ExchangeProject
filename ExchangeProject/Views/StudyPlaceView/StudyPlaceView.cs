using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExchangeProject.Views.StudyPlaceView
{
    public partial class StudyPlaceView : Form, IStudyPlaceView
    {
        public StudyPlaceView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            btnStudyPlaceClose.Click += delegate { this.Close(); };
        }

        public string StudyId { get => txtStudyPlaceId.Text; set => txtStudyPlaceId.Text = value; }
        public string StudyPlace { get => txtStudyPlaceName.Text; set => txtStudyPlaceName.Text = value; }
        public string CityId { get => txtStudyPlaceCityId.Text; set => txtStudyPlaceCityId.Text = value; }
        public string DistrictId { get => txtStudyPlaceDistrictId.Text; set => txtStudyPlaceDistrictId.Text = value; }
        public string SearchValue { get => txtSearchValue.Text; set => txtSearchValue.Text = value; }
        public string Message { get => message; set => message = value; }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler UpdateEvent;
        public event EventHandler CopyEvent;

        public void SetStudyPlaceListBindingSource(BindingSource styduPlacesList)
        {
            dgvStudyPlace.DataSource = styduPlacesList;
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            dgvStudyPlace.DoubleClick += delegate { CopyEvent?.Invoke(this, EventArgs.Empty); };
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

        private static StudyPlaceView instance;
        private string message;

        public static StudyPlaceView GetInstance(Form container)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new StudyPlaceView();
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

        private void StudyPlaceView_Load(object sender, EventArgs e)
        {

        }
    }
}
