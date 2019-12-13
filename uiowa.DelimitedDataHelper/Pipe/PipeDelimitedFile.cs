using System.Collections.Generic;

namespace uiowa.DelimitedDataHelper.Pipe
{
    /// <inheritdoc />
    public class PipeDelimitedFile : DelimitedDataFile
    {
        /// <inheritdoc />
        /// <summary>
        /// Delimited flat file with separator "|"
        /// </summary>
        /// <param name="fileName"></param>
        public PipeDelimitedFile(string fileName) : base(fileName, "|")
        {

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class PipeDelimitedDataWriter
    {
        /// <summary>
        /// Write to "|" delimited flat file. Takes fileName as a parameter and takes an optional DelimitedFileWriterConfig parameter.
        /// <para>By default, the writer will write header as the first row in the output file..</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        /// <param name="config"></param>
        public static void WriteToPipeDelimitedFile<T>(this IEnumerable<T> data, string fileName, DelimitedFileWriterConfig config = null)
        {
            new DelimitedFileWriter("|").CreateFileWithData(data, fileName, config);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="config"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string AsPipedString<T>(this IEnumerable<T> data, DelimitedFileWriterConfig config = null)
        {
            return new DelimitedFileWriter("|").ConvertToString(data, config);
        }
    }
}
