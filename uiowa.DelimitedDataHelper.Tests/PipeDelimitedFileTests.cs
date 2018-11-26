using System;
using System.IO;
using uiowa.DelimitedDataHelper.Pipe;
using uiowa.DelimitedDataHelper.Tests.TestModels;
using Xunit;

namespace uiowa.DelimitedDataHelper.Tests
{
    public class PipeDelimitedFileTests : IDisposable
    {
        private readonly string _input = Path.Combine(@"Data\PipeDelimitedFile.txt");
        private readonly string _output = Path.Combine(@"Data\output2.txt");

        public PipeDelimitedFileTests()
        {
            Console.WriteLine("Delete potential output file");
            File.Delete(_output);
        }

        [Fact]
        public void ShouldReadAndWritePipeDelimitedFileCorrectly()
        {
            var data = new PipeDelimitedFile(_input)
                        .SkipNRows(1)
                        .GetData<Contact>();
            data.WriteToPipeDelimitedFile(_output);
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
