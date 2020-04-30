using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsPortalDB
{
    public class TableDBWorkerService
    {
        public void WriteInFile(string userData, string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine(userData);
            }
        }

        public string ReadFromFile(string path)
        {
            try
            {
                var data = string.Empty;
                using (StreamReader reader = new StreamReader(path))
                {
                    data = reader.ReadToEnd();
                }

                return data;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
