using StudentsPortalApplicationServices.Absraction;
using StudentsPortalApplicationServices.Implementation;
using StudentsPortalDB;
using StudentsPortalDomainDTOs;
using StudentsPortalDomainModels.Abstraction;
using StudentsPortalDomainModels.Implementation;
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
            var startup = new Startup();
            InitializeComponent();
            StudentsDB.InitiliseDelegates(TableDBWorkerService.WriteInFile, TableDBWorkerService.ReadFromFile<Account>);
        }
        private void SignInBtn_Click(object sender, EventArgs e)
        {

            
            var user = Services.Get<IStudentsPortalRepositoryLayer>()
                .SignInAccount(new LoginDTO() 
                { 
                    Email = Email.Text, 
                    Password = Password.Text 
                });


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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
