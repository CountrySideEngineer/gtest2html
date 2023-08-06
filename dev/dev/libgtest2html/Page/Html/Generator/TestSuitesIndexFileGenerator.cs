using gtest2html.Page.Html.Template;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Page.Html.Generator
{
	internal class TestSuitesIndexFileGenerator : TestSuitesIndexPageGenerator
	{
		public static string FileName = "index";
		public static string FileNameWithExtention = $"{FileName}.html";

		/// <summary>
		/// Page HTML file output directory information
		/// </summary>
		public DirectoryInfo  OutputRootDir { get; set; }

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TestSuitesIndexFileGenerator() : base()
		{
			OutputRootDir = null;
		}

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="outputDir">Output root directory information.</param>
		public TestSuitesIndexFileGenerator(DirectoryInfo outputDir) : base()
		{
			OutputRootDir = outputDir;
		}

		/// <summary>
		/// Generate test suites HTML file.
		/// </summary>
		/// <param name="src">Source of TestSuites object.</param>
		/// <returns>Content of top page of the test.</returns>
		public override string Generate(TestSuites src)
		{
			var template = new TestSuitesIndexHtmlTemplate(src);
			string content = template.TransformText();

			DirectoryInfo outputDir = GetOutputDirectoryInfo(src);

			Generate(outputDir, content);

			return content;
		}

		/// <summary>
		/// Generate HTML file.
		/// </summary>
		/// <param name="outputDir">DirectoryInfo object about the HTML will be output.</param>
		/// <param name="content">Content of the HTML page.</param>
		protected virtual void Generate(DirectoryInfo outputDir, string content)
		{
			//Create outptu directory if the directory does not exist.
			if (!System.IO.Directory.Exists(outputDir.FullName))
			{
				OutputRootDir.Create();
			}

			//Setup output file path.
			string outputPath = $@"{outputDir.FullName}\{FileNameWithExtention}";
			using (var stream = new StreamWriter(outputPath, false, Encoding.UTF8))
			{
				stream.Write(content);
			}
		}

		/// <summary>
		/// Get output directory information the file to be output.
		/// </summary>
		/// <param name="src">TestSuites object of the test.</param>
		/// <returns>DirectoryInfo object the HTML page will be generated.</returns>
		protected virtual DirectoryInfo GetOutputDirectoryInfo(TestSuites src)
		{
			string xmlFileName = System.IO.Path.GetFileNameWithoutExtension(src.XmlFilePath);
			string outputDirPath = $@"{OutputRootDir.FullName}\{xmlFileName}\";
			DirectoryInfo outputDir = new DirectoryInfo(outputDirPath);

			return outputDir;
		}
	}
}
