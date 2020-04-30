using Newtonsoft.Json;
using StudentsPortalDomainModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsPortalDomainModels.Implementation
{
    public class Account : IAccount
    {
        public Account()
        {
            AccountId = _id; _id++;
        }

        private static int _id = 0;
        public string Password { get; set; }
        public string Username { get; set; }
        public IStudent Student { get; set; }
        public string ImageUrl { get; set; }
        public int AccountId { get; set; }
    }




    // Logic for deserializing Complex object (Account with IStudent Instance inside) without any exception
    public class ConcreteConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType) => true;

        public override object ReadJson(JsonReader reader,
         Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<T>(reader);
        }

        public override void WriteJson(JsonWriter writer,
            object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
