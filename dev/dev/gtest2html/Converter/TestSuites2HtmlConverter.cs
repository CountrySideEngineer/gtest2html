using gtest2html.Template;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Converter
{
	class TestSuites2HtmlConverter : ATest2HtmlConveter<TestSuites>
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public TestSuites2HtmlConverter() { }

		/// <summary>
		/// Get template to convert TestSuites object into HTML format.
		/// </summary>
		/// <param name="suites">TestSuites to be converted.</param>
		/// <returns>HTML template file.</returns>
		protected override TemplateCommonBase GetTemplate(TestSuites suites)
		{
			var template = new TestSuitesHtmlTemplate(suites);
			return template;
		}
	}
}
