using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Question
    {
        public int Id { get; set; }

        public int IdSubject { get; set; }

        public string Author { get; set; }

        public DateTime Date { get; set; }

        public string Text { get; set; }

        public string VariantsOfAnswer { get; set; }

        public int Theme {get; set; }

        public int Complexity { get; set; }

        public int Score { get; set; }

        public string CorrectAnswer { get; set; }

        public bool Accepted { get; set; }

        
        public Question()
        {
        }
        public string GetDataVariantsOfAnswer(Question question, int i)
        {
            string[] VariantsOfAnswer = new string[3];
            VariantsOfAnswer = question.VariantsOfAnswer.Split(':');
            return VariantsOfAnswer[i];
        }
    }
}
