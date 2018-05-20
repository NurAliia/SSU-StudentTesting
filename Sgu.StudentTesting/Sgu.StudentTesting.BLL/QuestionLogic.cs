using Common;
using Sgu.StudentTesting.BLL.Contracts;
using Sgu.StudentTesting.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgu.StudentTesting.BLL
{
    public class QuestionLogic: IQuestionLogic
    {
        #region [Fierlds]

        private readonly IQuestionDao _questionDao;
        #endregion [Fierlds]

        #region [Ctor]
        public QuestionLogic(IQuestionDao questionDao)
        {
            _questionDao = questionDao;
        }

        #endregion	[/Ctor]

        #region [Method]
        public void AddQuestion(Question question)
        {
            _questionDao.AddQuestion(question);
        }
        public IEnumerable<Question> GetQuestionsByAuthor(int author)
        {
            return _questionDao.GetQuestionsByAuthor(author).ToList();
        }
        public IEnumerable<Question> GetQuestionsByTheme(int idsubject, int theme)
        {
            return _questionDao.GetQuestionsByTheme(idsubject, theme).ToList();
        }
        public Question GetQuestionById(int questionId)
        {
            try
            {
                return this._questionDao.GetQuestionById(questionId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Update(Question question)
        {
            _questionDao.Update(question);
        }
        public void Accepted(int id)
        {
           _questionDao.Accepted(id);
        }
        public void DeleteById(int idQuestion)
        {
            _questionDao.DeleteById(idQuestion);
        }
        public IEnumerable<Question> ListNewQuestion()
        {
            return _questionDao.ListNewQuestion();
        }
        
        #endregion[/Method]
    }
}
