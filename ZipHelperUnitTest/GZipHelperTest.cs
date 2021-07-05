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

            var zippedSource = ZipHelper.Zip(source);

            var unzipped = ZipHelper.UnzipByteArray(zippedSource);

            //// ASSERT

            Assert.AreEqual(992, unzipped.Length);

            for (int i = 0; i < 992; i++)
            {
                Assert.AreEqual(source[i], unzipped[i]);
            }
        }
    }
}