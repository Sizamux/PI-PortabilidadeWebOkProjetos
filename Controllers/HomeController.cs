﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PI_PorrtabilidadeWebOkPrrojetos.Models;
using System.Diagnostics;

namespace PI_PorrtabilidadeWebOkPrrojetos.Controllers
{
    [Authorize]//Anotação Identity
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]//Permite Vizualização de não-Usuarios
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]//Permite Vizualização de não-Usuarios
        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}