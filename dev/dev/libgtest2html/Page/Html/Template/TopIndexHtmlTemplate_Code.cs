using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Page.Html.Template
{
	partial class TopIndexHtmlTemplate
	{
		protected IEnumerable<TestSuites> _testSuitesCollection;

		/// <summary>
		/// Default constructor.
		/// </summary>
		protected TopIndexHtmlTemplate()
		{
			_testSuitesCollection = null;
		}

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="testSuitesCollection">Collection of test suites.</param>
		public TopIndexHtmlTemplate(IEnumerable<TestSuites> testSuitesCollection)
		{
			_testSuitesCollection = testSuitesCollection;
		}

		/// <summary>
		/// The total number of test.
		/// </summary>
		public int TestNum
		{
			get
			{
				try
				{
					int sum = _testSuitesCollection.Select(suites => suites.Tests).Sum();
					return sum;
				}
				catch (NullReferenceException)
				{
					return 0;
				}
			}
		}

		/// <summary>
		/// The total number of failure.
		/// </summary>
		public int FailureNum
		{
			get
			{
				try
				{
					int sum = _testSuitesCollection.Select(suites => suites.Failures).Sum();
					return sum;
				}
				catch (NullReferenceException)
				{
					return 0;
				}
			}
		}

		/// <summary>
		/// The total number of disable.
		/// </summary>
		public int DisableNum
		{
			get
			{
				try
				{
					int sum = _testSuitesCollection.Select(suites => suites.Disabled).Sum();
					return sum;
				}
				catch (NullReferenceException)
				{
					return 0;
				}
			}
		}

		/// <summary>
		/// The total number of error.
		/// </summary>
		public int ErrorNum
		{
			get
			{
				try
				{
					int sum = _testSuitesCollection.Select(suites => suites.Errors).Sum();
					return sum;
				}
				catch (NullReferenceException)
				{
					return 0;
				}
			}
		}

		/// <summary>
		/// The total time of test.
		/// </summary>
		public float TimeNum
		{
			get
			{
				try
				{
					float sum = _testSuitesCollection.Select(suites => suites.Time).Sum();
					return sum;
				}
				catch (NullReferenceException)
				{
					return 0.0F;
				}
			}
		}
	}
}
