using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace gtest2html.Converter
{
	class Xml2TestSuiteConverter : IConverter<FileInfo, TestSuite>
	{
		XmlSerializer _serializer;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public Xml2TestSuiteConverter()
		{
			_serializer = new XmlSerializer(typeof(TestSuite));
		}

		/// <summary>
		/// Convert test suite in XML file into TestSuite object.
		/// </summary>
		/// <param name="src">Test suite XML file information.</param>
		/// <returns>Converted TestSuite object.</returns>
		public TestSuite Convert(FileInfo src)
		{
			using (var reader = new StreamReader(src.FullName, Encoding.GetEncoding("UTF-8")))
			{
				TestSuite suite = Deserialize(reader);
				return suite;
			}
		}

		/// <summary>
		/// Deserialize reader into TestSuite object.
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		protected TestSuite Deserialize(StreamReader reader)
		{
			TestSuite suite = (TestSuite)_serializer.Deserialize(reader);
			return suite;
		}
	}
}
