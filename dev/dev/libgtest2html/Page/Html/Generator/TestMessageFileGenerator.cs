using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Page.Html.Generator
{
	internal class TestMessageFileGenerator : TestMessagePageGenerator
	{
		/// <summary>
		/// Page HTML file output directory information
		/// </summary>
		public DirectoryInfo OutputRootDir { get; set; }

		protected string _testSuiteName;
		protected string _testCaseName;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TestMessageFileGenerator() : base()
		{
			OutputRootDir = null;
		}

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="outputDir">OUtput root directory information.</param>
		public TestMessageFileGenerator(DirectoryInfo outputDir)
		{
			OutputRootDir = outputDir;
		}

		protected override string Generate(Failure src)
		{
			string content = base.Generate(src);


			return content;
		}

		protected override string Generate(TestSuite src)
		{
			_testSuiteName = src.Name;
			string content = Generate(src);
			return content;
		}

		protected override string Generate(TestCase src)
		{
			_testCaseName = src.Name;
			string content = base.Generate(src);
			return content;
		}

		protected virtual DirectoryInfo GetOutputDirectoryInfo(TestSuites src)
		{
			string xmlFileName = System.IO.Path.GetFileNameWithoutExtension(src.XmlFilePath);
			string outputDirPath = $@"{OutputRootDir.FullName}\{xmlFileName}";
			DirectoryInfo outputDirInfo = new DirectoryInfo(outputDirPath);

			return outputDirInfo;
		}

		protected virtual void Generate(DirectoryInfo outputDir, string content)
		{
			if (!System.IO.Directory.Exists(outputDir.FullName))
			{
				outputDir.Create();
			}

			string outputPath = $@"{outputDir.FullName}\{_testSuiteName}_{_testCaseName}.html";
			using (var stream = new StreamWriter(outputPath, false, Encoding.UTF8))
			{
				stream.Write(content);
			}
		}

	}
}
