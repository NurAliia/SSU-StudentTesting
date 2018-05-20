using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgu.StudentTesting.DAL.Contracts
{
    public interface ITestDao
    {
        void AddTest(Test test);
        IEnumerable<Test> GetStudentsBySubjectTest(int subjectId);
        IEnumerable<QuestionInTest> GetQuestionInTestBySubject(int IdTest);
        IEnumerable<Test> GetTestsStudent(int studentId);
    }
}
