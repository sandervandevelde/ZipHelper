using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZipHelperLib;

namespace ZipHelperUnitTest
{
    [TestClass]
    public class DeflateHelperTest
    {
        [TestMethod]
        public void TestZipUnzipSucceeds()
        {
            //// ARRANGE

            var source = new byte[992];

            for (int i = 0; i < source.Length; i++)
            {
                source[i] = 42;
            }

            //// ACT

            var deflatedSource = DeflateHelper.Zip(source);

            var unzipped = DeflateHelper.Unzip(deflatedSource);

            //// ASSERT

            Assert.AreEqual(992, unzipped.Length);

            for (int i = 0; i < 992; i++)
            {
                Assert.AreEqual(source[i], unzipped[i]);
            }
        }
    }
}