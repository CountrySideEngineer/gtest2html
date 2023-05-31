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

		/// <summary>
		/// Extract suites from report files.
		/// </summary>
		/// <param name="reportInfos">Collection of FileInfo object of XML repotr file.</param>
		/// <returns>Collection of TestSuites object.</returns>
		/// <exception cref="Exception"></exception>
		public virtual IEnumerable<TestSuites> ExtractTestSuites(IEnumerable<FileInfo> reportInfos)
		{
			List<TestSuites> testSuitesList = new List<TestSuites>();
			try
			{
				foreach (var reportFile in reportInfos)
				{
					TestSuites suites = ExtractTestSuites(reportFile);
					testSuitesList.Add(suites);
				}
				return testSuitesList;
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Extract test suites data from report file in XML format.
		/// </summary>
		/// <param name="reportInfo">FileInfo object of report file in XML format.</param>
		/// <returns>TestSuites object.</returns>
		/// <exception cref="Exception"></exception>
		public virtual TestSuites ExtractTestSuites(FileInfo reportInfo)
		{
			try
			{
				TestSuites suites = _reportConverter.Convert(reportInfo);
				return suites;
			}
			catch (NullReferenceException)
			{
				string message = "Converter has not been set."
					+ Environment.NewLine
					+ "Check the application or restart PC.";
				throw new Exception(message);
			}
			catch (Exception)
			{
				string message = "An error detected whlie generating report."
					+ Environment.NewLine
					+ "Check your test suite report file.";
				throw new Exception(message);
			}
		}

		/// <summary>
		/// Abstract method to generate report page(s) of test suites.
		/// </summary>
		/// <param name="suitesCollection">Collection of test suites.</param>
		public abstract void Generate(IEnumerable<FileInfo> fileInfos);
	}
}
