using StudentsPortalApplicationServices.Absraction;
using StudentsPortalDomainDTOs;
using StudentsPortalDomainModels.Abstraction;
using StudentsPortalDomainServices.Abstraction;
using StudentsPortalDomainServices.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsPortalApplicationServices.Implementation
{
    public class StudentsPortalRepositoryLayer : IStudentsPortalRepositoryLayer
    {
        private readonly IStudentPortlalService _service;
        public StudentsPortalRepositoryLayer(IStudentPortlalService service)
        {
            _service = service;
        }

        public IAccount FindAccountById(int id)
        {
            return _service.GetAllAccounts().FirstOrDefault(o => o.AccountId == id);

        }

        public IEnumerable<IAccount> GetAllAccounts()
        {
            try
            {
                return _service.GetAllAccounts();
            }
            catch(Exception ex)
            {
                return new List<IAccount>();
            }
        }

        public bool RegisterUser(IAccount account)
        {
            try
            {
                _service.RegisterNewUser(account);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveCurrentAccount(IAccount account)
        {
            try
            {
                _service.DeleteCurrentAccount(account);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool SignInAccount(LoginDTO account)
        {
            try
            {
                var user = _service.SignInUser(account);
                Console.WriteLine();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SignOutAccount(IAccount account)
        {
            try
            {
                _service.SignOutUser();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool UpdateAccount(IAccount account)
        {
            try
            {
                _service.UpdateCurrentAccount(account);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
