using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using gtest2html;

namespace gtest2html.Converter.File
{
	internal abstract class TestXml2Html : IXml2Html<FileInfo>
	{
		public DirectoryInfo OutputDir { get; protected set; }

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TestXml2Html()
		{
			string location = Assembly.GetEntryAssembly().Location;
			OutputDir = System.IO.Directory.GetParent(location);
		}

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="outputDir">Output directory information.</param>
		public TestXml2Html(DirectoryInfo outputDir)
		{
			OutputDir = outputDir;
		}

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="sources">Path to directory to output.</param>
		public TestXml2Html(string outputDir)
		{
			OutputDir = new DirectoryInfo(outputDir);
		}

		public abstract void Convert(IEnumerable<FileInfo> sources);

		public abstract void Convert(FileInfo source);
	}
}
