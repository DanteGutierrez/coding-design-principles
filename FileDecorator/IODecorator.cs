using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDecorator
{
    public class IODecorator : File, IFileComponent
    {
        private string filename = "";
        private bool readwrite = false;
        public IODecorator(IFileComponent component, string filename, bool readwrite) : base(component)
        {
            this.filename = filename;
            this.readwrite = readwrite;
        }
        public string GetFile()
        {
            if(readwrite)
            {
                if (Component == null) return filename + " was not saved";
                StreamWriter sw = new(filename);
                sw.Write(Component.GetFile());
                sw.Close();
                return filename + " was saved.";
            }
            else
            {
                StreamReader sr = new(filename);
                return sr.ReadToEnd();
            }
        }
    }
}
