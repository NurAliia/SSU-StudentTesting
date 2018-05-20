using AutoMapper;
using Common;
using Sgu.StudentTesting.BLL.Contracts;
using Sgu.StudentTesting.PL.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sgu.StudentTesting.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserLogic _userLogic;

        public HomeController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }
        public ActionResult Index()
        {
            //Не возвращает user
            var user = _userLogic.GetUserByEMail(System.Web.HttpContext.Current.User.Identity.Name.ToString()) ?? new Common.User();
            
            int x = _userLogic.GetRoleUser(user.Id);
            ViewData["role"] = x;
            ViewData["IdUser"] = user.Id;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public RedirectToRouteResult Subject(int id)
        {
            return RedirectToAction("Index", "Subject", new { id = id });
        }
        public RedirectToRouteResult Tests(int id)
        {
            return RedirectToAction("Index", "Test", new { id = id });
        }
        public RedirectToRouteResult NewTeacher()
        {
            return RedirectToAction("ListRequestRights", "User");
        }
        public RedirectToRouteResult NewQuestion()
        {
            return RedirectToAction("ListNewQuestion","Question");
        }
        public RedirectToRouteResult ListStudent(int id)
        {
            return RedirectToAction("Index", "User",new {id=id });
        }
        public RedirectToRouteResult ListQuestion()
        {
            return RedirectToAction("Index", "Question");
        }
    }
}