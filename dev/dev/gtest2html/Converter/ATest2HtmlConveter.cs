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
		/// <summary>
		/// A sequence to convert content as S data type into string.
		/// </summary>
		/// <param name="src">Source to be conveted.</param>
		/// <returns>Converted HTML content in string data type.</returns>
		public string Convert(S src)
		{
			TemplateCommonBase template = GetTemplate(src);
			string content = template.TransformText();

			return content;
		}

		/// <summary>
		/// Abstracted method to get HTML template.
		/// </summary>
		/// <param name="src">Source to be converted.</param>
		/// <returns></returns>
		protected abstract TemplateCommonBase GetTemplate(S src);
	}
}
