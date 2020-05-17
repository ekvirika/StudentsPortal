using StudentsPortalDomainModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsPortalDomainServices.Abstraction
{
    public interface IMailService
    {
        bool SendMail(IMail mailInfo);
    }
}
