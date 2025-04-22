using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BankSample1.Data.Models
{
    public class Bank
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
    }
}
