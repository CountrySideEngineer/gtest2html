using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Template
{
	public partial class TestSuitesHtmlTemplate
	{
		public TestSuites TestSuites { get; set; }

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="testSuites">Test suites.</param>
		public TestSuitesHtmlTemplate(TestSuites testSuites)
		{
			TestSuites = testSuites;
		}
	}
}
