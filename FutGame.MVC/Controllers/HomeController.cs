using System.Collections.Generic;
using System.Web.Mvc;
using FutGame.Data.Config;
using FutGame.Model;

namespace FutGame.MVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //using (var ctx = new AppContext())
            //{
            //    var player1 = new Player()
            //                      {
            //                          Name = "Luís Fabiano",
            //                          Position = Position.Forward,
            //                          CalculatedLevel = "8.6",
            //                          DisplayLevel = 8,
            //                          RealTeam = "São Paulo Futebol Clube"
            //                      };

            //    ctx.Players.Add(player1);

            //    var playerList = new List<Player>();
            //    playerList.Add(player1);

            //    var team = new Team()
            //                   {
            //                       Name = "Sabe de Nada Inocente",
            //                       Abbreviation = "SNI",
            //                       Players = playerList
            //                   };
                
            //    ctx.Teams.Add(team);

            //    ctx.SaveChanges();
            //}

            return View();
        }

    }
}
