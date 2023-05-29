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

		/// <summary>
		/// Genereate test report pages in HTML format as a file.
		/// </summary>
		/// <param name="fileInfos">Collection of test report file in XML format.</param>
		public override void Generate(IEnumerable<FileInfo> fileInfos)
		{
			foreach (var fileInfo in fileInfos)
			{
				TestSuites testSuites = base.ExtractTestSuites(fileInfo);
				string content = Suites2Content(testSuites);
				SendReport(fileInfo, content);
			}
		}

		/// <summary>
		/// Generate test report page in HTML format as a file.
		/// </summary>
		/// <param name="fileInfo">Test report file information in XML format.</param>
		public virtual void Generate(FileInfo fileInfo)
		{
			TestSuites testSuites = base.ExtractTestSuites(fileInfo);
			string content = Suites2Content(testSuites);
			SendReport(fileInfo, content);
		}

		/// <summary>
		/// Returns path to file to output file.
		/// </summary>
		/// <param name="fileInfo">File information as FileInfo object.</param>
		/// <returns>FileInfo object about output file.</returns>
		protected virtual FileInfo GetOutputFileInfo(FileInfo fileInfo)
		{
			string fileName = Path.GetFileNameWithoutExtension(fileInfo.FullName);
			string outputFileName = $@"{OutputRoot.FullName}\{fileName}.html";
			FileInfo outputFileInfo = new FileInfo(outputFileName);

			return outputFileInfo;
		}

		/// <summary>
		/// Convert TestSuites object into string data in HTML format.
		/// </summary>
		/// <param name="suites">TestSuties object as </param>
		/// <returns>HTML data as string data.</returns>
		protected virtual string Suites2Content(TestSuites suites)
		{
			var converter = new TestSuites2HtmlConverter();
			string content = converter.Convert(suites);
			return content;
		}

		/// <summary>
		/// Send content into output file info, FileInfo.
		/// </summary>
		/// <param name="fileInfo">Output file information </param>
		/// <param name="content">HTML content in string data type.</param>
		protected virtual void SendReport(FileInfo fileInfo, string content)
		{
			FileInfo destInfo = GetOutputFileInfo(fileInfo);

			using (var writer = new StreamWriter(destInfo.FullName, false, Encoding.UTF8))
			{
				writer.Write(content);
			}
		}
	}
}
