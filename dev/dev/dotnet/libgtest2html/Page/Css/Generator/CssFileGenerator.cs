using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace gtest2html.Page.Css.Generator
{
    public class CssFileGenerator : CssGenerator
    {
        /// <summary>
        /// Base name for the generated CSS file (without extension).
        /// </summary>
        public static string FileName = "report";

        /// <summary>
        /// File name including the CSS extension.
        /// </summary>
        public static string FileNameWithExtention = $"{FileName}.css";

        /// <summary>
        /// Generate the CSS content using the base generator and write it to disk.
        /// Returns the generated content for further use.
        /// </summary>
        /// <param name="outputDir">Directory where the CSS file will be written.</param>
        public override string Generate(DirectoryInfo outputDir)
        {
            string content = base.Generate(outputDir);

            Generate(content, outputDir);
            return content;
        }

        /// <summary>
        /// Writes the provided CSS content into a file inside the specified output directory.
        /// This method is protected and virtual so subclasses can override how the file is persisted.
        /// </summary>
        /// <param name="content">The CSS content to write.</param>
        /// <param name="outputDir">The directory to write the file into.</param>
        protected virtual void Generate(string content, DirectoryInfo outputDir)
        {
            string filePath = $@"{outputDir.FullName}\{FileNameWithExtention}";
            using (var stream = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                stream.Write(content);
            }
        }
    }
}
