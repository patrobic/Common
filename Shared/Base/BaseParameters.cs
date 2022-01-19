using Newtonsoft.Json;
using Shared.ParameterManager;
using System;

namespace Book.Base
{
    public abstract class BaseParameters : IParameters
    {
        protected IParameterManager _manager;

        public BaseParameters(string name, IParameterManager manager = null, BaseParameters parameters = null)
        {
            _manager = manager;
            ModuleName = name ?? GetType().Name;

            Initialize(manager);

            if (parameters != null)
            {
                BookCode = parameters.BookCode;
                UserName = parameters.UserName;
            }
        }

        private void Initialize(IParameterManager manager = null)
        {
            manager?.GetParameters(this);
        }

        [JsonIgnore]
        public string ModuleName { get; init; }

        [JsonIgnore]
        public bool WriteToDisk { get; init; } = true;

        [JsonIgnore]
        public string OutputPath { get; set; }

        [JsonIgnore]
        public string BookCode { get; set; } = $"Book_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}";

        [JsonIgnore]
        public string UserName { get; set; }
    }
}