using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Converter
{
	interface IXmlConverter<S, R>
	{
		IEnumerable<R> Convert(IEnumerable<S> src);

		R Convert(S src);
	}
}
