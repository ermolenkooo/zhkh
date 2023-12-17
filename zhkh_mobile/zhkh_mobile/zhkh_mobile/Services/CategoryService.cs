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
    public class CategoryService
    {
        string Url = App.ip + "categories/";
        // настройки для десериализации для нечувствительности к регистру символов
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public async Task<ServiceCategory> GetServiceCategory(int id)
        {
            var response = await App.client.GetAsync(Url + "service/" + id);
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonSerializer.Deserialize<ServiceCategory>(
               await response.Content.ReadAsStringAsync(), options);
        }

        public async Task<MeterCategory> GetMeterCategory(int id)
        {
            var response = await App.client.GetAsync(Url + "meter/" + id);
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            var res =  JsonSerializer.Deserialize<MeterCategory>(
               await response.Content.ReadAsStringAsync(), options);

            if (res.Unit == "м")
                res.Unit += "³";

            return res;
        }
    }
}
