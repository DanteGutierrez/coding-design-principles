using QuestionarreIteratorCompositeV2.Abstracts;
using QuestionarreIteratorCompositeV2.Interfaces;
using QuestionarreIteratorCompositeV2.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionarreIteratorCompositeV2
{
    public class Quiz
    {
        private Prompt quiz;
        private int score = 0;
        public Quiz()
        {
            GenerateData();

            // Run the quiz
            Run(quiz);

            // Results
            Console.WriteLine("You ended with " + score + " point(s)!");
        }
        public void Run(Selection selection)
        {
            // Starts from quiz entry
            IIterator iterator = selection.GetIterator();
            while(iterator.HasNext())
            {

                // Grab the current iterator that the quiz is at
                Selection next = iterator.GetNext();

                // Make sure we dont break the code if there is
                // an improper object in iterator list
                if (next != null)
                {
                    // Print the text of that iterator
                    Console.WriteLine(next.GetFullPrint());

                    // Take in user input and score it
                    string input = Console.ReadLine();

                    bool correct = next.IsCorrect(input);

                    score += correct ? 1 : 0;
                }
            }
        }

        private void GenerateData()
        {
            List<Prompt> answers = new();
            List<Selection> questions = new();
            List<Prompt> categories = new();
            // Category: Life
            // How many days were in the year 2000?
            answers.Add(new ("365", null));
            answers.Add(new ("366", null));
            answers.Add(new("dunno", null));
            answers.Add(new("365", null));

            questions.Add(new AlphabetQuestion("How many days were in the year 2000?", new(answers.ToArray()), 'a'));

            answers.Clear();

            // How old is the universe?
            answers.Add(new("pretty old", null));
            answers.Add(new("at least 2 days", null));
            answers.Add(new("a lot", null));
            answers.Add(new("not as old as your mom", null));
            answers.Add(new("banana", null));

            questions.Add(new NumberedQuestion("How old is the universe?", new(answers.ToArray()), 1));

            answers.Clear();

            //Water is wet
            answers.Add(new("true", null));
            answers.Add(new("false", null));

            questions.Add(new TrueFalseQuestion("Water is wet", new(answers.ToArray()), true));

            // IMPROPER FORMAT CHECK
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            questions.Add(new Prompt("CODE BREAKER", null));
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            categories.Add(new("Life:", new(questions.ToArray())));

            answers.Clear();
            questions.Clear();

            //Category: Math
            //1 + 1 = 2

            answers.Add(new("correct", null));
            answers.Add(new("incorrect", null));

            questions.Add(new TrueFalseQuestion("1 + 1 = 2", new(answers.ToArray()), false));

            answers.Clear();

            //(2 ^ 2) + 1
            answers.Add(new("10", null));
            answers.Add(new("2", null));
            answers.Add(new("4", null));
            answers.Add(new("6", null));
            answers.Add(new("8", null));
            answers.Add(new("1", null));
            answers.Add(new("3", null));
            answers.Add(new("5", null));
            answers.Add(new("7", null));
            answers.Add(new("9", null));

            questions.Add(new NumberedQuestion("(2 ^ 2) + 1 = ?", new(answers.ToArray()), 9));

            answers.Clear();

            //round(7 * 8)
            answers.Add(new("100", null));
            answers.Add(new("20", null));
            answers.Add(new("40", null));
            answers.Add(new("60", null));
            answers.Add(new("80", null));

            questions.Add(new AlphabetQuestion("round(7 * 8)", new(answers.ToArray()), 'd'));

            categories.Add(new("Math:", new(questions.ToArray())));

            answers.Clear();
            questions.Clear();

            quiz = new Prompt("------------------------ THE QUIZ ------------------------", new(categories.ToArray()));
        }
    }
}
