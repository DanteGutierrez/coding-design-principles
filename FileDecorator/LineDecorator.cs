using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileDecorator
{
    public class LineDecorator : File, IFileComponent
    {
        public LineDecorator(IFileComponent component) : base (component)
        {
        }

        public string GetFile()
        {
            if (Component == null) return "";
            string tempString = Component.GetFile();
            if(tempString.Contains("\r\n"))
            {
                Console.WriteLine("Windows > Unix");
                return tempString.Replace("\r\n", "\n");
            }
            else if(tempString.Contains("\n"))
            {
                Console.WriteLine("Unix > Windows");
                return tempString.Replace("\n", "\r\n");
            }
            else return tempString;
        }
    }
}
