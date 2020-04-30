using StudentsPortalApplicationServices.Absraction;
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
            _service = new 
        }
        private readonly IStudentsPortalRepositoryLayer _service;
        private void SignInBtn_Click(object sender, EventArgs e)
        {
            var user = _service.SignInUser(new LoginDTO()
            {
                Email = Email.Text,
                Password = Password.Text
            });
        }
    }
}
