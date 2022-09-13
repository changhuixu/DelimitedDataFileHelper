using System.Reflection;
using System.Text;

namespace uiowa.DelimitedDataHelper
{
    internal class DelimitedFileWriter
    {
        private readonly string _delimiter;

        public DelimitedFileWriter(string delimiter = "\t")
        {
            _delimiter = delimiter;
        }

        /// <summary>
        /// Create a file and fill in content with data. If file exists, then the original file will be overwritten.
        /// </summary>
        /// <param name="data">List of data with type of (T).</param>
        /// <param name="fileName"></param>
        /// <param name="config">Optional. By default, true, write header, which is a list of property names in type (T).</param>
        public void CreateFileWithData<T>(IEnumerable<T> data, string fileName, DelimitedFileWriterConfig? config = null)
        {
            config ??= new DelimitedFileWriterConfig();
            if (File.Exists(fileName)) File.Delete(fileName);
            var objProperties = typeof(T).GetProperties();

            if (config.WriteHeader)
            {
                var header = GetHeader(objProperties);
                File.AppendAllText(fileName, header);
            }
            File.AppendAllText(fileName, WriteRows(data, objProperties));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public string ConvertToString<T>(IEnumerable<T> data, DelimitedFileWriterConfig? config = null)
        {
            config ??= new DelimitedFileWriterConfig();
            var objProperties = typeof(T).GetProperties();
            var sb = new StringBuilder();
            if (config.WriteHeader) sb.Append(GetHeader(objProperties));
            sb.Append(WriteRows(data, objProperties));
            return sb.ToString();
        }

        protected virtual string GetHeader(PropertyInfo[] objProperties)
        {
            var result = new StringBuilder();
            foreach (var objProperty in objProperties)
            {
                result.Append(Escape(objProperty.Name)).Append(_delimiter);
            }

            result.Length -= _delimiter.Length;
            result.AppendLine();
            return result.ToString();
        }

        protected virtual string WriteRows<T>(IEnumerable<T> data, PropertyInfo[] objProperties)
        {
            var result = new StringBuilder();

            foreach (var obj in data)
            {
                foreach (var objProperty in objProperties)
                {
                    result.Append(Escape(objProperty.GetValue(obj))).Append(_delimiter);
                }
                result.Length -= _delimiter.Length;
                result.AppendLine();
            }

            return result.ToString();
        }

        protected virtual string Escape(object? o)
        {
            return o?.ToString() ?? string.Empty;
        }
    }
}
