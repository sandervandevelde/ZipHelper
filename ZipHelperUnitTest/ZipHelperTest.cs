using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ZipHelperLib;

namespace ZipHelperUnitTest
{
    [TestClass]
    public class ZipHelperTest
    {
        private const string LIPSUMextended = "üe'[]{}éëLorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam rutrum risus at sodales ullamcorper. Pellentesque condimentum ut tellus in blandit. Aliquam tristique ante ac accumsan scelerisque. Pellentesque sagittis magna nec eros ullamcorper laoreet. Praesent suscipit sagittis metus, dignissim ornare ligula dignissim quis. Nunc in cursus lectus. Praesent laoreet congue velit nec ornare. Quisque gravida lobortis lobortis. Nam sit amet vulputate lectus, molestie scelerisque sem. Morbi et enim faucibus, aliquet ipsum sit amet, vulputate urna. Phasellus sollicitudin luctus ante. Ut finibus cursus ante quis semper. Sed ac interdum erat. Mauris ullamcorper magna non fermentum blandit. Praesent vitae arcu sed nibh cursus sagittis vel eu ante. Suspendisse tempor augue id purus malesuada vestibulum.";

        [TestMethod]
        public void TestZipUnzipSucceeds()
        {
            //// ARRANGE

            var expected = LIPSUMextended;

            //// ACT

            var zippedContent = ZipHelper.Zip(expected);
            var actual = ZipHelper.Unzip(zippedContent);

            //// ASSERT

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestZipUnzipWithAlternativeFilenameSucceeds()
        {
            //// ARRANGE

            var expected = LIPSUMextended;

            //// ACT

            var zippedContent = ZipHelper.Zip(expected, "a.json");
            var actual = ZipHelper.Unzip(zippedContent);

            //// ASSERT

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestZipJsonSucceeds()
        {
            //// ARRANGE

            var jsonMessage = JsonConvert.SerializeObject(new JsonMessage());

            //// ACT

            var zippedContent = ZipHelper.Zip(jsonMessage);
            var actual = ZipHelper.Unzip(zippedContent);

            //// ASSERT

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestZipUnzipByteArraySucceeds()
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

    public class JsonMessage
    {
        public int Test { get; set; }
    }
}