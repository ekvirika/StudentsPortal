using StudentsPortalApplicationServices.Absraction;
using StudentsPortalApplicationServices.Implementation;
using StudentsPortalDomainDTOs;
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
    public partial class Authorisation : Form
    {
        public Authorisation()
        {
            InitializeComponent();
        }
        private void SignInBtn_Click(object sender, EventArgs e)
        {
            //var exists = Services.Get<IStudentsPortalRepositoryLayer>().SignInAccount(new LoginDTO()
            //{
            //    Email = Email.Text,
            //    Password = Password.Text
            //});
            var _service = new StudentsPortalRepositoryLayer();
            var user = _service.SignInAccount(new LoginDTO() { Email = Email.Text, Password = Password.Text });

            if(user == true)
            {
                MessageBox.Show("Success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form mainView = new StudentsPortalView();
                mainView.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ooooppsss.. Something went wrong. Try again!");
            }
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            Form registerForm = new Registration();
            registerForm.Show();
            this.Hide();
        }
    }
}
