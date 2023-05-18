using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Converter
{
	class TestSuites2HtmlConverter : IConverter<IEnumerable<TestSuite>, string>
	{
		public string Convert(IEnumerable<TestSuite> src)
		{
			throw new NotImplementedException();
		}
	}
}
