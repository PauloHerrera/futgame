using System.Web.Mvc;
using FutGame.Model;
using FutGame.Model.Queries;
using Ninject;
using System.Linq;

namespace FutGame.MVC.Controllers
{
    public class HomeController : Controller
    {
        private IGenericRepository<Team> _repository;

        [Inject]
        public HomeController(IGenericRepository<Team> repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var team = _repository.GetAll();

            var teste = team.ToList();
            
            return View();
        }
    }
}
