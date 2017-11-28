using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _4MAT.Data;
using _4MAT.Foosball.Models;

namespace _4MAT.Foosball.Controllers
{
    public class HomeController : Controller
    {
        private readonly FoosballRepository _foosballRepository;

        public HomeController(FoosballRepository foosballRepository)
        {
            _foosballRepository = foosballRepository;
        }

        public async Task<IActionResult> Index()
        {
            var games = await _foosballRepository.RecentGames(DateTime.Now.AddDays(-7));
            return View(games);
        }

        //public IActionResult Index()
        //{
        //    var games = _foosballRepository.RecentGames(DateTime.Now.AddDays(-7));
        //    return View(games);
        //}

        public IActionResult LogGame()
        {
            return View();
        }


        public IActionResult LogGame(Game game)
        {
            _foosballRepository.AddGame(game);
            return RedirectToAction("Index");
        }

    }
}
