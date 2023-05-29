using gtest2html.Converter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Page
{
	class ErrorReportPageGenerator : AReportPageFileGenerator
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public ErrorReportPageGenerator() : base() { }

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="outputRoot">Output root directory information.</param>
		public ErrorReportPageGenerator(DirectoryInfo outputRoot) : base(outputRoot) { }

		/// <summary>
		/// Generate error report page html file.
		/// </summary>
		/// <param name="fileInfos"></param>
		public override void Generate(IEnumerable<FileInfo> fileInfos)
		{
			foreach (var fileInfo in fileInfos)
			{
				Generate(fileInfo);
			}
		}

		protected virtual void Generate(FileInfo fileInfo)
		{
			TestSuites suites = base.ExtractTestSuites(fileInfo);
			foreach (var suite in suites.TestItems)
			{
				IEnumerable<TestCase> failedTestCases = suite.TestCases.Where(_ => _.IsFail);
				foreach (var testCase in failedTestCases)
				{
					Generate(fileInfo, suite, testCase);
				}
			}
		}

		protected virtual void Generate(FileInfo fileInfo, TestSuite testSuite, TestCase testCase)
		{
			FileInfo parent = GetParentPageFileInfo(fileInfo);
			string content = TestCase2Content(testCase, parent);
			SendReport(content, testSuite, testCase);
		}

		protected string TestCase2Content(TestCase testCase, FileInfo parentPage)
		{
			var failure = new Failure()
			{
				Message = testCase.Failure.Message.Replace("\n", "<br>")
			};
			var converter = new TestSuites2MessageHtmlConverter()
			{
				ParentPagePath = parentPage.Name
			};
			string content = converter.Convert(failure);
			return content;
		}

		protected FileInfo GetOutputFileInfo(TestSuite suite, TestCase testCase)
		{
			string outputFileName = $@"{suite.Name}_{testCase.Name}.html";
			string outputFilePath = $@"{OutputRoot.FullName}\{outputFileName}";
			FileInfo outputFileInfo = new FileInfo(outputFilePath);

			return outputFileInfo;
		}

		protected FileInfo GetParentPageFileInfo(FileInfo parentFileInfo)
		{
			string fileName = Path.GetFileNameWithoutExtension(parentFileInfo.FullName);
			string parentPageFileName = $"{fileName}.html";
			string parentFilePath = $@"{OutputRoot.FullName}\{parentPageFileName}";
			FileInfo fileInfo = new FileInfo(parentFilePath);

			return fileInfo;
		}

		protected virtual void SendReport(string content, TestSuite testSuite, TestCase testCase)
		{
			FileInfo fileInfo = GetOutputFileInfo(testSuite, testCase);

			using (var writer = new StreamWriter(fileInfo.FullName, false, Encoding.UTF8))
			{
				writer.Write(content);
			}
		}
	}
}
