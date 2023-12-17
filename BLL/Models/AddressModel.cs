using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Flat { get; set; }
        public int Id_user { get; set; }

        public AddressModel() 
        { 

        }

        public AddressModel(ADDRESS a)
        {
            Id = a.id;
            City = a.city;
            Street = a.street;
            House = a.house;
            Flat = a.flat;
            Id_user = a.id_user;
        }
    }
}
