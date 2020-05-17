using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
        //Bitmap Image { get; set; }
    }
}
