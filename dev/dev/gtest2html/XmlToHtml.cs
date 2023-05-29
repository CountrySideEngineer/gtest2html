using gtest2html.Page;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace gtest2html
{
	public class XmlToHtml
	{
		#region Public Properties
		/// <summary>
		///	Output directory information.
		/// </summary>
		public DirectoryInfo OutputDirInfo;

		/// <summary>
		/// List of test resutl xml files.
		/// </summary>
		public IEnumerable<FileInfo> XmlFileInfos;
		#endregion

		#region Constructor and destructor(Finalizer)
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="outputDir">Path to output report.</param>
		/// <param name="xmlFilePathList">List of file path to result of test in xml format.</param>
		public XmlToHtml(DirectoryInfo outputDir, IEnumerable<FileInfo> xmlFileInfos)
		{
			OutputDirInfo = outputDir;
			XmlFileInfos = xmlFileInfos;
		}
		#endregion

		#region Other methods and private properties in calling order
		/// <summary>
		/// Run convert.
		/// </summary>
		public void Convert()
		{
			var pageGenerator = new TestReportPageGenerator(OutputDirInfo);
			pageGenerator.Generate(XmlFileInfos);

			var indexGenerator = new IndexPageGenerator(OutputDirInfo);
			indexGenerator.Generate(XmlFileInfos);

			var errorReportGenerator = new ErrorReportPageGenerator(OutputDirInfo);
			errorReportGenerator.Generate(XmlFileInfos);
		}
		#endregion
	}
}
