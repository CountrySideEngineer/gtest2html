using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Page.Html.Template
{
	partial class TestMessageHtmlTemplate
	{
		protected Failure _failure;

		/// <summary>
		/// Default constructor.
		/// </summary>
		protected TestMessageHtmlTemplate()
		{
			_failure = null;
		}

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="failure">Failure object.</param>
		public TestMessageHtmlTemplate(Failure failure)
		{
			_failure = failure;
		}
	}
}
