using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BiografAPI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        // [Fact] denne benyttes sammen med (1-2) frameworks moq og xunit
        public void FileNameDoesExist()
        {
            //Assert.Inconclusive();

            FileProcesses fp = new FileProcesses();
            bool fromCall;

            fromCall = fp.filenameexists(@"C:\Users\Lasse\Desktop\Music\DnB\9000 Miles.mp3");


            Assert.IsTrue(fromCall);
        }
        [TestMethod]
        public void FileNameDoesNotExist()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void FileNameNullOrEmptyThrowsArgumentNullException()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void FileNameNullOrEmpty_UsingAttribute()
        {
            Assert.Inconclusive();
        }
    }
}