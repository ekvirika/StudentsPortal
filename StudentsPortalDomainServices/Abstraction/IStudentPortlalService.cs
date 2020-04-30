using StudentsPortalDomainDTOs;
using StudentsPortalDomainModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsPortalDomainServices.Abstraction
{
    public interface IStudentPortlalService
    {
        bool RegisterNewUser(IAccount user);
        IAccount SignInUser(LoginDTO user);
        IAccount SearchAccount(string userName);
        void SignOutUser();

    }
}
