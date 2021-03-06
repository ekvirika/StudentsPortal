﻿using StudentsPortalDomainDTOs;
using StudentsPortalDomainModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsPortalApplicationServices.Absraction
{
    public interface IStudentsPortalRepositoryLayer
    {
        bool RegisterUser(IAccount account);
        bool SignInAccount(LoginDTO account);
        bool SignOutAccount(IAccount account);

        bool UpdateAccount(IAccount account);
        bool RemoveCurrentAccount(IAccount account);


        IEnumerable<IAccount> GetAllAccounts();
        IAccount FindAccountById(int id);

    }
}
