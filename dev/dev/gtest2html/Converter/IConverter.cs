using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Converter
{
	public interface IConverter<S, D>
	{
		D Convert(S src);
	}
}
