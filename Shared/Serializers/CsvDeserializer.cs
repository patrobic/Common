using CsvHelper;
using CsvHelper.Configuration;
using Shared.Logger;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Shared.Serializers
{
    public class CsvDeserializer<TMap, TTemplate>
        where TMap : ClassMap<TTemplate>
    {
        private ILogger _logger;

        public CsvDeserializer(ILogger logger = null)
        {
            _logger = logger;
        }

        public IList<TTemplate> Deserialize(string path)
        {
            try
            {
                using var reader = new StreamReader(path);
                var templates = Read(reader);

                if (_logger != null)
                {
                    _logger.Info(GetType(), $"Successfully imported {typeof(TTemplate).Name} file {path}.");
                }
                return templates;
            }
            catch (Exception e)
            {
                if (_logger != null)
                {
                    _logger.Error(GetType(), $"Failed Importing {typeof(TTemplate).Name} file {path}.", e);
                }
                return new List<TTemplate>();
            }
        }

        public IList<TTemplate> Deserialize(byte[] file)
        {
            try
            {
                Stream stream = new MemoryStream(file);
                using var reader = new StreamReader(stream);

                var records = Read(reader);
                return records;
            }
            catch (Exception e)
            {
                if (_logger != null)
                {
                    _logger.Error(GetType(), $"Failed Importing {typeof(TTemplate).Name} file.", e);
                }
                return new List<TTemplate>();
            }
        }

        private IList<TTemplate> Read(StreamReader reader)
        {
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<TMap>();

            var records = csv.GetRecords(typeof(TTemplate)).Cast<TTemplate>().ToList();
            return records;
        }
    }
}