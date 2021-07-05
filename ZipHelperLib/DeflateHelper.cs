using System.IO;
using System.IO.Compression;

namespace ZipHelperLib
{
    public class DeflateHelper
    {
        public static byte[] Zip(byte[] byteArray)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var deflateStream = new DeflateStream(memoryStream, CompressionMode.Compress, true))
                {
                    using (var streamWriter = new BufferedStream(deflateStream)) // encoding is not relevant
                    {
                        streamWriter.Write(byteArray, 0, byteArray.Length);
                    }
                }

                return memoryStream.ToArray();
            }
        }

        public static byte[] Unzip(byte[] byteArray)
        {
            using (var zippedMemoryStream = new MemoryStream(byteArray))
            {
                using (var unZippedMemoryStream = new MemoryStream())
                {
                    using (var deflateStream = new DeflateStream(zippedMemoryStream, CompressionMode.Decompress))
                    {
                        using (var unZippedBufferedStream = new BufferedStream(deflateStream))
                        {
                            unZippedBufferedStream.CopyTo(unZippedMemoryStream);
                        }

                        return unZippedMemoryStream.ToArray();
                    }
                }
            }
        }
    }
}