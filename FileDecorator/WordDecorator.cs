using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDecorator
{
    public class WordDecorator : File, IFileComponent
    {
        private string content = "";
        public WordDecorator(IFileComponent component, string content) : base(component)
        {
            this.content = content;
        }
        public string GetFile()
        {
            if (Component == null) return content;
            return Component.GetFile() + content;
        }
    }
}
