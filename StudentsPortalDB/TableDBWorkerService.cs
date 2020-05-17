using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsPortalDB
{
    public static class TableDBWorkerService
    {
        //public static void WriteInFile(string userData, string path)
        //{
        //    if (!File.Exists(path))
        //    {
        //        File.Create(path);
        //    }
        //    using (StreamWriter writer = new StreamWriter(path, false))
        //    {
        //        writer.WriteLine(userData);
        //    }
        //}

        //public static string ReadFromFile(string path)
        //{
        //    try
        //    {
        //        var data = string.Empty;
        //        using (StreamReader reader = new StreamReader(path))
        //        {
        //            data = reader.ReadToEnd();
        //        }

        //        return data;
        //    }
        //    catch (Exception ex)
        //    {
        //        return string.Empty;
        //    }
        //}

        public static void WriteInFile<T>(List<T> collection, string path)
        {
            var json = JsonConvert.SerializeObject(collection);

            var fileExists = File.Exists(path);
            if (!fileExists)
            {
                var stream = File.Create(path);
                stream.Dispose();
            }

            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.Write(json);
            }
        }

        public static IEnumerable<T> ReadFromFile<T>(string path)
        {
            try
            {
                var json = string.Empty;
                using (StreamReader reader = new StreamReader(path))
                {
                    json = reader.ReadToEnd();
                }

                var data = JsonConvert.DeserializeObject<List<T>>(json);
                return data;

            }
            catch (Exception ex)
            {
                return new List<T>();
            }
        }
    }
}
