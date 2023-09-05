using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDecorator
{
    public abstract class File
    {
        protected IFileComponent Component { get; set; }
        public File(IFileComponent component)
        {
            this.Component = component;
        }
    }
}
