using System;
using System.Reflection;

using MsieJavaScriptEngine;

namespace TestCoreJsInActiveScriptJsEngine
{
	public class Program
	{
		static void Main(string[] args)
		{
			bool? embedHostObject = null;

			while (!embedHostObject.HasValue)
			{
				Console.WriteLine(@"Options for executing JS scripts:
  #1 With embedding of host object
  #2 Without embedding of host object

You should select an option. Please, type a number of option:");

				string optionNumber = Console.ReadLine().Trim();

				switch (optionNumber)
				{
					case "1":
						embedHostObject = true;
						break;
					case "2":
						embedHostObject = false;
						break;
				}

				Console.WriteLine();
			}

			const string polyfillsResourceName = "TestCoreJsInActiveScriptJsEngine.Resources.es6-polyfills.js";
			Assembly assembly = typeof(Program).Assembly;
			var settings = new JsEngineSettings { EngineMode = JsEngineMode.ChakraActiveScript };

			MsieJsEngine engine = null;

			try
			{
				engine = new MsieJsEngine(settings);
				if (embedHostObject.Value)
				{
					engine.EmbedHostObject("someObj", new SomeClass());
				}
				engine.ExecuteResource(polyfillsResourceName, assembly);
				engine.Evaluate("var arr = Array.of(3);");
				int arrayLength = engine.Evaluate<int>("arr.length;");

				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Success!");

				Console.WriteLine();

				Console.ResetColor();
				Console.WriteLine("Array length: {0}", arrayLength);
			}
			catch (JsException e)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Failed!");

				Console.WriteLine();

				Console.ResetColor();
				Console.WriteLine(e.Message);
			}
			finally
			{
				engine?.Dispose();
			}
		}
	}
}