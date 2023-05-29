using gtest2html.Converter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Page
{
	public abstract class AReportPageFileGenerator : IReportPageGenerator
	{
		/// <summary>
		/// Output root directory information.
		/// </summary>
		public DirectoryInfo OutputRoot { get; set; }

		protected IConverter<FileInfo, TestSuites> _reportConverter;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public AReportPageFileGenerator()
		{
			OutputRoot = null;

			_reportConverter = new Xml2TestSuitesConverter();
		}

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="outputRoot">Output root directory information.</param>
		public AReportPageFileGenerator(DirectoryInfo outputRoot)
		{
			OutputRoot = outputRoot;

			_reportConverter = new Xml2TestSuitesConverter();
		}

		public virtual IEnumerable<TestSuites> ExtractTestSuites(IEnumerable<FileInfo> reportInfos)
		{
			List<TestSuites> testSuitesList = new List<TestSuites>();
			foreach (var reportFile in reportInfos)
			{
				TestSuites suites = ExtractTestSuites(reportFile);
				testSuitesList.Add(suites);
			}
			return testSuitesList;
		}

		public virtual TestSuites ExtractTestSuites(FileInfo reportInfo)
		{
			TestSuites suites = _reportConverter.Convert(reportInfo);
			return suites;
		}

		/// <summary>
		/// Abstract method to generate report page(s) of test suites.
		/// </summary>
		/// <param name="suitesCollection">Collection of test suites.</param>
		public abstract void Generate(IEnumerable<FileInfo> fileInfos);
	}
}
