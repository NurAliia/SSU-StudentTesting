using System.Web.Mvc;
using Sgu.StudentTesting.PL.Models;
using Common;
using Sgu.StudentTesting.BLL.Contracts;
using System.Web.Security;
using AutoMapper;
using Sgu.StudentTesting.PL.ViewModel.Subject;
using System.Security.Principal;
using Sgu.StudentTesting.PL.ViewModels.User;

namespace Sgu.StudentTesting.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserLogic _userLogic;
        private readonly ISubjectLogic _subjectLogic;
       // public SelectList DropDownList { get; set; }

        public AccountController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            FormsAuthentication.SetAuthCookie(model.Email, true);          
            if (ModelState.IsValid)
            {
                User user = _userLogic.CheckLoginUser(model.Email, model.Password);
                // поиск пользователя в бд                           
                if (user != null )
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");                  
                }
            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // создаем нового пользователя
                    _userLogic.AddUser(new Common.User
                    {
                        Name = model.Name,
                        SurName = model.SurName,
                        Patronymic = model.Patronymic,
                        City = model.City,
                        Faculty = model.Faculty,
                        University = model.University,
                        Direction = model.Direction,
                        EMail = model.Email,
                        Password = model.Password
                    });
                    User user = _userLogic.GetUserByEMail(model.Email);
                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }
            return View(model);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [ChildActionOnly]
        public PartialViewResult GetUserInfo()
        {

            var user = _userLogic.GetUserByEMail(User.Identity.Name) ?? new Common.User();

            var userDisplay = new UserDisplayVM()
            {
                Id = user.Id,
                Name = user.Name
            };
            return PartialView("LoginPartial", userDisplay);
        }

        public RedirectToRouteResult Details(int id)
        {
            return RedirectToAction("Details", "User", new { id = id });
        }
    }        
}