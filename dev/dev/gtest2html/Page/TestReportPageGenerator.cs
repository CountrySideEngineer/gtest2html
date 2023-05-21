using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Page
{
	using gtest2html.Converter;

	class TestReportPageGenerator : AReportPageFileGenerator
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public TestReportPageGenerator() : base() { }

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="outputRoot">Output root directory information.</param>
		public TestReportPageGenerator(DirectoryInfo outputRoot) : base(outputRoot) { }

		public override void Generate(IEnumerable<FileInfo> fileInfos)
		{
			foreach (var fileInfo in fileInfos)
			{
				TestSuites testSuites = base.ExtractTestSuites(fileInfo);
				string content = Suites2Content(testSuites);
				SendReport(fileInfo, content);
			}
		}

		public virtual void Generate(FileInfo fileInfo)
		{
			TestSuites testSuites = base.ExtractTestSuites(fileInfo);
			string content = Suites2Content(testSuites);
			SendReport(fileInfo, content);
		}

		protected virtual FileInfo GetOutputFileInfo(FileInfo fileInfo)
		{
			string fileName = Path.GetFileNameWithoutExtension(fileInfo.FullName);
			string outputFileName = $@"{OutputRoot.FullName}\{fileName}.html";
			FileInfo outputFileInfo = new FileInfo(outputFileName);

			return outputFileInfo;
		}

		protected virtual string Suites2Content(TestSuites suites)
		{
			var template = new TestSuites2HtmlConverter();
			string content = template.Convert(suites);
			return content;
		}

		protected void SendReport(FileInfo fileInfo, string content)
		{
			FileInfo destInfo = GetOutputFileInfo(fileInfo);

			using (var writer = new StreamWriter(destInfo.FullName, false, Encoding.UTF8))
			{
				writer.Write(content);
			}
		}
	}
}
