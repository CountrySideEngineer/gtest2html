using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace gtest2html.Converter
{
	class Xml2TestSuitesConverter : IConverter<FileInfo, TestSuites>
	{
		XmlSerializer _serializer;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public Xml2TestSuitesConverter()
		{
			_serializer = new XmlSerializer(typeof(TestSuites));
		}

		/// <summary>
		/// Convert test suite in XML file into TestSuite object.
		/// </summary>
		/// <param name="src">Test suite XML file information.</param>
		/// <returns>Converted TestSuite object.</returns>
		public TestSuites Convert(FileInfo src)
		{
			using (var reader = new StreamReader(src.FullName, Encoding.GetEncoding("UTF-8")))
			{
				TestSuites suites = Deserialize(reader);
				return suites;
			}
		}

		/// <summary>
		/// Deserialize reader into TestSuite object.
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		protected TestSuites Deserialize(StreamReader reader)
		{
			TestSuites suite = (TestSuites)_serializer.Deserialize(reader);
			return suite;
		}
	}
}
