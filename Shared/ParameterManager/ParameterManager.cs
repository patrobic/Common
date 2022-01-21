using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Shared.Base;
using System.IO;

namespace Shared.ParameterManager
{
    public class ParameterManager : IParameterManager
    {
        private ParameterManagerParameters _parameters = new();
        private static object _lock = new();

        public void GetParameters(IParameters parameters)
        {
            if (!parameters.WriteToDisk)
            {
                return;
            }
            var path = Path.Combine(_parameters.ParametersPath, $"{parameters.ModuleName}.json");
            if (File.Exists(path))
            {
                LoadParameters(parameters, path);
            }
            else
            {
                CreateDefaults(parameters, path);
            }
        }

        private void LoadParameters(IParameters parameters, string path)
        {
            string json;
            lock (_lock)
            {
                json = File.ReadAllText(path);
            }
            JsonConvert.PopulateObject(json, parameters, GetSettings());
        }

        private void CreateDefaults(IParameters parameters, string path)
        {
            var json = JsonConvert.SerializeObject(parameters, GetSettings());
            lock (_lock)
            {
                Directory.CreateDirectory(_parameters.ParametersPath);
                File.WriteAllText(path, json);
            }
        }

        private JsonSerializerSettings GetSettings()
        {
            var options = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ObjectCreationHandling = ObjectCreationHandling.Replace,
            };
            options.Converters.Add(new StringEnumConverter());
            return options;
        }
    }
}
