using Sgu.StudentTesting.BLL;
using Sgu.StudentTesting.BLL.Contracts;
using Ninject;
using Sgu.StudentTesting.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sgu.StudentTesting.DAL.Contracts;

namespace Sgu.StudentTesting.Config
{
    public static class Config
    {
        public static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUserLogic>().To<UserLogic>();
            kernel.Bind<IUserDao>().To<UserDao>();


            kernel.Bind<IQuestionLogic>().To<QuestionLogic>().InSingletonScope();
            kernel.Bind<IQuestionDao>().To<QuestionDao>().InSingletonScope();

            kernel.Bind<ISubjectLogic>().To<SubjectLogic>().InSingletonScope();
            kernel.Bind<ISubjectDao>().To<SubjectDao>().InSingletonScope();

            kernel.Bind<ITestLogic>().To<TestLogic>().InSingletonScope();
            kernel.Bind<ITestDao>().To<TestDao>().InSingletonScope();
        }
    }
}
