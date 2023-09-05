using QuestionarreIteratorCompositeV2.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionarreIteratorCompositeV2.Interfaces
{
    public interface IIterator
    {
        public bool HasNext();
        public Selection GetNext();
    }
}
