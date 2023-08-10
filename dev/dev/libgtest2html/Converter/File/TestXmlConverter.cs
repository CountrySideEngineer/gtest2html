using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace gtest2html.Converter.File
{
	using Logger = gtest2html.Log;

	internal class TestXmlConverter : IXmlConverter<FileInfo, TestSuites>
	{
		XmlSerializer _serializer = new XmlSerializer(typeof(TestSuites));

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TestXmlConverter() { }

		public IEnumerable<TestSuites> Convert(IEnumerable<FileInfo> src)
		{
			try
			{
				var collection = new List<TestSuites>();
				foreach (var srcItem in src)
				{
					try
					{
						Logger.INFO($"Start reading {srcItem.Name}");

						TestSuites item = Convert(srcItem);
						collection.Add(item);
					}
					catch (InvalidOperationException ex)
					{
						Logger.WARN(ex.Message);
						Logger.WARN($"Skip {srcItem.Name} reading.");
					}
				}
				return collection;
			}
			catch (Exception ex)
			when ((ex is ArgumentException) || (ex is NullReferenceException))
			{
				Logger.FATAL("Input file information error!");

				throw;
			}
		}

		/// <summary>
		/// Convert XML file into TestSuites object.
		/// </summary>
		/// <param name="src">FileInfo object of XML file to be converted.</param>
		/// <returns>TestSuites object oconverted from XML file.</returns>
		/// <exception cref="InvalidOperationException"></exception>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="NullReferenceException"></exception>
		public TestSuites Convert(FileInfo src)
		{
			try
			{
				using (var stream = new StreamReader(src.FullName, Encoding.UTF8))
				{
					TestSuites suites = GetTestSuites(stream);
					suites.TestName = System.IO.Path.GetFileNameWithoutExtension(src.FullName);
					return suites;
				}
			}
			catch (InvalidOperationException)
			{
				throw;
			}
			catch (Exception ex)
			when ((ex is ArgumentException) || (ex is NullReferenceException))
			{
				throw;
			}
		}

		/// <summary>
		/// Get TestSuites object from reader.
		/// </summary>
		/// <param name="reader">Reader to read from stream from XML file.</param>
		/// <returns>TestSuites object read from stream.</returns>
		/// <exception cref="InvalidOperationException"></exception>
		protected TestSuites GetTestSuites(StreamReader reader)
		{
			try
			{
				TestSuites suites = (TestSuites)_serializer.Deserialize(reader);
				return suites;
			}
			catch (Exception ex)
			when ((ex is InvalidOperationException) || (ex is InvalidCastException))
			{
				string message = "Read and convert XML file failed : Input XML format is invalid.";
				throw new InvalidOperationException(message);
			}
		}
	}
}
