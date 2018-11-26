using System;
using System.IO;
using uiowa.DelimitedDataHelper.Tab;
using uiowa.DelimitedDataHelper.Tests.TestModels;
using Xunit;

namespace uiowa.DelimitedDataHelper.Tests
{
    public class TabDelimitedFileTests : IDisposable
    {
        private readonly string _input = Path.Combine(@"Data\TabDelimitedFile.txt");
        private readonly string _output = Path.Combine(@"Data\output3.txt");

        public TabDelimitedFileTests()
        {
            Console.WriteLine("Delete potential output file");
            File.Delete(_output);
        }

        [Fact]
        public void ShouldReadAndWriteTabDelimitedFileCorrectly()
        {
            var data = new TabDelimitedFile(_input)
                        .SkipNRows(1)
                        .GetData<Contact>();
            data.WriteToTabDelimitedFile(_output);
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
