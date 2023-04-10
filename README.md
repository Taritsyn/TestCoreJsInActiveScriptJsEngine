TestCoreJsInActiveScriptJsEngine
================================

.NET console application for reproduce an error that occurs during execution of a polyfill based on the [core-js](https://github.com/zloirock/core-js) library in the `ChakraActiveScript` mode of [MSIE JavaScript Engine for .NET](https://github.com/Taritsyn/MsieJavaScriptEngine).

## Prerequisites

 1. Windows 7 SP1 or higher with the `jscript9.dll` library installed in the `System32` folder
 1. .NET Framework 4.6.2 or higher
 1. [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
 1. [Git for Windows](https://git-scm.com/download/win)
 1. [Node.js](https://nodejs.org/en/download)

## Steps to reproduce the error

 * Clone a repository.
   * `mkdir TemporaryProjects && cd TemporaryProjects`
   * `git clone https://github.com/Taritsyn/TestCoreJsInActiveScriptJsEngine`
 * Build a JS polyfills.
   * `cd TestCoreJsInActiveScriptJsEngine`
   * `build-js`
 * Run a console application.
   * `dotnet run -c Release`
   * Select a first option