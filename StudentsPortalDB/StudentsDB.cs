using StudentsPortalDomainModels.Abstraction;
using StudentsPortalDomainModels.Implementation;
using StudentsPortalExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsPortalDB
{
    public class StudentsDB : TableDB<IAccount>
    {
        private StudentsDB()
        {
            _students = DBReader?.Invoke(TablePath).ToList<IAccount>();
            //AutoIncrementId = _students.Count();
        }

        public List<IAccount> _students = default;
        private static TableDB<IAccount> _instance = default;
        public static TableDB<IAccount> Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new StudentsDB();

                return _instance;
            }
        }
 

        protected override int AutoIncrementId { get; set; }

        protected override string TablePath => "Students.json";

        public override void Create(IAccount obj)
        {           
            //var userExistence = _students
            //        .FirstOrDefault(o => o.Username == obj.Username || o.Student.Email == obj.Student.Email);
            //if (userExistence != null)
            //{
            //    throw new Exception();
            //}

            obj.AccountId = AutoIncrementId;
            _students.Add(obj);
            WriteInDB();
            AutoIncrementId++;
        }

        public override IEnumerable<IAccount> Read()
        {
            return _students;
        }

        public override void Update(IAccount obj)
        {
            var updateElem = _students.FirstOrDefault(o => o.AccountId == obj.AccountId);
            var elemIndex = _students.IndexOf(updateElem);
            _students[elemIndex] = obj;
            WriteInDB();
        }

        public override void Delete(IAccount obj)
        {
            _students.Remove(obj);
            WriteInDB();
        }



        // CRUD Helper
        public void WriteInDB()
        {
            //TableDBWorkerService.WriteInFile(_students.Stringify<List<IAccount>>(), TablePath);
            //TableDBWorkerService.WriteInFile(_students, TablePath);
            DBWriter?.Invoke(_students, TablePath);
        }
    }
}
