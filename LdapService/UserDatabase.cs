using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace LdapService
{
    internal class UserDatabase
    {
        private readonly IConfiguration _configuration;

        public UserDatabase(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        internal List<User> GetUserDatabase()
        {
            return JsonConvert.DeserializeObject<List<User>>(File.ReadAllText($"{_configuration.GetValue<string>("DataDirectoryPath")}UserDataBase.json"));
        }

        public class User
        {
            public string Dn { get; set; }
            public Dictionary<string, List<string>> Attributes { get; set; }
        }
    }
}
