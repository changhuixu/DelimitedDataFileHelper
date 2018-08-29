using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uiowa.DelimitedDataHelper.Pipe;
using uiowa.DelimitedDataHelper.Tests.TestModels;

namespace uiowa.DelimitedDataHelper.Tests
{
    [TestClass]
    public class PipeDelimitedFileTests
    {
        private static readonly string ProjectFolder = AppDomain.CurrentDomain.BaseDirectory;
        private readonly string _input = Path.Combine(ProjectFolder, @"Data\PipeDelimitedFile.txt");
        private readonly string _output = Path.Combine(ProjectFolder, @"Data\output2.txt");

        [TestInitialize]
        public void SetUp()
        {
            Console.WriteLine("Delete potential output file");
            File.Delete(_output);
        }

        [TestMethod]
        public void ShouldReadAndWritePipeDelimitedFileCorrectly()
        {
            var data = new PipeDelimitedFile(_input)
                        .SkipNRows(1)
                        .GetData<Contact>();
            data.WriteToPipeDelimitedFile(_output);
            var result1 = File.ReadAllBytes(_input);
            var result2 = File.ReadAllBytes(_output);
            CollectionAssert.AreEqual(result2, result1);
        }

        [TestCleanup]
        public void TearDown()
        {
            File.Delete(_input);
            File.Delete(_output);
            Console.WriteLine("Output file deleted");
        }
    }
}
