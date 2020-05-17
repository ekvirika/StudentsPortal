using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using StudentsPortalApplicationServices.Absraction;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsPortalApplicationServices.Implementation
{
    public class CloudinaryService : ICloudinaryService
    {
        private string _path = default;
        private readonly Cloudinary cloud = new Cloudinary(
            new Account(
                "dqfgluj1j",
                "323632319256927",
                "yRO404B2C0LDTVGKr5Yzza5zFhU")
            );


        public Image SelectImage()
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                _path = open.FileName;
                Image img = new Bitmap(_path);
                return img;
            }

            return default;
        }

        public void UploadImage()
        {
            var imageUpload = new ImageUploadParams()
            {
                File = new FileDescription(_path),
                PublicId = _path.Split('\\').LastOrDefault()
            };

            cloud.Upload(imageUpload);
        }

        //public Image GetImage()
        //{

        //}
    }
}
