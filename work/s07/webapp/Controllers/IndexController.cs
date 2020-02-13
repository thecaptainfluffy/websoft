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
        [Route("About")]
        public IActionResult About() 
        {
            return View();
        }
        [Route("Privacy")]
        public IActionResult Privacy() 
        {
            return View();
        }
        [Route("api/accounts")]
        public IEnumerable<Account> Accounts() 
        {
            JsonFileAccountService jfas = new JsonFileAccountService();
            return jfas.GetAccounts();
        }
        [Route("api/accounts/{number}")]
        public IActionResult Accounts(int number) 
        {
            JsonFileAccountService jfas = new JsonFileAccountService();
            var accounts = jfas.GetAccounts();
            foreach(var account in accounts) {
                if(account.Number == number)
                return Ok(account);
            }
            return Ok("{\"error\": Account " + number + " does not exist}");
        }
    }
}