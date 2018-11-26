namespace uiowa.DelimitedDataHelper.Csv
{
    /// <inheritdoc />
    /// <summary>
    /// Csv Reader Configuration.
    /// <para>Set up the reader to consider the case when entries are "" quoted.</para>
    /// <para>Set up the reader to return Trim() string or not.</para>
    /// </summary>
    public class CsvReaderConfig : DelimitedFileReaderConfig
    {
        public bool IsQuoted { get; set; }


        /// <inheritdoc />
        /// <summary>
        /// Csv Reader Configuration. 
        /// Set up the reader to consider the case when entries are "" quoted.
        /// Set up the reader to return Trim() string or not.
        /// </summary>
        /// <param name="isQuoted">Optional. By default, isQuoted is true.</param>
        /// <param name="needTrimStartEndWhiteSpaces">Optional. By default, true.</param>
        public CsvReaderConfig(bool isQuoted = true, bool needTrimStartEndWhiteSpaces = true) : base(needTrimStartEndWhiteSpaces)
        {
            IsQuoted = isQuoted;
        }

        /// <inheritdoc />
        /// <summary>
        /// Default Csv Reader Configuration.
        /// The reader will regard all enties are "" quoted.
        /// The reader will trim starting/ending white spaces.
        /// </summary>
        public CsvReaderConfig()
        {
            IsQuoted = true;
            NeedTrimStartEndWhiteSpaces = true;
        }
    }


    /// <inheritdoc />
    public class CsvWriterConfig : DelimitedFileWriterConfig
    {
        /// <summary>
        /// Is the cell value double quoted?
        /// </summary>
        public bool IsQuoted { get; set; }


        /// <inheritdoc />
        /// <summary>
        /// Csv Writer configurations. 
        /// Set up the writer to consider the case if need to write "" quoted entries;
        /// Set up the writer to consider the case if need to writer header.
        /// </summary>
        /// <param name="isQuoted">Optional. By default, isQuoted is true.</param>
        /// <param name="writeHeader">Optional. By default, writeHeader is true.</param>
        public CsvWriterConfig(bool isQuoted = true, bool writeHeader = true) : base(writeHeader)
        {
            IsQuoted = isQuoted;
        }

        /// <inheritdoc />
        /// <summary>
        /// Default Csv Writer configuration.
        /// The writer will write header, will use "" to escape all entries.
        /// </summary>
        public CsvWriterConfig()
        {
            IsQuoted = true;
            WriteHeader = true;
        }
    }
}
