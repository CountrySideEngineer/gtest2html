using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Template
{
	partial class TestMessageHtmlTemplate
	{
		/// <summary>
		/// Path to parent page path.
		/// </summary>
		public string ParentPage { get; set; }

		/// <summary>
		/// Failure information.
		/// </summary>
		public Failure Failure { get; set; }

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="parentPage">Parent page path.</param>
		/// <param name="failure">Failure information as Failure object.</param>
		public TestMessageHtmlTemplate(string parentPage, Failure failure)
		{
			this.ParentPage = parentPage;
			this.Failure = failure;
		}
	}
}
