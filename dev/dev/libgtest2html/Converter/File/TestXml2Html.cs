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

		public void Convert(IEnumerable<FileInfo> sources)
		{
			IEnumerable<TestSuites> suitesCollection = XmlToTestSuites(sources);
			Convert(suitesCollection);
		}

		public void Convert(FileInfo source)
		{
			TestSuites suites = XmlToTestSuites(source);
			var suitesCollection = new List<TestSuites>
			{
				suites
			};
			Convert(suitesCollection);
		}

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

		internal void Convert(IEnumerable<TestSuites> suitesCollection, ATestSuites2Html converter)
		{
			converter.Convert(suitesCollection);
		}

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
