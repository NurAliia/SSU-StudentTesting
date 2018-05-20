using Sgu.StudentTesting.BLL.Contracts;
using Common;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Sgu.StudentTesting.DAL.Contracts;
using Sgu.StudentTesting.PL.ViewModels.User;

namespace Sgu.StudentTesting.PL.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserLogic _userLogic;
        
        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        #region General

        // GET: Student        
        public ActionResult Index()
        {
            var user = _userLogic.GetUserByEMail(System.Web.HttpContext.Current.User.Identity.Name.ToString()) ?? new Common.User();

            var a = Mapper.Map<IEnumerable<User>, IEnumerable<UserDisplayVM>>(this._userLogic.GetStudents(user.Id));
            return this.View(a);
        }
        public ActionResult StudentTests(int id)
        {
            return RedirectToAction("Index","Test", new { id=id});
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserCreateVM student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._userLogic.AddUser(Mapper.Map<UserCreateVM, User>(student));
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(student);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return this.View(Mapper.Map<User,UserCreateVM>(this._userLogic.GetUserByIdFull(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserCreateVM student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._userLogic.Update(Mapper.Map<User>(student));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(student);
        }

        public ActionResult Delete(int id)
        {
            return this.View("DeleteConfirmation", Mapper.Map<UserDisplayVM>(this._userLogic.GetUserById(id)));
        }
        //Confirm
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UserDisplayVM user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._userLogic.Delete(user.Id);
                    return this.RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return RedirectToAction("Delete");
        }
        public ActionResult Details(int id)
        {
            var user = _userLogic.GetUserByEMail(System.Web.HttpContext.Current.User.Identity.Name.ToString()) ?? new Common.User();

            int x = _userLogic.GetRoleUser(user.Id);
            ViewData["role"] = x;

            return this.View(Mapper.Map<User,UserDisplayVM>(this._userLogic.GetUserByIdFull(id)));
        }
        [HttpPost]
        public ActionResult DetailsPost(int id)
        {
            _userLogic.RequestRights(id);
            return RedirectToAction("index", "Home");
        }
        public ActionResult ListRequestRights()
        {
            return  View(Mapper.Map<IEnumerable<User>, IEnumerable<UserDisplayVM>>(_userLogic.ListRequestRights()));
        }
        public ActionResult AcceptedTeacher(int id)
        {
            _userLogic.DeleteRequestRights(id);
            return RedirectToAction("ListRequestRights");
        }
        public ActionResult NotAcceptedTeacher(int id)
        {
            _userLogic.DeleteRequestRights(id);
            return RedirectToAction("ListRequestRights");
        }
        public ActionResult NewQuestions()
        {
            return RedirectToAction("ListNewQuestion", "Question");
        }
        public ActionResult BackToSubject()
        {
            return RedirectToAction("Index","Home");
        }

        #endregion general
    }
}