using System.Collections.Generic;

namespace DelimitedDataHelper.Tab
{
    public class TabDelimitedFile : DelimitedDataFile
    {
        /// <summary>
        /// Tab ("\t") delimited file.
        /// </summary>
        /// <param name="fileName"></param>
        public TabDelimitedFile(string fileName) : base(fileName)
        {

        }
    }

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
    }
}
