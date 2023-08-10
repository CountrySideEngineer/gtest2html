using gtest2html.Converter.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace gtest2html
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Count() < 2)
			{
				Console.WriteLine("2 arguments are needed.");
				Console.WriteLine("1st : Path to directory to output result HTML.");
				Console.WriteLine("2nd : Path to directory contains the test result xml files.");

				return;
			}

			string outputDirPath = args[0];
			string xmlDirPath = args[1];

			try
			{
				DirectoryInfo outputDirInfo = CreateOutputDirInfo(outputDirPath);
				IEnumerable<FileInfo> xmlFiles = GetXmlFilePaths(xmlDirPath);
				var xml2Html = new TestXml2Html(outputDirInfo);
				xml2Html.Convert(xmlFiles);
			}
			catch (Exception ex)
			when (ex is ArgumentException)
			{
				Console.WriteLine(ex.Message);
			}

			return;
		}

		/// <summary>
		/// Returns the list of file information contained in direcotry specified by argument
		/// dirPath.
		/// </summary>
		/// <param name="dirPath">Path to directory contains result of test in XML format.</param>
		/// <returns>List of test result XML file information.</returns>
		/// <exception cref="ArgumentException"></exception>
		private static IEnumerable<FileInfo> GetXmlFilePaths(string dirPath)
		{
			if (File.Exists(dirPath))
			{
				throw new ArgumentException("The path is not directory.");
			}
			else if (!Directory.Exists(dirPath))
			{
				throw new ArgumentException("The directory has not existed.");
			}
			else
			{
				try
				{
					var dirInfo = new DirectoryInfo(dirPath);
					var fileInfos = dirInfo.GetFiles("*.xml", SearchOption.AllDirectories).ToList();

					return fileInfos;
				}
				catch (System.Security.SecurityException)
				{
					throw new ArgumentException("The directory can not accss.");
				}
				catch (ArgumentNullException)
				{
					throw new ArgumentException("No xml file found in the directory");
				}
			}
		}

		/// <summary>
		/// Create directory information object about output directory.
		/// </summary>
		/// <param name="dirPath">Path to output html result.</param>
		/// <returns>Directory information of output directory.</returns>
		/// <exception cref="ArgumentException"></exception>
		private static DirectoryInfo CreateOutputDirInfo(string dirPath)
		{
			//If the path specified by argument dirPath mean file, it is invalid.
			if (File.Exists(dirPath)) {
				throw new ArgumentException("The path has already existed.");
			}
			try
			{
				if (!Directory.Exists(dirPath))
				{
					Directory.CreateDirectory(dirPath);
				}

				var dirInfo = new DirectoryInfo(dirPath);
				return dirInfo;
			}
			catch (Exception ex)
			when ((ex is PathTooLongException) ||
				(ex is IOException) ||
				(ex is UnauthorizedAccessException))
			{
				throw new ArgumentException("The output directory path is invalid.");
			}
		}
	}
}
