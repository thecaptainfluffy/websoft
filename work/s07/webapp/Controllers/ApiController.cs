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
    [Route("api")]
    public class ApiController : Controller
    {
        [Route("accounts")]
        public IEnumerable<Account> Accounts() 
        {
            JsonFileAccountService jfas = new JsonFileAccountService();
            return jfas.GetAccounts();
        }
        [Route("accounts/{number}")]
        [HttpGet]
        public IActionResult GetAccounts(int number) 
        {
            JsonFileAccountService jfas = new JsonFileAccountService();
            var accounts = jfas.GetAccounts();
            foreach(var account in accounts) {
                if(account.Number == number)
                return Ok(account);
            }
            return Ok("{\"error\": Account " + number + " does not exist}");
        }
        [Route("account")]
        public IActionResult Account() 
        {
            JsonFileAccountService jfas = new JsonFileAccountService();
            var accounts = jfas.GetAccounts();
            ViewData["Account"] = accounts.ElementAt(0);
            return View();
        }
        [HttpPost]
        public IActionResult Post([Bind("Number, Balance, Label, Owner")] Account account) 
        {
            ViewData["Error"] = "Incorrect account number";      
            ViewData["Account"] = account;
            JsonFileAccountService jfas = new JsonFileAccountService();
            var accounts = jfas.GetAccounts();
            foreach(var acc in accounts) {
                if(account.Number == acc.Number) {
                    ViewData["Account"] = acc;
                    ViewData["Error"] = "";  
                }
            }      
            return View("Account");
        }                   
    }
}