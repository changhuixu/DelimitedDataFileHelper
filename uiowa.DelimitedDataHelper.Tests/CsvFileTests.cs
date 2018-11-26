using System;
using System.IO;
using uiowa.DelimitedDataHelper.Csv;
using uiowa.DelimitedDataHelper.Tests.TestModels;
using Xunit;

namespace uiowa.DelimitedDataHelper.Tests
{
    public class CsvFileTests : IDisposable
    {
        private static readonly string ProjectFolder = AppDomain.CurrentDomain.BaseDirectory;
        private readonly string _input = Path.Combine(ProjectFolder, @"Data\Contacts.csv");
        private readonly string _output = Path.Combine(ProjectFolder, @"Data\output1.csv");

        public CsvFileTests()
        {
            Console.WriteLine("Delete potential output file");
            File.Delete(_output);
        }

        [Fact]
        public void ShouldReadAndWriteCsvCorrectly()
        {
            var data = new CsvFile(_input)
                        .SkipNRows(1)
                        .GetData<Contact>();
            data.WriteToCsvFile(_output);
            var result1 = File.ReadAllBytes(_input);
            var result2 = File.ReadAllBytes(_output);
            Assert.Equal(result2, result1);
        }

        public void Dispose()
        {
            File.Delete(_input);
            File.Delete(_output);
            Console.WriteLine("Output file deleted");
        }
    }
}
