using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FutGame.MVC.Helpers.Security;
using FutGame.MVC.Models;
using FutGame.Model.Entities;
using FutGame.Model.Queries;
using Newtonsoft.Json;
using Ninject;

namespace FutGame.MVC.Controllers
{
    public class LoginController : Controller
    {
        private IUserRepository _repository;

        protected virtual new CurrentUser User
        {
            get { return HttpContext.User as CurrentUser; }
        }

        [Inject]
        public LoginController(IUserRepository repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserLoginViewModel model)
        {
            //TODO:REFACTOR!
            var user = _repository.Authenticate(new User(){Username = model.Username, Password = Cryptography.ComputeHash(model.Password, new SHA256CryptoServiceProvider()) });

            if (user != null)
            {
                UserViewModel serializeModel = new UserViewModel();
                serializeModel.UserId = user.UserId;
                serializeModel.FirstName = user.FirstName;
                serializeModel.LastName = user.LastName;

                string userData = JsonConvert.SerializeObject(serializeModel);
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                         1,
                        user.Email,
                         DateTime.Now,
                         DateTime.Now.AddMinutes(15),
                         false,
                         userData);

                string encTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                Response.Cookies.Add(faCookie);
            }

            var teste = User;

            return View();
        }

    }
}
