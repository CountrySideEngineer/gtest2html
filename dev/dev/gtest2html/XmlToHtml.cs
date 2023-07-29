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

		IEnumerable<AReportPageFileGenerator> _generatorCollection;
		#endregion

		#region Constructor and destructor(Finalizer)
		/// <summary>
		/// Constructor with argument about output root directory.
		/// </summary>
		/// <param name="outputDir">Output directory information.</param>
		public XmlToHtml(DirectoryInfo outputDir)
		{
			OutputDirInfo = outputDir;
			XmlFileInfos = null;

			SetupPageFileGenerator();
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="outputDir">Path to output report.</param>
		/// <param name="xmlFilePathList">List of file path to result of test in xml format.</param>
		public XmlToHtml(DirectoryInfo outputDir, IEnumerable<FileInfo> xmlFileInfos)
		{
			OutputDirInfo = outputDir;
			XmlFileInfos = xmlFileInfos;

			SetupPageFileGenerator();
		}
		#endregion

		#region Other methods and private properties in calling order
		/// <summary>
		/// Run convert.
		/// </summary>
		public void Convert()
		{
			Convert(XmlFileInfos);
		}
		#endregion

		/// <summary>
		/// Run convert xml file into HTML file.
		/// </summary>
		/// <param name="xmlFileInfos">Collection of XML file information to be converted.</param>
		public void Convert(IEnumerable<FileInfo> xmlFileInfos)
		{
			try
			{
				foreach (var generator in _generatorCollection)
				{
					Convert(xmlFileInfos, generator);
				}
			}
			catch (Exception ex)
			{
				Console.Write(ex.Message);
			}
		}

		/// <summary>
		/// Run convert xml file into HTML file.
		/// </summary>
		/// <param name="fileInfos">Collection of XML file information to be converted.</param>
		/// <param name="generator">HTML page generator.</param>
		protected void Convert(IEnumerable<FileInfo> fileInfos, AReportPageFileGenerator generator)
		{
			generator.Generate(fileInfos);
		}

		/// <summary>
		/// Setup page generator object.
		/// </summary>
		protected void SetupPageFileGenerator()
		{
			var generatorCollection = new List<AReportPageFileGenerator>();
			generatorCollection.Add(new TestReportPageGenerator(OutputDirInfo));
			generatorCollection.Add(new IndexPageGenerator(OutputDirInfo));
			generatorCollection.Add(new ErrorReportPageGenerator(OutputDirInfo));

			_generatorCollection = generatorCollection;
		}
	}
}
