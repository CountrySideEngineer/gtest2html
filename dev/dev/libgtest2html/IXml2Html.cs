using System;
using System.Collections.Generic;
using System.IO;

namespace gtest2html
{
	interface IXml2Html<S>
	{
		void Convert(IEnumerable<S> sources);

		void Convert(S source);
	}
}
