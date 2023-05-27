using gtest2html.Converter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Page
{
	class IndexPageGenerator : AReportPageFileGenerator
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public IndexPageGenerator() :  base() { }

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="outputRoot">Output root directory information.</param>
		public IndexPageGenerator(DirectoryInfo outputRoot) : base(outputRoot) { }

		public override void Generate(IEnumerable<FileInfo> fileInfos)
		{
			IEnumerable<TestSuites> testSuitesCollection = GetSuitesList(fileInfos);
			string content = Suites2Content(testSuitesCollection);
			SendReport(content);
		}

		protected IEnumerable<TestSuites> GetSuitesList(IEnumerable<FileInfo> fileInfos)
		{
			var suitesList = new List<TestSuites>();
			foreach (var fileInfoItme in fileInfos)
			{
				TestSuites testSuites = base.ExtractTestSuites(fileInfoItme);
				suitesList.Add(testSuites);
			}
			return suitesList;
		}

		protected virtual FileInfo GetOutputFileInfo()
		{
			string outputFileName = $@"{OutputRoot}\index.html";
			FileInfo outputFileInfo = new FileInfo(outputFileName);

			return outputFileInfo;
		}

		protected virtual string Suites2Content(IEnumerable<TestSuites> suites)
		{
			var converter = new TestSuties2IndexHtmlConverter();
			string content = converter.Convert(suites);
			return content;
		}

		protected virtual void SendReport(string content)
		{
			FileInfo destFileInfo = GetOutputFileInfo();

			using (var writer = new StreamWriter(destFileInfo.FullName, false, Encoding.UTF8))
			{
				writer.Write(content);
			}
		}
	}
}
