using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace uiowa.DelimitedDataHelper
{
    /// <summary>
    /// Delimited Data File. It must be a flat file.
    /// This is a helper class for reading data.
    /// <para>Open to Inheritance.</para>
    /// </summary>
    public class DelimitedDataFile
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly string Delimiter;
        /// <summary>
        /// File content rows
        /// </summary>
        public string[] Rows { get; protected set; }

        /// <summary>
        /// Delimited Data File. It needs to provide the fileName of a flat file and needs to know the delimiter.
        /// By default, the delimiter is tab ("\t").
        /// </summary>
        /// <param name="fileName">Required. Full path of a file.</param>
        /// <param name="delimiter">Optional. By default, the delimiter is tab ("\t").</param>
        public DelimitedDataFile(string fileName, string delimiter = "\t")
        {
            if (!File.Exists(fileName)) throw new FileNotFoundException($"File [{fileName}] Not Found");
            Rows = File.ReadAllLines(fileName).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            Delimiter = delimiter;
        }

        /// <summary>
        /// Skip reading the first n rows in a CSV file.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public virtual DelimitedDataFile SkipNRows(int n)
        {
            Rows = Rows.Skip(n).ToArray();
            return this;
        }

        /// <summary>
        /// Get a collection of objects of type T. This method takes an optional parameter DelimitedFileReaderConfig.
        /// <para>By default, reader will trim starting/ending white spaces of each entry.</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="config">Optional. By default, reader will trim starting/ending white spaces of each entry.</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetData<T>(DelimitedFileReaderConfig config = null) where T : new()
        {
            if (config == null) config = new DelimitedFileReaderConfig();
            var objProperties = typeof(T).GetProperties();

            foreach (var x in Rows)
            {
                var items = x.Split(new[] { Delimiter }, StringSplitOptions.None);
                var result = new T();
                var i = 0;
                foreach (var propertyInfo in objProperties)
                {
                    var value = config.NeedTrimStartEndWhiteSpaces ? Sanitize(items[i]) : items[i];
                    propertyInfo.SetValue(result, Convert.ChangeType(value, propertyInfo.PropertyType));
                    i++;
                }
                yield return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        protected virtual string Sanitize(string s)
        {
            return s.Trim();
        }
    }
}
