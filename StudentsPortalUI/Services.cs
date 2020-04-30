using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsPortalUI
{
    public static class Services
    {
        private static readonly Dictionary<Type, Func<object>> _servicesCollection
           = new Dictionary<Type, Func<object>>();

        private static readonly Dictionary<Type, object> _singleServicesCollection
           = new Dictionary<Type, object>();

        public static void Add<Type>(Func<object> func)
        {
            _servicesCollection[typeof(Type)] = func;
        }

        public static void AddAsSingleton<Type>(Func<object> func)
        {
            _singleServicesCollection[typeof(Type)] = func?.Invoke();
        }


        public static T Get<T>()
        {
            try
            {
                var exists = _servicesCollection.ContainsKey(typeof(T));
                return exists ?
                    (T)_servicesCollection[typeof(T)].Invoke() : (T)_singleServicesCollection[typeof(T)];
            }
            catch (Exception ex)
            {
                return default;
            }
        }
    }
}
