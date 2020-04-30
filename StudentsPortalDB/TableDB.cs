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

        public abstract void Create(T obj);
        public abstract List<T> Read();
        public abstract void Update(T obj);
        public abstract void Delete(T obj);
    }
}
