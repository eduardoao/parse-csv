using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace ParseCSV
{
    public class CsvParser 
    {   
        public List<string[]> ParserCsv(string csv)
        {
            var lines = new List<string[]>();
            foreach (string line in Regex.Split(csv, Environment.NewLine)
                .ToList().Where(s => !string.IsNullOrEmpty(s)))
            {
                string[] values = Regex.Split(line, ",");

                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim('\"');
                }
                lines.Add(values);
            }

            return lines;
        }

        public List<string> ParseToCsv<T>(List<T> list)
        {
            var lines = new List<string>();
            var properts = TypeDescriptor.GetProperties(typeof(T)).OfType<PropertyDescriptor>();
            var header = string.Join(",", properts.ToList().Select(col => col.Name));
            lines.Add(header);

            var valueLines = list.Select(row => string.Join(","
                , header
                .Split(',')
                .Select(
                    a => row
                    .GetType()
                    .GetProperty(a)
                    .GetValue(row, null)
                    )));

            lines.AddRange(valueLines);
            return lines;
        }


    }
}
