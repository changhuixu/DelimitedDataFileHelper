using Microsoft.VisualStudio.TestTools.UnitTesting;
using uiowa.DelimitedDataHelper.Tests.TestModels;

namespace uiowa.DelimitedDataHelper.Tests
{
    [TestClass]
    public class TabDelimitedFileTests
    {
        private static readonly string ProjDir = AppDomain.CurrentDomain.BaseDirectory;
        private readonly string _input = Path.Combine(ProjDir, @"Data", @"TabDelimitedFile.txt");
        private readonly string _output = Path.Combine(ProjDir, @"Data", @"output3.txt");

        [TestInitialize]
        public void Initialize()
        {
            Console.WriteLine("Delete potential output file");
            File.Delete(_output);
        }

        [TestMethod]
        public void ShouldReadAndWriteTabDelimitedFileCorrectly()
        {
            var data = new TabDelimitedFile(_input)
                        .SkipNRows(1)
                        .GetData<Contact>();
            data.WriteToTabDelimitedFile(_output);
            var result1 = File.ReadAllLines(_input);
            var result2 = File.ReadAllLines(_output);
            CollectionAssert.AreEqual(result2, result1);
        }

        [TestMethod]
        public void ShouldConvertToString()
        {
            var dataString = new TabDelimitedFile(_input)
                .SkipNRows(1)
                .GetData<Contact>().AsTabDelimitedString();
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
