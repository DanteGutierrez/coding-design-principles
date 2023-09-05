using QuestionarreIteratorCompositeV2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionarreIteratorCompositeV2.Abstracts
{
    public abstract class Selection
    {
        protected string Label;
        protected List<Selection> Children;
        public Selection(string label, List<Selection> children)
        {
            Label = label;
            Children = children;
        }
        public int Count()
        {
            if (Children == null) return -1;
            return Children.Count;
        }
        public Selection Select(int index)
        {
            if (index < 0 || index > Children.Count) return null;
            return Children[index];
        }
        public string GetLabel()
        {
            return Label;
        }
        public virtual bool IsCorrect(string input)
        {
            return false;
        }
        public abstract string GetFullPrint();
        public virtual IIterator GetIterator()
        {
            return new PromptIterator(this);
        }
    }
}
