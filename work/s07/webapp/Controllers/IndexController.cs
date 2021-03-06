using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Collections.Generic;
using System.Linq;
using webapp.Models;
using webapp.Services;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace webapp.Controllers 
{
    [Route("/")]
    public class IndexController : Controller
    {
        public IActionResult index() 
        {
            JsonFileAccountService jfas = new JsonFileAccountService();
            ViewData["Accounts"] = jfas.GetAccounts();
            return View();
        }
    }
}