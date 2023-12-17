using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Models
{
    public class ServiceModel
    {
        public int Id { get; set; }
        public int Id_address { get; set; }
        public int Id_category { get; set; }
        public string Company { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public bool Status { get; set; }
        public double Amount { get; set; }
        public string Account { get; set; }

        public ServiceModel() 
        { 

        }

        public ServiceModel(SERVICE s)
        {
            Id = s.id;
            Id_address = s.id_address;
            Id_category = s.id_category;
            Company = s.company;
            Month = s.month;
            Year = s.year;
            Status = s.status;
            Amount = s.amount;
            Account = s.account;
        }
    }
}
