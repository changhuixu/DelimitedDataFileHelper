using DelimitedDataHelper.Csv;
using DelimitedDataHelper.Tests.TestModels;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.IO;

namespace DelimitedDataHelper.Tests
{
    [TestFixture]
    public class CsvFileTests
    {
        private static readonly string ProjectFolder = AppDomain.CurrentDomain.BaseDirectory;
        private readonly string _input = Path.Combine(ProjectFolder, @"Data\Contacts.csv");
        private readonly string _output = Path.Combine(ProjectFolder, @"Data\output1.csv");

        [SetUp]
        public void SetUp()
        {
            File.Delete(_output);
        }

        [Test]
        public void ShouldReadAndWriteCsvCorrectly()
        {
            var data = new CsvFile(_input)
                        .SkipNRows(1)
                        .GetData<Contact>();
            data.WriteToCsvFile(_output);
            var result1 = File.ReadAllBytes(_input);
            var result2 = File.ReadAllBytes(_output);
            result1.Should().Equal(result2);
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(_input);
            File.Delete(_output);
        }
    }
}
