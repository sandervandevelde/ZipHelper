using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZipHelperLib;

namespace ZipHelperUnitTest
{
    [TestClass]
    public class GZipHelperTest
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

            var zippedSource = GZipHelper.Zip(source);

            Assert.AreEqual(29, zippedSource.Length);

            var unzipped = GZipHelper.Unzip(zippedSource);

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

            var zippedSource = GZipHelper.Zip(source);

            Assert.AreEqual(1015, zippedSource.Length);

            var unzipped = GZipHelper.Unzip(zippedSource);

            //// ASSERT

            Assert.AreEqual(992, unzipped.Length);

            for (int i = 0; i < 992; i++)
            {
                Assert.AreEqual(source[i], unzipped[i]);
            }
        }
    }
}