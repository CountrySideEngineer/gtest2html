using System;
using System.Collections.Generic;
using gtest2html.Page.Html.Template;

namespace gtest2html.Page.Html.Generator
{
	internal class TopIndexPageGenerator : APageGenerator<IEnumerable<TestSuites>, string>
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public TopIndexPageGenerator() : base() { }

		/// <summary>
		/// Generate top index page content from collection of TestSuites object.
		/// </summary>
		/// <param name="src">Collection of TestSuites to be converted.</param>
		/// <returns>Content of top index page.</returns>
		public override string Generate(IEnumerable<TestSuites> src)
		{
			var template = new TopIndexHtmlTemplate(src);
			var content = template.TransformText();
			return content;
		}
	}
}
