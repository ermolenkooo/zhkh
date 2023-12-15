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
    public class MeterService
    {
        private CategoryService categoryService = new CategoryService();

        public async Task<List<Meter>> GetMetersOfAddress(int id)
        {
            List<Meter> meters = new List<Meter>();

            meters.Add(new Meter { 
                Id = 1, 
                Id_address = id,
                Number = "№123400098",
                Id_category = 1,
                Date = new DateTime(2023, 9, 25),
                Reading = 12312,
                Category = await categoryService.GetMeterCategory(1)
            });

            meters.Add(new Meter
            {
                Id = 2,
                Id_address = id,
                Number = "№123400098",
                Id_category = 2,
                Date = new DateTime(2023, 9, 25),
                Reading = 345,
                Category = await categoryService.GetMeterCategory(2)
            });

            meters.Add(new Meter
            {
                Id = 3,
                Id_address = id,
                Number = "№123400098",
                Id_category = 3,
                Date = new DateTime(2023, 9, 25),
                Reading = 256,
                Category = await categoryService.GetMeterCategory(3)
            });

            return meters;
        }

        public async void UpdateReading(int id, int reading)
        {

        }

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
