using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace ZipHelperLib
{
    public class GZipHelper
    {
        public static byte[] Zip(byte[] byteArray)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
                {
                    using (var streamWriter = new BufferedStream(gzipStream)) // encoding is not relevant
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
                    using (var unZippedBufferedStream = new BufferedStream(new GZipStream(zippedMemoryStream, CompressionMode.Decompress)))
                    {
                        unZippedBufferedStream.CopyTo(unZippedMemoryStream);
                    }
                    return unZippedMemoryStream.ToArray();
                }
            }
        }
    }
}