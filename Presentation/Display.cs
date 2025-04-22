using BankSample1.Business;
using BankSample1.Data.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using Microsoft.SqlServer;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace BankSample1.Presentation
{
    public class Display
    {
        private const int closeOperationId = 6;
        private BankBusiness bankBusiness = new BankBusiness();
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18)); ;
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
        }
        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1: ListAll(); break;
                    case 2: Add(); break;
                    case 3: Update(); break;
                    case 4: Fetch(); break;
                    case 5: Delete(); break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
            
        }
        public Display()
        {
            Input();
        }
        private void Delete()
        {
            Console.WriteLine("Enter ID of the entry to delete: ");
            int id = int.Parse(Console.ReadLine());
            bankBusiness.Delete(id);
            Console.WriteLine("Done!");
        }

        private void Fetch()
        {

            Console.WriteLine("Enter ID of the entry to fetch: ");
            int id = int.Parse(Console.ReadLine());

            Bank bank = bankBusiness.Get(id);

            if (bank != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine($"Id: {bank.Id}");
                Console.WriteLine($"Name: {bank.Name}");
                Console.WriteLine($"Price: {bank.Balance}");
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Error: Bank not found!");
            }
        }

        private void Update()
        {
            Console.WriteLine("Enter ID of the entry to update: ");
            int id = int.Parse(Console.ReadLine());

            Bank bank = bankBusiness.Get(id);

            if (bank != null)
            {
                Console.WriteLine("Name: ");
                bank.Name = Console.ReadLine();

                Console.WriteLine("Price: ");
                bank.Balance = double.Parse(Console.ReadLine());


                bankBusiness.Update(bank);
            }
            else
            {
                Console.WriteLine("Error: Bank not found!");
            }
        }

        private void Add()
        {
            Bank bank = new Bank();
            Console.WriteLine("Enter name: ");
            bank.Name = Console.ReadLine();
            Console.WriteLine("Enter balance: ");
            bank.Balance = double.Parse(Console.ReadLine());
            bankBusiness.Add(bank);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 16) + "BANKS" + new string('-', 16));
            Console.WriteLine(new string('-', 40));

            List<Bank> banks = bankBusiness.GetAll();

            foreach (var bank in banks)
            {
                Console.WriteLine($"{bank.Id} {bank.Name} {bank.Balance}");
            }
        }
    }
}
