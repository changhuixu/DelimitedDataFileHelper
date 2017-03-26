namespace DelimitedDataHelper
{
    /// <summary>
    /// Delimited File Reader Configurations. By default, reader will trim starting/ending white spaces of each entry.
    /// </summary>
    public class DelimitedFileReaderConfig
    {
        public bool NeedTrimStartEndWhiteSpaces { get; set; }

        /// <summary>
        /// Delimited File Reader Configurations. By default, reader will trim starting/ending white spaces of each entry.
        /// </summary>
        public DelimitedFileReaderConfig()
        {
            NeedTrimStartEndWhiteSpaces = true;
        }

        /// <summary>
        /// Delimited File Reader Configurations. By default, reader will trim starting/ending white spaces of each entry.
        /// </summary>
        /// <param name="needTrimStartEndWhiteSpaces">Optional. By default, true, reader will trim starting/ending white spaces of each entry.</param>
        public DelimitedFileReaderConfig(bool needTrimStartEndWhiteSpaces)
        {
            NeedTrimStartEndWhiteSpaces = needTrimStartEndWhiteSpaces;
        }
    }

    /// <summary>
    /// Delimited File Writer Configurations. By default, writer will write header as the first row of the output file.
    /// </summary>
    public class DelimitedFileWriterConfig
    {
        public bool WriteHeader { get; set; }

        /// <summary>
        /// Delimited File Writer Configurations. By default, writer will write header as the first row of the output file.
        /// </summary>
        public DelimitedFileWriterConfig()
        {
            WriteHeader = true;
        }

        /// <summary>
        /// Delimited File Writer Configurations. By default, writer will write header as the first row of the output file.
        /// </summary>
        /// <param name="writeHeader">Optional. By default, true, writer will write header as the first row of the output file.</param>
        public DelimitedFileWriterConfig(bool writeHeader)
        {
            WriteHeader = writeHeader;
        }
    }
}
