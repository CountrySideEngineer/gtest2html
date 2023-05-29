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

		/// <summary>
		/// Generate error report page HTML file.
		/// </summary>
		/// <param name="fileInfo">Test report file information.</param>
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

		/// <summary>
		/// Generate error report page HTML file.
		/// </summary>
		/// <param name="fileInfo">Test report file information.</param>
		/// <param name="testSuite">Test suite information.</param>
		/// <param name="testCase">Failed test case data.</param>
		protected virtual void Generate(FileInfo fileInfo, TestSuite testSuite, TestCase testCase)
		{
			FileInfo parent = GetParentPageFileInfo(fileInfo);
			string content = TestCase2Content(testCase, parent);
			SendReport(content, testSuite, testCase);
		}

		/// <summary>
		/// Convert TestCase object into html content.
		/// </summary>
		/// <param name="testCase">TestCase</param>
		/// <param name="parentPage">Parent page file information.</param>
		/// <returns>Error information page content.</returns>
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

		/// <summary>
		/// Returns output file information.
		/// </summary>
		/// <param name="suite">TestSuite object of failed test case.</param>
		/// <param name="testCase">TestCase object of failed test.</param>
		/// <returns>FileInfo object of error page.</returns>
		protected FileInfo GetOutputFileInfo(TestSuite suite, TestCase testCase)
		{
			string outputFileName = $@"{suite.Name}_{testCase.Name}.html";
			string outputFilePath = $@"{OutputRoot.FullName}\{outputFileName}";
			FileInfo outputFileInfo = new FileInfo(outputFilePath);

			return outputFileInfo;
		}

		/// <summary>
		/// Returns parent page of error report page.
		/// </summary>
		/// <param name="parentFileInfo">Parent file information.</param>
		/// <returns>Error page file information.</returns>
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
