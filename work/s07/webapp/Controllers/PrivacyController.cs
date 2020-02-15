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
    [Route("Privacy")]
    public class PrivacyController : Controller
    {
        public IActionResult Privacy() 
        {
            return View();
        }
    }
}