using System.Linq;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace ZipHelperLib
{
    /// <summary>
    /// This is a C# .Net Standard library which enables zipping and unzipping strings in memory.
    /// Zip and Unzip in memory using System.IO.Compression.
    /// </summary>
    /// <remarks>
    /// Please check if System.IO.Compression and Linq are included.
    /// </remarks>
    public static class ZipHelper
    {
        /// <summary>
        /// Zips a string into a zipped byte array.
        /// </summary>
        /// <param name="textToZip">The text to be zipped.</param>
        /// <param name="zippedFileName">Optional alternative filename</param>
        /// <param name="compressionLevel">Compressionlevel (default optimal)</param>
        /// <returns>byte[] representing a zipped stream (Encoding.Default)</returns>
        public static byte[] Zip(string textToZip, string zippedFileName = "zipped.txt", CompressionLevel compressionLevel = CompressionLevel.Optimal)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    var demoFile = zipArchive.CreateEntry(zippedFileName, compressionLevel);

                    using (var entryStream = demoFile.Open())
                    {
                        using (var streamWriter = new StreamWriter(entryStream, Encoding.Default))
                        {
                            streamWriter.Write(textToZip);
                        }
                    }
                }

                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Zips a byte array into a zipped byte array.
        /// </summary>
        /// <param name="byteArrayToZip">The byte array to be zipped.</param>
        /// <param name="zippedFileName">Optional alternative filename</param>
        /// <param name="compressionLevel">Compressionlevel (default optimal)</param>
        /// <returns>byte[] representing a zipped stream</returns>
        public static byte[] Zip(byte[] byteArrayToZip, string zippedFileName = "zipped.txt", CompressionLevel compressionLevel = CompressionLevel.Optimal)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    var demoFile = zipArchive.CreateEntry(zippedFileName, compressionLevel);

                    using (var entryStream = demoFile.Open())
                    {
                        using (var streamWriter = new StreamWriter(entryStream)) // encoding is not relevant
                        {
                            streamWriter.BaseStream.Write(byteArrayToZip, 0, byteArrayToZip.Length);
                        }
                    }
                }

                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Unzip a zipped byte array into a string.
        /// </summary>
        /// <param name="zippedBuffer">The byte array to be unzipped</param>
        /// <returns>string representing the original stream (Encoding.Default)</returns>
        public static string Unzip(byte[] zippedBuffer)
        {
            using (var zippedStream = new MemoryStream(zippedBuffer))
            {
                using (var archive = new ZipArchive(zippedStream))
                {
                    var entry = archive.Entries.FirstOrDefault(); // We expect at least one file

                    if (entry != null)
                    {
                        using (var unzippedEntryStream = entry.Open())
                        {
                            using (var ms = new MemoryStream())
                            {
                                unzippedEntryStream.CopyTo(ms);
                                var unzippedArray = ms.ToArray();

                                return Encoding.Default.GetString(unzippedArray);
                            }
                        }
                    }

                    return null;
                }
            }
        }

        /// <summary>
        /// Unzip a zipped byte array into a string.
        /// </summary>
        /// <param name="zippedBuffer">The byte array to be unzipped</param>
        /// <returns>string representing the original byte array stream</returns>
        public static byte[] UnzipByteArray(byte[] zippedBuffer)
        {
            using (var zippedStream = new MemoryStream(zippedBuffer))
            {
                using (var archive = new ZipArchive(zippedStream))
                {
                    var entry = archive.Entries.FirstOrDefault(); // We expect at least one file

                    if (entry != null)
                    {
                        using (var unzippedEntryStream = entry.Open())
                        {
                            using (var ms = new MemoryStream())
                            {
                                unzippedEntryStream.CopyTo(ms);
                                var unzippedArray = ms.ToArray();

                                return unzippedArray;
                            }
                        }
                    }

                    return null;
                }
            }
        }
    }
}