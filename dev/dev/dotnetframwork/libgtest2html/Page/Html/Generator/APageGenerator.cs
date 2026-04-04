using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Page.Html.Generator
{
	using gtest2html.Page;

	public abstract class APageGenerator<S, R> : IPageGenerator<S, R>
	{
		public abstract R Generate(S src);
	}
}
