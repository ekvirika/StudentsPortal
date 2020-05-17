using StudentsPortalApplicationServices.Absraction;
using StudentsPortalApplicationServices.Implementation;
using StudentsPortalDomainModels.Abstraction;
using StudentsPortalDomainModels.Enums;
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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
            _allGenderRadionButtons = Gender.Controls.OfType<RadioButton>().ToList();
            _allDegreeRadionButtons = Degree.Controls.OfType<RadioButton>().ToList();
            _allInputs = this.Controls.OfType<TextBox>().ToList();
        }

        private List<RadioButton> _allGenderRadionButtons = default;
        private List<RadioButton> _allDegreeRadionButtons = default;
        private List<TextBox> _allInputs = default;

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            IAccount tmp = new Account
            {
                Password = PasswordInp.Text,
                Username = UsernameInp.Text,
                Student = new Student()
                {
                    MobilePhone = PhoneInp.Text,
                    Name = NameInp.Text,
                    Surname = SurnameInp.Text,
                    Age = Convert.ToInt32(AgeInp.Text),                    
                    Email = EmailInp.Text,
                    UniversityName = UniInp.Text,
                    Gender = (GenderType)Convert.ToInt32(_allGenderRadionButtons.FirstOrDefault(o => o.Checked).TabIndex),
                    Degree = (DegreeType)Convert.ToInt32(_allDegreeRadionButtons.FirstOrDefault(o => o.Checked).TabIndex),
                },
            };

            var registered = Services.Get<IStudentsPortalRepositoryLayer>().RegisterUser(tmp);
            if (registered)
            {
                MessageBox.Show($"User {UsernameInp.Text} {SurnameInp.Text} successfully registered!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                Authorisation authorisation = new Authorisation();
                authorisation.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show($"User {UsernameInp.Text} {SurnameInp.Text} coudn't be registered.!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void ClearInputs()
        {
            _allInputs.ForEach(o => o.Text = string.Empty);
            _allGenderRadionButtons.ForEach(o => o.Checked = false);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
