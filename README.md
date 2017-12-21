# Introduction

This is a C# .Net Standard library which enables zipping and unzipping strings in memory.

No additional NuGet packages are needed, this logic is based on System.IO.Compression.

Please check if System.IO.Compression and Linq are included.

## NuGet

The Zip/Unzip logic is also available on http://nuget.org. 

You can find it on https://www.nuget.org/packages/ZipHelperLib/

Or use your Package Manager in Visual Studio: **Install-Package ZipHelperLib -Version 1.0.0**

## Solution

This solution is deviced in three parts:

1. ZipHelperLib, the zip/unzip logic
2. ZipHelperApp, a test application for the zip/unzip logic; it uses a file (included in project) containing Lorem Ipsum text just to fill a stringto start with. After execution, check the compression rate. 
3. ZipHelperUnit, a unittest for the zip/unzip logic; it uses a text string, no files.

## Contribute

This logic is licenced under the MIT license.

Want to contribute? Throw me a pull request....

Want to know more about me? Check out my [blog](http://blog.vandevelde-online.com)
