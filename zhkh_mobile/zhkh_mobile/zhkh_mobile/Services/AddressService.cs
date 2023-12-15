using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using zhkh_mobile.Models;

namespace zhkh_mobile.Services
{
    public class AddressService
    {
        public async Task<Address> GetAddressOfUser(int id)
        {
            if (id == 1)
                return new Address { Id = 1, City = "Иваново", Street = "Ленина", House = "12", Flat = "44", Id_user = 1 };
            else
                return null;
        }

        public async Task<Address> AddAddress(Address address)
        {
            return new Address { Id = 1, City = address.City, Street = address.Street, House = address.House, Flat = address.Flat, Id_user = address.Id_user };
        }
    }
}
