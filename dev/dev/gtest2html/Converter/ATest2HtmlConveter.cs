using gtest2html.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Converter
{
	abstract class ATest2HtmlConveter<S> : IConverter<S, string>
	{
		public string Convert(S src)
		{
			TemplateCommonBase template = GetTemplate(src);
			string content = template.TransformText();

			return content;
		}

		protected abstract TemplateCommonBase GetTemplate(S src);
	}
}
