using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace TestTools.Base
{
    public class ConfigurationSection : IConfigurationSection
    {
        private string _connectionString;
        public ConfigurationSection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string this[string key] { get => _connectionString; set => _connectionString = value; }

        public string Key => "ConnectionStrings";

        public string Path => string.Empty;

        public string Value { get => _connectionString; set => _connectionString = value; }

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
            throw new NotImplementedException();
        }
    }
}
