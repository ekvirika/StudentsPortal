using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsPortalDB
{
    public abstract class TableDB<T>
    {
        protected abstract int AutoIncrementId { get; set; }
        protected abstract string TablePath { get; }
        protected static Action<List<T>, string> DBWriter { get; set; }
        protected static Func<string, IEnumerable<T>> DBReader { get; set; }
        public static void InitiliseDelegates(Action<List<T>, string> dbWriter, Func<string, IEnumerable<T>> dbReader)
        {
            DBReader = dbReader;
            DBWriter = dbWriter;
        }

        public abstract void Create(T obj);
        public abstract IEnumerable<T> Read();
        public abstract void Update(T obj);
        public abstract void Delete(T obj);
    }
}
