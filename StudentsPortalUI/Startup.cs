using StudentsPortalApplicationServices.Absraction;
using StudentsPortalApplicationServices.Implementation;
using StudentsPortalDB;
using StudentsPortalDomainModels.Abstraction;
using StudentsPortalDomainModels.Implementation;
using StudentsPortalDomainServices.Abstraction;
using StudentsPortalDomainServices.Implementation;
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
            StudentsDB.InitiliseDelegates(TableDBWorkerService.WriteInFile, TableDBWorkerService.ReadFromFile<Account>);
        }

        public void ConfigureServices()
        {
            Services.AddAsSingleton<IStudentPortlalService>(() => new StudentPortalService());
            Services.AddAsSingleton<IStudentsPortalRepositoryLayer>(() => new StudentsPortalRepositoryLayer(Services.Get<IStudentPortlalService>()));
            Services.Add<ICloudinaryService>(() => new CloudinaryService());
        }
    }

}
