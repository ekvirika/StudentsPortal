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
    public partial class StudentsPortalView : Form
    {
        public StudentsPortalView()
        {
            InitializeComponent();
            profileSec = new ProfileSec() {TopLevel = false };
            studentsSec = new Students() {TopLevel = false };
            settingsSec = new Settings() {TopLevel = false };
            messagesSec = new Messages() {TopLevel = false };

            ProfileSectionShow();
        }

        private readonly Form profileSec = default;
        private readonly Form studentsSec = default;
        private readonly Form settingsSec = default;
        private readonly Form messagesSec = default;
        public void ProfileSectionShow()
        {
            ShowNewForm(profileSec);
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoginHelperService.LogOutUser();
            var result = MessageBox.Show("Do you want to log out?", "Logging out", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Authorisation auth = new Authorisation();
                this.Hide();
                auth.Show();
            }
        }

        public void ShowNewForm(Form form)
        {
            MainPanel.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.BringToFront();
            form.Show();
        }

        private void ContactsSec_Click(object sender, EventArgs e)
        {
            ShowNewForm(studentsSec);
        }

        private void MessagesSec_Click(object sender, EventArgs e)
        {
            ShowNewForm(messagesSec);
        }

        private void SettingsSec_Click(object sender, EventArgs e)
        {
            ShowNewForm(settingsSec);
        }
    }
}
