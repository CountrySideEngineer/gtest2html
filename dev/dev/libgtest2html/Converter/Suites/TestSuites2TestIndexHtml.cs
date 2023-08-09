using gtest2html.Page.Html.Generator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Converter.Suites
{
	internal class TestSuites2TestIndexHtml : ATestSuites2Html
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public TestSuites2TestIndexHtml() : base() { }

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="dirInfo"Output directory information.</param>
		public TestSuites2TestIndexHtml(DirectoryInfo dirInfo) : base(dirInfo) { }

		/// <summary>
		/// Convert TestSuites info file.
		/// </summary>
		/// <param name="testSuites">TestSuites object to be converted.</param>
		public override void Convert(TestSuites testSuites)
		{
			var generator = new TestSuitesIndexFileGenerator(OutputDir);
			generator.Generate(testSuites);
		}
	}
}
