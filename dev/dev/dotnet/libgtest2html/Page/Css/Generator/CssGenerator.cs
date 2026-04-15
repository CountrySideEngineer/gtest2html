using gtest2html.Page.Css.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace gtest2html.Page.Css.Generator
{
    public class CssGenerator : IPageGenerator<DirectoryInfo, string>
    {
        public CssGenerator() { }

        public virtual string Generate(DirectoryInfo src)
        {
            var cssTemplate = new CssTemplate();
            var content = cssTemplate.TransformText();

            return content;




            throw new NotImplementedException();
        }
    }
}
