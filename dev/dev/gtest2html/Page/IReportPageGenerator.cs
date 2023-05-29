using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Page
{
	interface IReportPageGenerator
	{
		void Generate(IEnumerable<FileInfo> fileInfos);
	}
}
