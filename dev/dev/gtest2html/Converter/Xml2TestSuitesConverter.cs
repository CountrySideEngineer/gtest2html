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
		/// <summary>
		/// Serializer to convert XML to TestSuites object.
		/// </summary>
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
		/// <exception cref="ArgumentException"></exception>
		public TestSuites Convert(FileInfo src)
		{
			try
			{
				string testName = Path.GetFileNameWithoutExtension(src.FullName);
				using (var reader = new StreamReader(src.FullName, Encoding.GetEncoding("UTF-8")))
				{
					TestSuites suites = Deserialize(reader);
					suites.TestName = testName;
					return suites;
				}
			}
			catch (ArgumentException)
			{
				string message = "Input XML file can not convert.";
				throw new ArgumentException(message);
			}
			catch (InvalidOperationException ex)
			{
				throw new ArgumentException(ex.Message);
			}
		}

		/// <summary>
		/// Deserialize reader into TestSuite object.
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		/// <exception cref="InvalidOperationException"></exception>
		protected virtual TestSuites Deserialize(StreamReader reader)
		{
			try
			{
				TestSuites suite = (TestSuites)_serializer.Deserialize(reader);
				return suite;
			}
			catch (InvalidOperationException)
			{
				string message = "Input XML file format is invalid.";
				throw new InvalidOperationException(message);

			}
		}
	}
}
