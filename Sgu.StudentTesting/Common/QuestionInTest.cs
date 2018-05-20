using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class QuestionInTest
    {
        // public int IdTest { get; set; }
        public string Text { get; set; }
        public string VariantsOfAnswers { get; set;}
        public int Answer { get; set; }

        public QuestionInTest()
        { }

        public string GetDataVariantsOfAnswer(QuestionInTest question, int i)
        {
            string[] VariantsOfAnswer = new string[3];
            VariantsOfAnswer = question.VariantsOfAnswers.Split(':');
            return VariantsOfAnswer[i];
        }
    }

}
