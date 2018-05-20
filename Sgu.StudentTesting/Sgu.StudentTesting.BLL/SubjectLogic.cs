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
    public class SubjectLogic : ISubjectLogic
    {
        #region [Fierlds]

        private readonly ISubjectDao _subjectDao;
        #endregion [Fierlds]

        #region [Ctor]
        public SubjectLogic(ISubjectDao subjectDao)
        {
            _subjectDao = subjectDao;
        }

        #endregion	[/Ctor]

        public void AddSubject(Subject subject)
        {
            _subjectDao.AddSubject(subject);
        }
        public Subject GetSubjectById(int id)
        {
            return _subjectDao.GetSubjectById(id);
        }
        public IEnumerable<Question> GetQuestionBySubject(int idSubject)
        {
            return _subjectDao.GetQuestionBySubject(idSubject).ToList();
        }
        public IEnumerable<Subject> GetSubjectsStudent(int direction)
        {
            return _subjectDao.GetSubjectsStudent(direction).ToList();
        }
        public IEnumerable<string> GetListTheme(int idsubject)
        {
            return _subjectDao.GetListTheme(idsubject);
        }
    }
}
