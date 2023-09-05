using QuestionarreIteratorCompositeV2.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionarreIteratorCompositeV2
{
    public class Prompt : Selection
    {
        public Prompt(string label, List<Selection> choices) : base(label, choices) { }
        public override string GetFullPrint()
        {
            StringBuilder sb = new();
            sb.Append(Label + '\n');
            return sb.ToString();
        }
    }
}
