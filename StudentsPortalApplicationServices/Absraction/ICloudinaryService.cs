using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsPortalApplicationServices.Absraction
{
    public interface ICloudinaryService
    {
        Image SelectImage();
        void UploadImage();
    }

}
