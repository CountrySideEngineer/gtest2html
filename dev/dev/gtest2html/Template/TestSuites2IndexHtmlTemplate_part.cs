using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Template
{
	partial class TestSuites2IndexHtmlTemplate
	{
		/// <summary>
		/// Collection of TestSuites object.
		/// </summary>
		public IEnumerable<TestSuites> TestSuitesList { get; set; }

		/// <summary>
		/// Constructor with argument about 
		/// </summary>
		/// <param name="testSuites"></param>
		public TestSuites2IndexHtmlTemplate(IEnumerable<TestSuites> testSuites)
		{
			this.TestSuitesList = testSuites;
		}

		/// <summary>
		/// The number of test.
		/// </summary>
		public int TestNum
		{
			get
			{
				int sum = 0;

				try
				{
					foreach (var testItem in TestSuitesList)
					{
						sum += testItem.Tests;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					sum = 0;
				}
				return sum;
			}
		}

		/// <summary>
		/// The number of failure.
		/// </summary>
		public int FailureNum
		{
			get
			{
				int sum = 0;

				try
				{
					foreach (var testItem in TestSuitesList)
					{
						sum += testItem.Failures;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					sum = 0;
				}
				return sum;
			}
		}

		/// <summary>
		/// The number of disable.
		/// </summary>
		public int DisableNum
		{
			get
			{
				int sum = 0;

				try
				{
					foreach (var testItem in TestSuitesList)
					{
						sum += testItem.Disabled;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					sum = 0;
				}
				return sum;
			}
		}

		/// <summary>
		/// The number of error.
		/// </summary>
		public int ErrorNum
		{
			get
			{
				int sum = 0;

				try
				{
					foreach (var testItem in TestSuitesList)
					{
						sum += testItem.Errors;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					sum = 0;
				}
				return sum;
			}
		}

		/// <summary>
		/// Total time.
		/// </summary>
		public float TimeNum
		{
			get
			{
				float sum = 0;

				try
				{
					foreach (var testItem in TestSuitesList)
					{
						sum += testItem.Time;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					sum = 0;
				}
				return sum;
			}
		}
	}
}
