using System;
using System.Collections.Generic;
using Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgu.StudentTesting.DAL.Contracts
{
    public interface IQuestionDao
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
