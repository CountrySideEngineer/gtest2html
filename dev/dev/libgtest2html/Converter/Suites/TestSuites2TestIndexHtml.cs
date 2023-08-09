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

		public TestSuites2TestIndexHtml(DirectoryInfo dirInfo) : base(dirInfo) { }

		public override void Convert(TestSuites testSuites)
		{
			var generator = new TestSuitesIndexFileGenerator(OutputDir);
			generator.Generate(testSuites);
		}
	}
}
