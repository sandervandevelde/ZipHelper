using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZipHelperLib;

namespace ZipHelperApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //// 1. Read file from disk and text. So text is our input

            var fileName = @"lipsum.txt";
            var textBuffer = File.ReadAllText(fileName);

            //// 2. ZIP IN MEMORY. Create zipped byte array from string

            var zippedBuffer = ZipHelper.Zip(textBuffer);

            //// 3. write byte array to zip file

            var zipName = @"lipsum.zip";
            File.WriteAllBytes(zipName, zippedBuffer);

            //// 4. read zip from file into byte array

            var rawFileStream = File.OpenRead(zipName);
            byte[] zippedtoTextBuffer = new byte[rawFileStream.Length];
            rawFileStream.Read(zippedtoTextBuffer, 0, (int)rawFileStream.Length);

            //// 5. UNZIP IN MEMORY. Create text from zipped byte array

            var text = ZipHelper.Unzip(zippedtoTextBuffer);

            //// 6. Write unzipped file

            File.WriteAllText(@"lipsum.unzipped.txt", text);
        }
    }
}
