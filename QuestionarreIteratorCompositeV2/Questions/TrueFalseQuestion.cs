using QuestionarreIteratorCompositeV2.Abstracts;
using QuestionarreIteratorCompositeV2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionarreIteratorCompositeV2.Questions
{
    public class TrueFalseQuestion : Selection
    {
        private bool CorrectChoice;
        public TrueFalseQuestion(string label, List<Selection> choices, bool correctChoice) : base(label, choices)
        {
            CorrectChoice = correctChoice;
        }

        public override string GetFullPrint()
        {
            StringBuilder sb = new();
            sb.Append("True or False: ");
            sb.Append(Label + '\n');
            for (int i = 0; i < Children.Count; i++)
            {
                sb.Append((i % 2 == 0 ? "true" : "false") + ") ");
                sb.Append(Children[i].GetLabel() + '\n');
            }
            return sb.ToString();
        }
        public override bool IsCorrect(string input)
        {
            if (bool.TryParse(input, out bool refinedInput))
            {
                return refinedInput == CorrectChoice;
            }
            return false;
        }
        public override IIterator GetIterator()
        {
            return new QuestionIterator(this);
        }
    }
}
