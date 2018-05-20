using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgu.StudentTesting.BLL.Contracts
{
    public interface IQuestionLogic
    {
        void AddQuestion(Question question);
        IEnumerable<Question> GetQuestionsByAuthor(int author);
        IEnumerable<Question> GetQuestionsByTheme(int idsubject, int theme);
        Question GetQuestionById(int questionId);
        void Update(Question question);
        void Accepted(int id);
        void DeleteById(int idQuestion);
        IEnumerable<Question> ListNewQuestion();
    }
}
