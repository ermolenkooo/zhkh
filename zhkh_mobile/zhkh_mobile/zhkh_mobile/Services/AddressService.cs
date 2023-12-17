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
        string Url = App.ip + "address";
        // настройки для десериализации для нечувствительности к регистру символов
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
       
        public async Task<Address> GetAddressOfUser(int id)
        {
            var response = await App.client.GetAsync(Url + "/" + id);
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonSerializer.Deserialize<Address>(
               await response.Content.ReadAsStringAsync(), options);
        }

        public async Task<Address> AddAddress(Address address)
        {
            var response = await App.client.PostAsync(Url,
            new StringContent(
                JsonSerializer.Serialize(address),
                Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonSerializer.Deserialize<Address>(
                await response.Content.ReadAsStringAsync(), options);
        }
    }
}
