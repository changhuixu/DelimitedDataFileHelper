using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uiowa.DelimitedDataHelper.Csv;
using uiowa.DelimitedDataHelper.Tests.TestModels;

namespace uiowa.DelimitedDataHelper.Tests
{
    [TestClass]
    public class CsvFileTests
    {
        private static readonly string ProjDir = AppDomain.CurrentDomain.BaseDirectory;
        private readonly string _input = Path.Combine(ProjDir, @"Data", @"Contacts.csv");
        private readonly string _output = Path.Combine(ProjDir, @"Data", @"output1.csv");

        [TestInitialize]
        public void Initialize()
        {
            Console.WriteLine("Delete potential output file");
            File.Delete(_output);
        }

        [TestMethod]
        public void ShouldReadAndWriteCsvCorrectly()
        {
            var data = new CsvFile(_input)
                        .SkipNRows(1)
                        .GetData<Contact>();
            data.WriteToCsvFile(_output);
            var result1 = File.ReadAllLines(_input);
            var result2 = File.ReadAllLines(_output);
            foreach (var b in result1)
            {
                Console.Write(b);
            }
            Console.WriteLine();

            foreach (var b in result2)
            {
                Console.Write(b);
            }
            Console.WriteLine();

            CollectionAssert.AreEqual(result2, result1);
        }

        [TestCleanup]
        public void Cleanup()
        {
            File.Delete(_input);
            File.Delete(_output);
            Console.WriteLine("Output file deleted");
        }
    }
}
