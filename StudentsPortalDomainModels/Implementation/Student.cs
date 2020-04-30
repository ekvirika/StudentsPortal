using StudentsPortalDomainModels.Abstraction;
using StudentsPortalDomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsPortalDomainModels.Implementation
{
    public class Student : IStudent
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public GenderType Gender { get; set ; }
        public string MobilePhone { get; set; }

    }
}
