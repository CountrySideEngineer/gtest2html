using gtest2html.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Converter
{
	class TestSuites2MessageHtmlConverter : ATest2HtmlConveter<Failure>
	{
		public string ParentPagePath { get; set; }

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TestSuites2MessageHtmlConverter() : base()
		{
			ParentPagePath = null;
		}

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="parentPath"></param>
		public TestSuites2MessageHtmlConverter(string parentPath) : base()
		{
			ParentPagePath = parentPath;
		}

		/// <summary>
		/// Returns template file for Failure message.
		/// </summary>
		/// <param name="src"></param>
		/// <returns></returns>
		protected override TemplateCommonBase GetTemplate(Failure src)
		{
			var template = new TestMessageHtmlTemplate(ParentPagePath, src);
			return template;
		}
	}
}
