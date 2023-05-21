using gtest2html.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Converter
{
	class TestSuties2IndexHtmlConverter : ATest2HtmlConveter<IEnumerable<TestSuites>>
	{
		/// <summary>
		/// Create template for index.html
		/// </summary>
		/// <param name="src"></param>
		/// <returns>Template for index.html</returns>
		protected override TemplateCommonBase GetTemplate(IEnumerable<TestSuites> src)
		{
			var template = new TestSuites2IndexHtmlTemplate(src);
			return template;
		}
	}
}
