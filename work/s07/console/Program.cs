using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
               string option = "";
               string FormatAccountsHeader = String.Format("{0, 10} {1, 10} {2,10} {3, 10}", "Number", "Balance", "Label", "Owner");
            do {
                var accounts = ReadAccounts();
                Console.WriteLine("-------Menu-------");
                Console.WriteLine("1. View accounts");
                Console.WriteLine("2. View account by number");
                Console.WriteLine("3. Search");
                Console.WriteLine("4. Move");
                Console.WriteLine("5. Exit");
                Console.Write("Option: ");
                option = Console.ReadLine();
                Console.WriteLine("------------------");
                switch (option) {
                    case "1":
                    Console.WriteLine(FormatAccountsHeader);
                    Console.WriteLine("_____________________________________________");    
                    foreach(var acc in accounts) {
                        string FormatAccountsValue = String.Format("{0, 10} {1, 10} {2, 10} {3, 10}", acc.Number, acc.Balance, acc.Label, acc.Owner);
                        Console.WriteLine(FormatAccountsValue);
                        Console.WriteLine("---------------------------------------------"); 
                    }
                    break;

                    case "2":
                    var nr = 0;
                    do {
                        Console.WriteLine("Insert number");
                        string input = Console.ReadLine();
                        nr = Int32.Parse(input);
                    } while (0 > nr || nr >= accounts.Count());
                    Console.WriteLine(FormatAccountsHeader);
                    Console.WriteLine("_____________________________________________"); 
                    string FormatAccount = String.Format("{0, 10} {1, 10} {2, 10} {3, 10}", accounts.ElementAt(nr).Number, accounts.ElementAt(nr).Balance, accounts.ElementAt(nr).Label, accounts.ElementAt(nr).Owner);
                    Console.WriteLine(FormatAccount);
                    break;

                    case "3":
                    Console.WriteLine("Search number, label or owner: ");
                    string search = Console.ReadLine();
                    Console.WriteLine(FormatAccountsHeader);
                    Console.WriteLine("_____________________________________________");    
                    foreach(var acc in accounts) {
                        if(acc.Number.ToString().Equals(search) ||
                        acc.Label.Contains(search) ||
                        acc.Owner.ToString().Contains(search)) {
                            string FormatAccountsValue = String.Format("{0, 10} {1, 10} {2, 10} {3, 10}", acc.Number, acc.Balance, acc.Label, acc.Owner);
                            Console.WriteLine(FormatAccountsValue);
                            Console.WriteLine("---------------------------------------------"); 
                        }
                    }
                    break;

                    case "4":
                    int facc = -1;
                    int tacc = -1;
                    int balance = 0;

                    Console.WriteLine("Take money from account: ");
                    int faccNr = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Give money to account: ");
                    int taccNr = Int32.Parse(Console.ReadLine());

                    for(int i = 0; i < accounts.Count(); i++) {
                        if(faccNr == accounts.ElementAt(i).Number) {
                            facc = i;
                        }
                        if(taccNr == accounts.ElementAt(i).Number) {
                            tacc = i;
                        }
                    }
                    if(facc != -1 && tacc != -1) {
                    Console.WriteLine("How much? (Max: " + accounts.ElementAt(facc).Balance + "): ");
                    do {
                     balance = Int32.Parse(Console.ReadLine());
                    } while(0 > balance && balance > accounts.ElementAt(facc).Balance);

                    accounts.ElementAt(facc).Balance = (accounts.ElementAt(facc).Balance - balance);
                    accounts.ElementAt(tacc).Balance = (accounts.ElementAt(tacc).Balance + balance); 

                    System.IO.File.WriteAllText("data/account.json", JsonSerializer.Serialize(accounts));
                    } else {
                        Console.WriteLine("Wrong acc number");
                    }
                    break;
                }
            } while(option != "5");
            Console.WriteLine("Exit the program");
        }

        static IEnumerable<Account> ReadAccounts()
        {
            String file = "data/account.json";

            using (StreamReader r = new StreamReader(file))
            {
                string data = r.ReadToEnd();
                // Console.WriteLine(data);

                var json = JsonSerializer.Deserialize<Account[]>(
                    data,
                    new JsonSerializerOptions {
                        PropertyNameCaseInsensitive = true
                    }
                );

                //Console.WriteLine(json[0]);
                return json;
            }
        }
        
        

    }
     public class Account
    {
        public int Number { get; set; }
        public int Balance { get; set; }
        public string Label { get; set; }
        public int Owner { get; set; }
        
        public override string ToString() {
            return JsonSerializer.Serialize<Account>(this);
        }
    }
}
