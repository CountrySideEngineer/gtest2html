using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Page.Html.Generator
{
	internal class TopIndexFileGenerator : TopIndexPageGenerator
	{
		public static string FileName = "index";
		public static string FileNameWithExtention = $"{FileName}.html";

		/// <summary>
		/// Page HTML file output directory information.
		/// </summary>
		public DirectoryInfo OutputDir { get; set; }

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TopIndexFileGenerator() : base()
		{
			OutputDir = null;
		}

		/// <summary>
		/// Constructor withh argument.
		/// </summary>
		/// <param name="outputDir"></param>
		public TopIndexFileGenerator(DirectoryInfo outputDir) : base()
		{
			OutputDir = outputDir;
		}

		/// <summary>
		/// Generate top index HTML page from collection fo TestSuites object.
		/// </summary>
		/// <param name="src">Collection of TestSuites to be converted.</param>
		/// <returns></returns>
		public override string Generate(IEnumerable<TestSuites> src)
		{
			string content = base.Generate(src);

			Generate(content);

			return content;
		}

		/// <summary>
		/// Generate top index HTML file.
		/// </summary>
		/// <param name="content">Content of index.html</param>
		protected virtual void Generate(string content)
		{
			string filePath = $@"{OutputDir.FullName}\{FileName}";
			using (var stream = new StreamWriter(filePath, false, Encoding.UTF8))
			{
				stream.Write(content);
			}
		}
	}
}
