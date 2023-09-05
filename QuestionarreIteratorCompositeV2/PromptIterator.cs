using QuestionarreIteratorCompositeV2.Abstracts;
using QuestionarreIteratorCompositeV2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionarreIteratorCompositeV2
{
    public class PromptIterator : IIterator
    {
        private Selection Parent;
        private IIterator ChildIterator;
        private int currentIndex = 0;
        private int size = 0;
        public PromptIterator(Selection partner)
        {
            Parent = partner;
            size = partner.Count();
        }
        public Selection GetNext()
        {
            // If this iterator has nothing left to show,
            // It should not return anything
            if (!HasNext()) return null;

            // Fill child node if it is empty
            if(ChildIterator == null)
            {
                ChildIterator = Parent.Select(currentIndex).GetIterator();
                currentIndex++;

                // Returns itself so that the current prompt's text will be displayed
                return Parent;
            }
            else if (ChildIterator.HasNext())
            {
                // Returns the child's next node if it has one
                return ChildIterator.GetNext();
            }
            else
            {
                // If the child does not have a next node,
                // replace it with the next child in line and repeat
                ChildIterator = Parent.Select(currentIndex).GetIterator();
                currentIndex++;
                return GetNext();
            }
        }
        public bool HasNext()
        {
            // This iterator doesnt end when it reaches its last child,
            // it has to make sure its child cant return anything as well.
            bool childNext = false;
            if (ChildIterator != null) childNext = ChildIterator.HasNext();
            return currentIndex < size || childNext;
        }
    }
}
