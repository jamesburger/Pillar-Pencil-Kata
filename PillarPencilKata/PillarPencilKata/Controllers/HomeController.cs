using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PillarPencilKata.Models;
using PillarPencilKata.Pencil_Logic;

namespace PillarPencilKata.Controllers
{
    public class HomeController : Controller
    {
        private IPencil Pencil;

        public HomeController(IPencil pencil)
        {
           Pencil = pencil;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Write(string input)
        {
            PaperModel Paper = new PaperModel();
            Pencil.WriteInputOntoPaper(input, Paper);
            return View("Index", Paper);
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
