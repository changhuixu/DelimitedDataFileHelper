﻿namespace uiowa.DelimitedDataHelper
{
    internal class CsvFileWriter : DelimitedFileWriter
    {
        public CsvFileWriter() : base(",")
        {

        }

        protected override string Escape(object? o)
        {
            return o == null ? "" : $"\"{o.ToString()?.Replace("\"", "\"\"")}\"";
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class CsvFileExtensions
    {
        /// <summary>
        /// Extension method to Write a data collection to a CSV file.
        /// <para>Need to provide file name.</para>
        /// <para>Can take an optional CsvWriterConfig. By default, CsvWriter will write header and will write "" quoted entries.</para>
        /// </summary>
        /// <typeparam name="T">Data type of IEnumerable(T)</typeparam>
        /// <param name="data"></param>
        /// <param name="fileName">Full path for output file.</param>
        /// <param name="config">Optional. By default, null, which means will write header and will write "" quoted entries.</param>
        public static void WriteToCsvFile<T>(this IEnumerable<T> data, string fileName, CsvWriterConfig? config = null)
        {
            if (config == null) config = new CsvWriterConfig();
            if (config.IsQuoted)
            {
                new CsvFileWriter().CreateFileWithData(data, fileName, config);
                return;
            }
            new DelimitedFileWriter().CreateFileWithData(data, fileName, config);
        }

        /// <summary>
        /// Convert a collection of Data to string.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="config"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string AsCsvString<T>(this IEnumerable<T> data, CsvWriterConfig? config = null)
        {
            config ??= new CsvWriterConfig();
            if (config.IsQuoted)
            {
                return new CsvFileWriter().ConvertToString(data, config);

            }
            return new DelimitedFileWriter().ConvertToString(data, config);
        }
    }
}
