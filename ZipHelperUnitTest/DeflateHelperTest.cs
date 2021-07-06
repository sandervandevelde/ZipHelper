using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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

            Assert.AreEqual(11, deflatedSource.Length);

            var unzipped = DeflateHelper.Unzip(deflatedSource);

            //// ASSERT

            Assert.AreEqual(992, unzipped.Length);

            for (int i = 0; i < 992; i++)
            {
                Assert.AreEqual(source[i], unzipped[i]);
            }
        }

        [TestMethod]
        public void TestZipUnzipRandomSucceeds()
        {
            //// ARRANGE

            var source = new byte[992];

            var r = new Random(42);

            r.NextBytes(source);

            //// ACT

            var deflatedSource = DeflateHelper.Zip(source);

            Assert.AreEqual(997, deflatedSource.Length);

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