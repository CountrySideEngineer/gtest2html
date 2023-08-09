using gtest2html.Page.Html.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Page.Html.Generator
{
	internal class TestSuitesIndexPageGenerator : APageGenerator<TestSuites, string>
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public TestSuitesIndexPageGenerator() : base() { }

		/// <summary>
		/// Generate content of index page of a test suites.
		/// </summary>
		/// <param name="src">Source of TestSuies object.</param>
		/// <returns>Content of top page of test.</returns>
		public override string Generate(TestSuites src)
		{
			var template = new TestSuitesIndexHtmlTemplate(src);
			string content = template.TransformText();

			return content;
		}
	}
}
