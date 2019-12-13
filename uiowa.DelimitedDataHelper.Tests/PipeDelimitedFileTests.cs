using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uiowa.DelimitedDataHelper.Pipe;
using uiowa.DelimitedDataHelper.Tests.TestModels;

namespace uiowa.DelimitedDataHelper.Tests
{
    [TestClass]
    public class PipeDelimitedFileTests
    {
        private static readonly string ProjDir = AppDomain.CurrentDomain.BaseDirectory;
        private readonly string _input = Path.Combine(ProjDir, @"Data", @"PipeDelimitedFile.txt");
        private readonly string _input2 = Path.Combine(ProjDir, @"Data", @"PipeDelimitedFile2.txt");
        private readonly string _output = Path.Combine(ProjDir, @"Data", @"output2.txt");

        [TestInitialize]
        public void Initialize()
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
            var result1 = File.ReadAllLines(_input);
            var result2 = File.ReadAllLines(_output);
            CollectionAssert.AreEqual(result2, result1);
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenWrongColumnNumber()
        {
            Action action = () => _ = new PipeDelimitedFile(_input2)
                .SkipNRows(1)
                .GetData<Contact>().ToList();
            var e = Assert.ThrowsException<IndexOutOfRangeException>(action);
            Assert.AreEqual("Index was outside the bounds of the array. DataRow: Johnson|ABC|johnson@abc.com", e.Message);
        }

        [TestMethod]
        public void ShouldConvertToString()
        {
            var dataString = new PipeDelimitedFile(_input)
                .SkipNRows(1)
                .GetData<Contact>().AsPipedString();
            var result1 = File.ReadAllLines(_input).ToArray();
            var result2 = dataString.Split(Environment.NewLine).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            CollectionAssert.AreEqual(result2, result1);
        }

        [TestCleanup]
        public void Cleanup()
        {
            File.Delete(_output);
        }
    }
}
