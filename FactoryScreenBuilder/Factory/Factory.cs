using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryScreenBuilder.Factory
{
    public static class Factory
    {
        public static IFactory GetFactory(FactoryType type)
        {
            IFactory factory = null;
            switch(type)
            {
                case FactoryType.HTML:
                    factory = new FactoryHTML();
                    break;
                case FactoryType.JSON:
                    factory = new FactoryJSON();
                    break;
                default:
                    break;
            }
            return factory;
        }
    }
}
