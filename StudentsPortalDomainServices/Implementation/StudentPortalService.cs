using StudentsPortalDB;
using StudentsPortalDomainDTOs;
using StudentsPortalDomainModels.Abstraction;
using StudentsPortalDomainServices.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StudentsPortalDomainServices.Implementation
{
    public class StudentPortalService : IStudentPortlalService
    {

        public readonly DBWorkerService<IAccount> _accountsDB = default;
        public StudentPortalService()
        {
            _accountsDB = new DBWorkerService<IAccount>(StudentsDB.Instance);
        }

        public bool RegisterNewUser(IAccount user)
        {
            return _accountsDB.Create(user);
        }


        public IAccount SignInUser(LoginDTO user)
        {
            var searchedUser = GetAllAccounts()
              ?.FirstOrDefault(o =>
              o.Student.Email == user.Email || 
              o.Password == user.Password);

            if (searchedUser != null)
            {
                LoginHelperService.LoginUser(searchedUser);
            }
            return searchedUser;
        }

        public void SignOutUser()
        {
            LoginHelperService.LogOutUser();
        }


        public void DeleteCurrentAccount(IAccount user)
        {
            _accountsDB.Delete(user);
        }

        public IEnumerable<IAccount> GetAllAccounts()
        {
            return _accountsDB?.Read();
        }

        public void UpdateCurrentAccount(IAccount user)
        {
            _accountsDB.Update(user);
        }

        //public IAccount SearchAccount(string userName)
        //{
        //    var user = _accountsDB
        //       .Read()
        //       .FirstOrDefault(o => o.Username.ToLower() == userName.ToLower());
        //    return user;
        //}
    }
}
