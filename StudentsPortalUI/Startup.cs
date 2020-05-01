using StudentsPortalApplicationServices.Absraction;
using StudentsPortalApplicationServices.Implementation;
using StudentsPortalDB;
using StudentsPortalDomainModels.Abstraction;
using StudentsPortalDomainModels.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsPortalUI
{
    public class Startup
    {
        public Startup()
        {
            ConfigureServices();
        }

        public void ConfigureServices()
        {
            Services.AddAsSingleton<IStudentsPortalRepositoryLayer>(() => new StudentsPortalRepositoryLayer());
            Services.Add<ICloudinaryService>(() => new CloudinaryService());
        }
    }

}
