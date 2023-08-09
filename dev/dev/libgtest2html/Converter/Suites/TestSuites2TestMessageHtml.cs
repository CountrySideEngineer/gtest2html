using gtest2html.Page.Html.Generator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Converter.Suites
{
	internal class TestSuites2TestMessageHtml : ATestSuites2Html
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public TestSuites2TestMessageHtml() : base() { }

		public TestSuites2TestMessageHtml(DirectoryInfo dirInfo) : base(dirInfo) { }

		public override void Convert(TestSuites testSuites)
		{
			var generator = new TestMessageFileGenerator(OutputDir);
			generator.Generate(testSuites);
		}
	}
}
