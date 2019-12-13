using System.Collections.Generic;

namespace uiowa.DelimitedDataHelper.Tab
{
    /// <inheritdoc />
    public class TabDelimitedFile : DelimitedDataFile
    {
        /// <inheritdoc />
        /// <summary>
        /// Tab ("\t") delimited file.
        /// </summary>
        /// <param name="fileName"></param>
        public TabDelimitedFile(string fileName) : base(fileName)
        {

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class TabDelimitedDataWriter
    {
        /// <summary>
        /// Write to Tab ("\t") delimited flat file. Takes fileName as a parameter and takes an optional DelimitedFileWriterConfig parameter.
        /// <para>By default, the writer will write header as the first row in the output file..</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        /// <param name="config"></param>
        public static void WriteToTabDelimitedFile<T>(this IEnumerable<T> data, string fileName, DelimitedFileWriterConfig config = null)
        {
            new DelimitedFileWriter().CreateFileWithData(data, fileName, config);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="config"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string AsTabedString<T>(this IEnumerable<T> data, DelimitedFileWriterConfig config = null)
        {
            return new DelimitedFileWriter().ConvertToString(data, config);
        }
    }
}
