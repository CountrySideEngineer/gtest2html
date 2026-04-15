using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtest2html.Page.Css.Generator
{
    public class CssFileGenerator : CssGenerator
    {
        public static string FileName = "report";
        public static string FileNameWithExtention = $"{FileName}.css";

        public override string Generate(DirectoryInfo outputDir)
        {
            string content = base.Generate(outputDir);

            Generate(content, outputDir);
            return content;
        }

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
