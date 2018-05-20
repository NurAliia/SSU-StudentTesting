using AutoMapper;
using Common;
using Sgu.StudentTesting.BLL.Contracts;
using Sgu.StudentTesting.PL.ViewModel.Question;
using Sgu.StudentTesting.PL.ViewModel.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;


namespace Sgu.StudentTesting.PL.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectLogic _subjectLogic;

        public SubjectController(ISubjectLogic subjectLogic)
        {
            _subjectLogic = subjectLogic;
        }
        #region General

        // GET: Subject
        public ActionResult Index(int id)
        {
            //БЕРЕМ Студенда и выбираем его предметы в хранимке
            var a = Mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectDisplayVM>>(this._subjectLogic.GetSubjectsStudent(id));
            ViewData["IdUser"] = id;
            return this.View(a);
        }
        public ActionResult Test(int id, int idSubject)
        {
            ViewData["idUser"] = id;
            ViewData["idSubject"] = idSubject;
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult TestPost(int id,int idSubject)
        {           
            //var a = Mapper.Map<Subject, SubjectDisplayVM>(this._subjectLogic.GetSubjectById((int)ViewData["idSubject"]));
                       
            return RedirectToAction("StartTest", "Test", new { idSubject = idSubject, id = id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubjectCreateVM test)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _subjectLogic.AddSubject(Mapper.Map<SubjectCreateVM, Subject>(test));
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(test);
        }
        public ActionResult Back()
        {
            return RedirectToAction("Index", "Home");
        }
        public RedirectToRouteResult Details(int id)
        {
            return RedirectToAction("Details", "User", new { id = id });
        }
        #endregion[/Method]
    }
}