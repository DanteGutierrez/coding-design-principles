using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FactoryScreenBuilder.Factory
{
    public interface IFactory
    {
        bool Build(string filename, List<Control> controls);
        List<Control> Read(string filename);
    }
}
