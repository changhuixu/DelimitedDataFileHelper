using DelimitedDataHelper.Pipe;
using DelimitedDataHelper.Tests.TestModels;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.IO;

namespace DelimitedDataHelper.Tests
{
    [TestFixture]
    public class PipeDelimitedFileTests
    {
        private static readonly string ProjectFolder = AppDomain.CurrentDomain.BaseDirectory;
        private readonly string _input = Path.Combine(ProjectFolder, @"Data\PipeDelimitedFile.txt");
        private readonly string _output = Path.Combine(ProjectFolder, @"Data\output2.txt");

        [SetUp]
        public void SetUp()
        {
            File.Delete(_output);
        }

        [Test]
        public void ShouldReadAndWritePipeDelimitedFileCorrectly()
        {
            var data = new PipeDelimitedFile(_input)
                        .SkipNRows(1)
                        .GetData<Contact>();
            data.WriteToPipeDelimitedFile(_output);
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
