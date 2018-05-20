using AutoMapper;
using Common;
using Sgu.StudentTesting.BLL.Contracts;
using Sgu.StudentTesting.PL.ViewModel;
using Sgu.StudentTesting.PL.ViewModel.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Sgu.StudentTesting.PL.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionLogic _questionLogic;
        private readonly IUserLogic _userLogic;

        public QuestionController(IQuestionLogic questionLogic, IUserLogic userLogic)
        {
            _questionLogic = questionLogic;
            _userLogic = userLogic;
        }

        #region General

        // GET: Student        
        public ActionResult Index()
        {
            //ПЕРЕДАЕМ автора, который авторизированный. ОН может смотреть только свои вопросы
            var user = _userLogic.GetUserByEMail(System.Web.HttpContext.Current.User.Identity.Name.ToString()) ?? new Common.User();
            
            var a = Mapper.Map<IEnumerable<Question>, IEnumerable<QuestionDisplayVM>>(this._questionLogic.GetQuestionsByAuthor(user.Id));

            return this.View(a);
        }

        public ActionResult ListQuestionSubject(int subject, int theme)
        {
            var list = (this._questionLogic.GetQuestionsByTheme(subject, theme));
            TestViewModel test = new TestViewModel(list);
            return this.View(Mapper.Map <QuestionCreateVM>(list));
        }
        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuestionCreateVM question)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    question.Author = (_userLogic.GetUserByEMail(System.Web.HttpContext.Current.User.Identity.Name.ToString()) ?? new Common.User()).Id;
                    _questionLogic.AddQuestion(Mapper.Map<QuestionCreateVM, Question>(question));
                    return RedirectToAction("Index");
                }
                     
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(question);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = _userLogic.GetUserByEMail(System.Web.HttpContext.Current.User.Identity.Name.ToString()) ?? new Common.User();

            int x = _userLogic.GetRoleUser(user.Id);
            ViewData["role"] = x;
            return this.View(Mapper.Map<QuestionCreateVM>(this._questionLogic.GetQuestionById(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToRouteResult Edit([Bind(Include = "Id, Author, IdSubject, Date, Text, VariantOfAnswer1,VariantOfAnswer2,VariantOfAnswer3,VariantOfAnswer4,Theme,Complexity, Score,CorrectAnswer")] QuestionCreateVM question)
        {
            int x=0;
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _userLogic.GetUserByEMail(System.Web.HttpContext.Current.User.Identity.Name.ToString()) ?? new Common.User();

                    x = _userLogic.GetRoleUser(user.Id);
                    ViewData["role"] = x;
                    question.Author = user.Id;
                    _questionLogic.Update(Mapper.Map<QuestionCreateVM,Question>(question));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            if (x == 1)
            {
                return RedirectToAction("ListNewQuestion");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            return this.View("Delete", Mapper.Map<QuestionDisplayVM>(this._questionLogic.GetQuestionById(id)));
        }
        //Confirm
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _userLogic.GetUserByEMail(System.Web.HttpContext.Current.User.Identity.Name.ToString()) ?? new Common.User();

                    int x = _userLogic.GetRoleUser(user.Id);
                    ViewData["role"] = x;
                    this._questionLogic.DeleteById(id);
                    if (x == 1)
                    {
                        return RedirectToAction("ListNewQuestion");
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return RedirectToAction("Delete");
        }
        public ActionResult ListNewQuestion()
        {
            var a = Mapper.Map<IEnumerable<Question>, IEnumerable<QuestionDisplayVM>>(_questionLogic.ListNewQuestion());

            return this.View(a);

        }
        public RedirectToRouteResult Details(int id)
        {
            return RedirectToAction("Details", "User", new { id = id });
        }
        public ActionResult AcceptedQuestion(int id)
        {
            _questionLogic.Accepted(id);
            return View("ListNewQuestion");
        }
        //public ActionResult GetQuestionsByAuthor(int id)
        //{
        //    var a = Mapper.Map<IEnumerable<Question>, IEnumerable<QuestionDisplayVM>>(_questionLogic.GetQuestionsByAuthor(id));

        //    return View(a);
        //}

        #endregion general
    }
}