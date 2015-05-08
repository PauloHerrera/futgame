using System.Collections.Generic;
using System.Web.Mvc;
using FutGame.MVC.Helpers.Security;
using FutGame.Model;
using FutGame.Model.Entities;
using FutGame.Model.Queries;
using Ninject;
using System.Linq;

namespace FutGame.MVC.Controllers
{
    [CustomAuthorize]
    public class MaganerController : Controller
    {
        private IGenericRepository<Team> _repository;

        [Inject]
        public MaganerController(IGenericRepository<Team> repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var team = _repository.GetAll();

            var teste = team.ToList();

            List<int> teste2 = teste.Select(team1 => 1).ToList();

            return View();
        }
    }
}
