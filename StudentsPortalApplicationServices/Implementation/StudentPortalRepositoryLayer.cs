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
    public class StudentPortalRepositoryLayer : IStudentsPortalRepositoryLayer
    {
        private readonly IStudentPortlalService _service;
        public StudentPortalRepositoryLayer()
        {
            _service = new StudentPortalService();
        }

        public IAccount FindAccountById(int id)
        {
            return _service.GetAllAnimals().FirstOrDefault(o => o.Id == id);

        }

        public List<IAccount> GetAllAccounts()
        {

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
            
        }

        public bool SignInAccount(LoginDTO account)
        {
            try
            {
                _service.SignInUser(account);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateAccount(IAccount account)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
