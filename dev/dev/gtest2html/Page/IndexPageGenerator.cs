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

		/// <summary>
		/// Generate index page html file.
		/// </summary>
		/// <param name="fileInfos">Test resport XML file information.</param>
		public override void Generate(IEnumerable<FileInfo> fileInfos)
		{
			IEnumerable<TestSuites> testSuitesCollection = GetSuitesList(fileInfos);
			string content = Suites2Content(testSuitesCollection);
			SendReport(content);
		}

		/// <summary>
		/// Returns collection of TestSuites object converted from input fileInfos.
		/// </summary>
		/// <param name="fileInfos">Collection of FileInfo object about test report XML file.</param>
		/// <returns>Colelction of TestSuites object converted from inputs.</returns>
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

		/// <summary>
		/// Get output file information as FileInfo object.
		/// </summary>
		/// <returns>FileInfo object about output index.html file.</returns>
		protected virtual FileInfo GetOutputFileInfo()
		{
			string outputFileName = $@"{OutputRoot}\index.html";
			FileInfo outputFileInfo = new FileInfo(outputFileName);

			return outputFileInfo;
		}

		/// <summary>
		/// Convert collection of TestSuites into index page content as string.
		/// </summary>
		/// <param name="suites">Collection of TestSuites object.</param>
		/// <returns>Index page content in string data type.</returns>
		protected virtual string Suites2Content(IEnumerable<TestSuites> suites)
		{
			var converter = new TestSuties2IndexHtmlConverter();
			string content = converter.Convert(suites);
			return content;
		}

		/// <summary>
		/// Send content into page.
		/// </summary>
		/// <param name="content">Index page content.</param>
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
