using CsvHelper;
using IssueWatcher.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueWatcher.Services
{
    public class CustomFilterService
    {
        private readonly string _SavedFiltersFile = "Data\\saved_filters.csv";

        public void SaveFilter(CustomFilter filtro)
        {
            bool fileExists = File.Exists(_SavedFiltersFile);

            using (var writer = new StreamWriter(_SavedFiltersFile, append: true))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                if (!fileExists)
                {
                    csv.WriteHeader<CustomFilter>();
                    csv.NextRecord();
                }
                csv.WriteRecord(filtro);
                csv.NextRecord();
            }
        }

        public List<CustomFilter> GetAllFilters()
        {
            if (!File.Exists(_SavedFiltersFile))
                return new List<CustomFilter>();

            using (var reader = new StreamReader(_SavedFiltersFile))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<CustomFilter>().ToList();
            }
        }
    }
}
