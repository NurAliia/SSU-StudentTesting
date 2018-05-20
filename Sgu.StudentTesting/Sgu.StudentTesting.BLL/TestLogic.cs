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
    public class TestLogic : ITestLogic
    {
        #region [Fierlds]

        private readonly ITestDao _testDao;
        private readonly ISubjectDao _subjectDao;
        public List<Question> testList;
        
        #endregion [Fierlds]

        #region [Ctor]
        public TestLogic(ITestDao testDao, ISubjectDao subjectDao)
        {
            _testDao = testDao;
            _subjectDao = subjectDao;
        }

        public void Initialization(int idSubject)
        {
            testList = new List<Question>(_subjectDao.GetQuestionBySubject(idSubject));
        }

        public Question NewQuestion()
        {
            var a = testList.First();
            testList.RemoveAt(1);
            if (testList.Count > 0)
            {
                return a;
            }
            else
            {
                return null;
            }
        }

        #endregion	[/Ctor]

        public void AddTest(Test test)
        {
            _testDao.AddTest(test);
        }
        public IEnumerable<Test> GetTestsStudent(int studentId)
        {
            return _testDao.GetTestsStudent(studentId).ToList();
        }
        public IEnumerable<Test> GetStudentsBySubjectTest(int subjectId)
        {
            return _testDao.GetStudentsBySubjectTest(subjectId);
        }
        public IEnumerable<QuestionInTest> GetQuestionInTestBySubject(int idTest)
        {
            return _testDao.GetQuestionInTestBySubject(idTest);
        }
    }
}
