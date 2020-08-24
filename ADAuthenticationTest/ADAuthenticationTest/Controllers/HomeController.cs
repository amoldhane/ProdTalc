using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ADAuthenticationTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;

namespace ADAuthenticationTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult Index()
        {
            ViewBag.UserName = User.Identity.Name;
            return View();
        }

        [HttpPost]
        public IActionResult SignOut()
        {
            return SignOut(new AuthenticationProperties()
            { RedirectUri = "/Home/SignOutSuccess" },
        AzureADDefaults.AuthenticationScheme,
        AzureADDefaults.CookieScheme,
        AzureADDefaults.OpenIdScheme);
        }

        public IActionResult SignOutSuccess()
        {
            return View();
        }
    }
}
