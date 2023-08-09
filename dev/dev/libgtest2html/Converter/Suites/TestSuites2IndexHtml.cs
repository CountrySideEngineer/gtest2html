using gtest2html.Page.Html.Generator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Converter.Suites
{
	internal class TestSuites2IndexHtml : ATestSuites2Html
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public TestSuites2IndexHtml() : base() { }

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="dirInfo">Output directory information.</param>
		public TestSuites2IndexHtml(DirectoryInfo dirInfo) : base(dirInfo) { }

		/// <summary>
		/// Convert test suites collection into HTML file.
		/// </summary>
		/// <param name="testSuitesCollection">Collection of TestSuites object to be converted.</param>
		public override void Convert(IEnumerable<TestSuites> testSuitesCollection)
		{
			var generator = new TopIndexFileGenerator(OutputDir);
			generator.Generate(testSuitesCollection);
		}

		/// <summary>
		/// Convert test suites into HTML file.
		/// </summary>
		/// <param name="testSuites">TestSuites object to be converted.</param>
		public override void Convert(TestSuites testSuites)
		{
			var collection = new List<TestSuites>()
			{
				testSuites
			};
			Convert(collection);
		}
	}
}
