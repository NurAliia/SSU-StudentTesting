using AutoMapper;
using Common;
using Sgu.StudentTesting.BLL.Contracts;
using Sgu.StudentTesting.PL.ViewModel.Question;
using Sgu.StudentTesting.PL.ViewModel.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sgu.StudentTesting.PL.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestLogic _testLogic;


        public TestController(ITestLogic testLogic)
        {
            _testLogic = testLogic;
        }

        #region General

        // GET: Test
        public ActionResult Index(int id)
        {
            //Берем студента
            var a = Mapper.Map<IEnumerable<Test>, IEnumerable<TestVM>>(this._testLogic.GetTestsStudent(id));
            ViewData["idUser"] = id;
            return this.View(a);
        }
        
        public ActionResult SaveTest(TestVM test) //Принимает пройденный тест
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._testLogic.AddTest(Mapper.Map<TestVM, Test>(test));
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(test);
        }
        [HttpGet]
        public ActionResult StartTest(int idSubject, int id)
        {
            _testLogic.Initialization(idSubject);
            ViewData["idUser"] = id;
            return View("NextQuestion", Mapper.Map<Question, QuestionDisplayVM>(_testLogic.NewQuestion()));
        }
        [HttpPost]
        public ActionResult StartTest(int answer)
        {
            if (_testLogic.NewQuestion() == null)
            {
                return View("Result", new { result = 4});
            }
            return View("NextQuestion");
        }           
            
        public RedirectToRouteResult BackToStudents()
        {
            return RedirectToAction("Index","User");
        }
        public RedirectToRouteResult BackToSubject(int id)
        {
            return RedirectToAction("Index","Subject",new { id = id });
        }
        public ActionResult ListAnswers(int idTest, int idUser)
        {
            var a = Mapper.Map<IEnumerable<QuestionInTest>, IEnumerable<QuestionInTestDisplayVM>>(_testLogic.GetQuestionInTestBySubject(idTest));

            ViewData["idUser"]=idUser;
            return View(a);
        }
        public ActionResult Result(int result)
        {
            return View(result);
        }
        #endregion[/Method]
    }
}