using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Page
{
	interface IPageGenerator<S, R>
	{
		R Generate(S src);
	}
}
