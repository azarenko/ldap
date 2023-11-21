using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;

namespace Sample
{
    internal class UserDatabase
    {
        internal List<User> GetUserDatabase()
        {
            return JsonConvert.DeserializeObject<List<User>>(File.ReadAllText("UserDataBase.json"));
        }

        public class User
        {
            public string Dn { get; set; }
            public Dictionary<string, List<string>> Attributes { get; set; }
        }
    }
}
