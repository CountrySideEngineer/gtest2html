using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Page.Html.Template
{
	partial class TestSuitesIndexHtmlTemplate
	{
		protected TestSuites _testSuites;

		/// <summary>
		/// Default constructor.
		/// </summary>
		protected TestSuitesIndexHtmlTemplate()
		{
			_testSuites = null;
		}

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="testSuites">TestSuites object to be converted.</param>
		public TestSuitesIndexHtmlTemplate(TestSuites testSuites)
		{
			_testSuites = testSuites;
		}
	}
}
