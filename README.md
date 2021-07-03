# Introduction

This is a C# .Net Standard library which enables zipping and unzipping strings in memory.

No additional NuGet packages are needed, this logic is based on System.IO.Compression.

Please check if System.IO.Compression and Linq are included.

## NuGet

The Zip/Unzip logic is also available on http://nuget.org. 

You can find it on https://www.nuget.org/packages/ZipHelperLib/.

Or use your Package Manager in Visual Studio: **Install-Package ZipHelperLib -Version 1.0.0**

## Solution

This solution is deviced in three parts:

1. ZipHelperLib, the zip/unzip logic
2. ZipHelperApp, a test application for the zip/unzip logic; it uses a file (included in project) containing Lorem Ipsum text just to fill a stringto start with. After execution, check the compression rate
3. ZipHelperUnit, a unittest for the zip/unzip logic; it uses a text string, not a file

## Publishing

Follow this [guide](https://docs.microsoft.com/en-us/nuget/nuget-org/publish-a-package)

Do these steps:

- Update the`package version like '<PackageVersion>1.0.1</PackageVersion>' in the csproj of the library
- Compile the code
- Run the unittests
- In Visual Studio, right-click the project
- Publish
- Publish to a local folder
- Publish to 'ZipHelper\ZipHelperLib\bin\Release\netstandard2.0\publish'

A package is created.

Run:


```
dotnet nuget push ZipHelperLib.1.0.1.nupkg --api-key [a valid key gnerated on nuget.org] --source https://api.nuget.org/v3/index.json

pause
``` 

See a new version is made available.


## Contribute

This logic is licenced under the MIT license.

Want to contribute? Throw me a pull request....

Want to know more about me? Check out my [blog](http://blog.vandevelde-online.com)
