using StudentsPortalDomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsPortalDomainModels.Abstraction
{
    public interface IStudent
    {
        string Name { get; set; }
        string Surname { get; set; }
        int Age { get; set; }
        string Email { get; set; }
        GenderType Gender { get; set; }
        string MobilePhone { get; set; }
        string UniversityName { get; set; }
        DegreeType Degree { get; set; }
    }
}
