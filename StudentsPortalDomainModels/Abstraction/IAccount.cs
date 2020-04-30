using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsPortalDomainModels.Abstraction
{
    public interface IAccount
    {
        string Password { get; set; }
        string Username { get; set; }
        int AccountId { get; set; }
        IStudent Student { get; set; }
        string ImageUrl { get; set; }
    }
}
