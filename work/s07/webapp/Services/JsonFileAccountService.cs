using System.Collections.Generic;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using webapp.Models;

namespace webapp.Services
{
    public class JsonFileAccountService
    {
        public IEnumerable<Account> GetAccounts()
        {
            String file = "data/account.json";

            using (StreamReader r = new StreamReader(file))
            {
                string data = r.ReadToEnd();
                var json = JsonSerializer.Deserialize<Account[]>(
                    data,
                    new JsonSerializerOptions {
                        PropertyNameCaseInsensitive = true
                    }
                );
                return json;
            }
        }
    }
}
