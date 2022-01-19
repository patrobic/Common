using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace TestTools.Base
{
    public class Configuration : IConfiguration
    {
        private Dictionary<string, string> _configurations = new Dictionary<string, string>();

        public string this[string key] { get { return _configurations[key]; } set { } }

        public Configuration(string connection)
        {
            _configurations["DefaultConnection"] = connection;
        }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            throw new NotImplementedException();
        }

        public IChangeToken GetReloadToken()
        {
            throw new NotImplementedException();
        }

        public IConfigurationSection GetSection(string key)
        {
            return new ConfigurationSection(_configurations["DefaultConnection"]);
        }
    }
}
