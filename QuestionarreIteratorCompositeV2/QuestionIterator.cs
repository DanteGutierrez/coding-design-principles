using QuestionarreIteratorCompositeV2.Abstracts;
using QuestionarreIteratorCompositeV2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionarreIteratorCompositeV2
{
    class QuestionIterator : IIterator
    {
        private Selection Parent;
        private int used = 0;
        public QuestionIterator(Selection parent)
        {
            Parent = parent;
        }
        public Selection GetNext()
        {
            // Since the Question is my 'end point node,
            // I dont need to check its children as they are just answers
            used++;
            return Parent;
        }
        public bool HasNext()
        {
            // I check to see if it has printed in the past,
            // and if it has then it cannot print again
            return used <= 0;
        }
    }
}
