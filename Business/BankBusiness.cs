﻿using BankSample1.Data;
using BankSample1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSample1.Business
{
    public class BankBusiness
    {
        private BankContext bankContext;
        public List<Bank> GetAll()
        {
            using (bankContext = new BankContext())
            {
                return bankContext.Banks.ToList();
            }
        }
        public Bank Get(int id) 
        {
            using (bankContext = new BankContext())
            {
                return bankContext.Banks.Find(id);
            }
        }
        public void Add(Bank bank) 
        {
            using (bankContext = new BankContext())
            {
                bankContext.Banks.Add(bank);
                bankContext.SaveChanges();
            }
        }
        public void Update(Bank bank)
        { 
            using (bankContext = new BankContext())
            {
                var item = bankContext.Banks.Find(bank.Id);
                if (item != null)
                {
                    bankContext.Entry(item).CurrentValues.SetValues(bank);
                    bankContext.SaveChanges();
                }
            }
        }
        public void Delete(int id) 
        { 
            using (bankContext = new BankContext())
            {
                var bank = bankContext.Banks.Find(id);
                if (bank != null)
                {
                    bankContext.Banks.Remove(bank);
                    bankContext.SaveChanges();
                }
            }
        }
    }
}
