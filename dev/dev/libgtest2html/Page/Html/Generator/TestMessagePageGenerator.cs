using gtest2html.Page.Html.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Page.Html.Generator
{
	internal class TestMessagePageGenerator : APageGenerator<TestSuites, string>
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public TestMessagePageGenerator() : base() { }

		/// <summary>
		/// Generate conent about the failure.
		/// </summary>
		/// <param name="src">TestSuites object.</param>
		/// <returns>Content of test message page.</returns>
		public override string Generate(TestSuites src)
		{
			string content = string.Empty;
			foreach (var testSuite in src.TestSuitesItems)
			{
				string newContent = Generate(testSuite);
				if (!string.IsNullOrEmpty(content))
				{
					content += Environment.NewLine;
				}
				content += newContent;

			}
			return content;
		}

		/// <summary>
		/// Generate content about test suite.
		/// </summary>
		/// <param name="src">TestSuite object.</param>
		/// <returns>Content of test message page.</returns>
		protected virtual string Generate(TestSuite src)
		{
			string content = string.Empty;
			foreach (var testCase in src.TestCases)
			{
				string newContent = Generate(testCase);
				if (!string.IsNullOrEmpty(content))
				{
					content += Environment.NewLine;
				}
				content += newContent;
			}
			return content;
		}

		/// <summary>
		/// Generate test failure message.
		/// </summary>
		/// <param name="src">TestCase object.</param>
		/// <returns>Content of test message page.</returns>
		protected virtual string Generate(TestCase src)
		{
			string content = string.Empty;
			if (src.IsFail)
			{
				content = Generate(src.Failure);
			}
			else
			{
				content = string.Empty;
			}
			return content;
		}

		/// <summary>
		/// Generate test filure message.
		/// </summary>
		/// <param name="src">Failure message.</param>
		/// <returns>Failure message.</returns>
		protected virtual string Generate(Failure src)
		{
			var template = new TestMessageHtmlTemplate(src);
			string content = template.TransformText();

			return content;
		}
	}
}
