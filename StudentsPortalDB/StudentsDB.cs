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
        private List<IAccount> _students = default;
        private static TableDB<IAccount> _instance = default;
        private readonly TableDBWorkerService _fileWorker = default;
        public static TableDB<IAccount> Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new StudentsDB();

                return _instance;
            }
        }
        private StudentsDB()
        {
            _students = new List<IAccount>();
            _fileWorker = new TableDBWorkerService();
        }
        protected override int AutoIncrementId { get; set; }

        protected override string TablePath => "Students.json";

        public override void Create(IAccount obj)
        {
            InitialiseStudentsCollection();
            obj.AccountId = AutoIncrementId;
            _students.Add(obj);
            WriteInDB();
            AutoIncrementId++;
        }

        public override List<IAccount> Read()
        {
            var accountsFromFile = _fileWorker.ReadFromFile(TablePath);
            if (accountsFromFile.Length > 0)
            {
                _students = accountsFromFile.ParseList<Account>().ToList<IAccount>();

            }
            return _students;
        }

        public override void Update(IAccount obj)
        {
            InitialiseStudentsCollection();
            var updateElem = _students.FirstOrDefault(o => o.AccountId == obj.AccountId);
            var elemIndex = _students.IndexOf(updateElem);
            _students[elemIndex] = obj;
            WriteInDB();
        }

        public override void Delete(IAccount obj)
        {
            InitialiseStudentsCollection();
            _animals.Remove(obj);
            WriteInDB();
        }



        // CRUD Helper
        public void WriteInDB()
        {
            _fileWorker.WriteInFile(_students.Stringify<List<IAccount>>(), TablePath);
        }
        public void InitialiseStudentsCollection()
        {
            _students = Read();
        }
    }
}
