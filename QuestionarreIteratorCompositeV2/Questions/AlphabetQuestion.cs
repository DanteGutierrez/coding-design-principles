using QuestionarreIteratorCompositeV2.Abstracts;
using QuestionarreIteratorCompositeV2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionarreIteratorCompositeV2.Questions
{
    public class AlphabetQuestion : Selection
    {
        public static readonly List<char> ALPHABET = new() { 'a', 'b', 'c', 'd', 'e', 'f' };
        private char CorrectChoice;
        public AlphabetQuestion(string label, List<Selection> choices, char correctChoice) : base(label, choices)
        {
            CorrectChoice = correctChoice;
        }

        public override string GetFullPrint()
        {
            StringBuilder sb = new();
            sb.Append(Label + '\n');
            for (int i = 0; i < Children.Count; i++)
            {
                sb.Append(ALPHABET[i] + ") ");
                sb.Append(Children[i].GetLabel() + '\n');
            }
            return sb.ToString();
        }
        public override bool IsCorrect(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;

            char refinedInput = input.ToLower()[0];
            return refinedInput.Equals(CorrectChoice);
        }
        public override IIterator GetIterator()
        {
            return new QuestionIterator(this);
        }
    }
}
