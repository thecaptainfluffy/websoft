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
        public IActionResult Post(int fNumber, int tNumber, int money) 
        {     
            JsonFileAccountService jfas = new JsonFileAccountService();
            var accounts = jfas.GetAccounts();
            int i = 0;
            int iFrom = -1;
            int iTo = -1;
            foreach(var acc in accounts) {
                if(acc.Number == fNumber) {
                    iFrom = i;
                }
                if(acc.Number == tNumber) {
                    iTo = i;
                }
                i++;
            }
            if(iFrom != -1 && iTo != -1) {
                if(accounts.ElementAt(iFrom).Balance < money) {
                    ViewData["Error"] = "This account doesn't have that much money";
                    return View("Account");
                }

            accounts.ElementAt(iFrom).Balance = (accounts.ElementAt(iFrom).Balance - money);
            accounts.ElementAt(iTo).Balance = (accounts.ElementAt(iTo).Balance + money); 
            System.IO.File.WriteAllText("data/account.json", JsonSerializer.Serialize(accounts));
            } else {
                ViewData["Error"] = "Incorrect number for either from or to acc";
            }
            return View("Account");
        }                   
    }
}