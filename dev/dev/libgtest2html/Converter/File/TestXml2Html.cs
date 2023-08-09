using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using gtest2html;
using gtest2html.Converter.Suites;

namespace gtest2html.Converter.File
{
	public class TestXml2Html : IXml2Html<FileInfo>
	{
		public DirectoryInfo OutputDir { get; protected set; }

		/// <summary>
		/// Serializer to convert XML to TestSuites object.
		/// </summary>
		XmlSerializer _serializer = new XmlSerializer(typeof(TestSuites));

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
		
		/// <summary>
		/// Convert XML files about test result into HTML files.
		/// </summary>
		/// <param name="sources">Collection of test result XML file to be converted.</param>
		public void Convert(IEnumerable<FileInfo> sources)
		{
			IEnumerable<TestSuites> suitesCollection = XmlToTestSuites(sources);
			Convert(suitesCollection);
		}

		/// <summary>
		/// Convert XML file about test result into HTML file.
		/// </summary>
		/// <param name="source">Test result XML file to be converted.</param>
		public void Convert(FileInfo source)
		{
			TestSuites suites = XmlToTestSuites(source);
			var suitesCollection = new List<TestSuites>
			{
				suites
			};
			Convert(suitesCollection);
		}

		/// <summary>
		/// Convert collection of TestSuites object into HTML files.
		/// </summary>
		/// <param name="suitesCollection">Collection of TestSuites object to be converted into HTML.</param>
		public void Convert(IEnumerable<TestSuites> suitesCollection)
		{
			var converters = new List<ATestSuites2Html>()
			{
				new TestSuites2IndexHtml(OutputDir),
				new TestSuites2TestIndexHtml(OutputDir),
				new TestSuites2TestMessageHtml(OutputDir),
			};
			foreach (var converter in converters)
			{
				Convert(suitesCollection, converter);
			}
		}

		/// <summary>
		/// Convert TestSuites object into HTML file using converter.
		/// </summary>
		/// <param name="suitesCollection">Collection of TestSuites objects to be converted into HTML file.</param>
		/// <param name="converter">A converter derived from ATestSuites2HTML to use to convert TestSuites object.</param>
		internal void Convert(IEnumerable<TestSuites> suitesCollection, ATestSuites2Html converter)
		{
			converter.Convert(suitesCollection);
		}

		/// <summary>
		/// Convert XML file into collection of TestSuites object.
		/// </summary>
		/// <param name="xmlFiles">Collection of test result XML file to be converted.</param>
		/// <returns></returns>
		protected IEnumerable<TestSuites> XmlToTestSuites(IEnumerable<FileInfo> xmlFiles)
		{
			List<TestSuites> suitesCollection = new List<TestSuites>();
			foreach (var xmlFile in xmlFiles)
			{
				TestSuites suites = XmlToTestSuites(xmlFile);
				suitesCollection.Add(suites);
			}
			return suitesCollection;
		}

		/// <summary>
		/// Convert XML file into TestSuites object.
		/// </summary>
		/// <param name="xmlFile">XML file information to be converted.</param>
		/// <returns>Converted TestSuites object.</returns>
		protected TestSuites XmlToTestSuites(FileInfo xmlFile)
		{
			try
			{
				using (var stream = new StreamReader(xmlFile.FullName, Encoding.UTF8))
				{
					TestSuites suites = GetTestSuites(stream);
					suites.TestName = System.IO.Path.GetFileNameWithoutExtension(xmlFile.FullName);
					return suites;
				}
			}
			catch (ArgumentException)
			{
				string message = "Input XML file can not convert";
				throw new ArgumentException(message);
			}
			catch (InvalidCastException)
			{
				throw;
			}
		}

		/// <summary>
		/// Get TestSuites object from reader.
		/// </summary>
		/// <param name="reader">Reader to read from stream from XML file.</param>
		/// <returns>TestSuites object read from stream.</returns>
		protected TestSuites GetTestSuites(StreamReader reader)
		{
			try
			{
				TestSuites suites = (TestSuites)_serializer.Deserialize(reader);
				return suites;
			}
			catch (InvalidCastException)
			{
				string message = "Input xml XML file format is invalid.";
				throw new InvalidCastException(message);
			}
		}
	}
}
