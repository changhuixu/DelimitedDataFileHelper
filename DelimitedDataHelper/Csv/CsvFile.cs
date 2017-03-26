using System;
using System.Collections.Generic;

namespace DelimitedDataHelper.Csv
{
    public class CsvFile : DelimitedDataFile
    {
        private const string QuotedDelimiter = "\",\"";
        public CsvFile(string fileName) : base(fileName, ",")
        {
        }

        /// <summary>
        /// Skip reading the first n rows in a CSV file.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public new CsvFile SkipNRows(int n)
        {
            return (CsvFile)base.SkipNRows(n);
        }

        /// <summary>
        /// Get a collection of objects of type T. This method takes an optional parameter CsvReaderConfig.
        /// <para>By default, reader will trim starting/ending white spaces of each entry and reader will parse "" quoted entries.</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="config">Optional. By default, reader will trim starting/ending white spaces of each entry and reader will parse "" quoted entries.</param>
        /// <returns></returns>
        public IEnumerable<T> GetData<T>(CsvReaderConfig config = null) where T : new()
        {
            if (config == null) config = new CsvReaderConfig();
            return config.IsQuoted ? ParseQuotedCsvData<T>(config) : base.GetData<T>(config);
        }

        private IEnumerable<T> ParseQuotedCsvData<T>(DelimitedFileReaderConfig config) where T : new()
        {
            var objProperties = typeof(T).GetProperties();
            foreach (var x in Rows)
            {
                var items = x.Split(new[] { QuotedDelimiter }, StringSplitOptions.None);
                items[0] = items[0].Substring(1);
                items[objProperties.Length - 1] = TrimLastCharacter(items[objProperties.Length - 1]);
                var result = new T();
                var i = 0;
                foreach (var propertyInfo in objProperties)
                {
                    var value = config.NeedTrimStartEndWhiteSpaces ? items[i].Trim() : items[i];
                    propertyInfo.SetValue(result, Convert.ChangeType(value, propertyInfo.PropertyType));
                    i++;
                }
                yield return result;
            }
        }

        private static string TrimLastCharacter(string s)
        {
            return s.Substring(0, s.Length - 1);
        }
    }
}
