using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace FutGame.MVC.Helpers.Security
{
    public class CurrentUser : IPrincipal
    {
        public IIdentity Identity { get; private set; }

        public  CurrentUser(string username)
        {
            this.Identity = new GenericIdentity(username);
        }

        public bool IsInRole(string role)
        {
            return role == "user";
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}