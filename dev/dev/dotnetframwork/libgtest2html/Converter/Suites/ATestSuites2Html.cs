using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Converter.Suites
{
	internal abstract class ATestSuites2Html 
	{
		public DirectoryInfo OutputDir { get; set; }

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ATestSuites2Html() { }

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="outputDir">Output directory information.</param>
		public ATestSuites2Html(DirectoryInfo outputDir)
		{
			OutputDir = outputDir;
		}

		/// <summary>
		/// Convert collection of TestSuites object into HTML file.
		/// </summary>
		/// <param name="testSuitesCollection">Collection of TestSuites to convert into HTML file.</param>
		public virtual void Convert(IEnumerable<TestSuites> testSuitesCollection)
		{
			foreach (var testSuites in testSuitesCollection)
			{
				Convert(testSuites);
			}
		}

		public abstract void Convert(TestSuites testSuites);
	}
}
