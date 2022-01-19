using System;
using System.IO;

namespace Shared.ParameterManager
{
    public class ParameterManagerParameters
    {
        public string ParametersPath { get; set; } = Path.Combine(Path.GetDirectoryName(AppContext.BaseDirectory), "Parameters");
    }
}
