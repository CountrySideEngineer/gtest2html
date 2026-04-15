using gtest2html.Page.Css.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace gtest2html.Page.Css.Generator
{
    /// <summary>
    /// Generates CSS content from a T4 template.
    /// The generator returns the generated CSS as a string. Subclasses may
    /// extend the behavior to persist the output to disk.
    /// </summary>
    public class CssGenerator : IPageGenerator<DirectoryInfo, string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CssGenerator"/> class.
        /// This constructor performs no special initialization and is provided
        /// for extensibility by subclasses.
        /// </summary>
        public CssGenerator() { }

        /// <summary>
        /// Generate CSS content using the embedded T4 template.
        /// </summary>
        /// <param name="src">The source directory (not used by the default implementation).</param>
        /// <returns>The generated CSS content as a UTF-8 string.</returns>
        public virtual string Generate(DirectoryInfo src)
        {
            var cssTemplate = new CssTemplate();
            var content = cssTemplate.TransformText();

            return content;
        }
    }
}
