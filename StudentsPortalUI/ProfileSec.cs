using StudentsPortalDomainServices.Implementation;
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
    public partial class ProfileSec : Form
    {
        public ProfileSec()
        {
            InitializeComponent();
        }

        private void ProfileSec_Load(object sender, EventArgs e)
        {
            var user = LoginHelperService.GetCurrentUser();
            if (user != null)
            {

                Nameuser.Text = $"{user.Student.Name} {user.Student.Surname}";
                Username.Text = user.Username;
                Email.Text = user.Student.Email;
                Age.Text = $"{user.Student.Age.ToString()} Years Old";
                PhoneNum.Text = user.Student.MobilePhone;
                Degree.Text = user.Student.Degree.ToString();
            }
        }
    }
}
