using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsPortalDB
{
    public class DBWorkerService<T>
    {
        private TableDB<T> _tableDB = default;
        public DBWorkerService(TableDB<T> instance) { _tableDB = instance; }

        public bool Create(T obj)
        {
            try
            {
                _tableDB.Create(obj);
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public List<T> Read()
        {
            return _tableDB.Read();
        }

        public bool Update(T obj)
        {
            try
            {
                _tableDB.Update(obj);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(T obj)
        {
            try
            {
                _tableDB.Delete(obj);
                return true;
            }
            catch (Exception ex) { return false; }
        }
    }
}
