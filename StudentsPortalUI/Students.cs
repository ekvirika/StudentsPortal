using StudentsPortalApplicationServices.Absraction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsPortalUI
{
    public partial class Students : Form
    {
        public Students()
        {
            InitializeComponent();
            InitialiseAnimalView();
        }

        private void StudentsView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InitialiseAnimalView()
        {
            StudentsView.DataSource = Services.Get<IStudentsPortalRepositoryLayer>().GetAllAccounts().ToList();
        }
    }
}
