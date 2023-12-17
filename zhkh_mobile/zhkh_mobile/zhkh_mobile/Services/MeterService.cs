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
        string Url = App.ip + "meter/";
        // настройки для десериализации для нечувствительности к регистру символов
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        private CategoryService categoryService = new CategoryService();

        public async Task<List<Meter>> GetMetersOfAddress(int id)
        {
            string result = await App.client.GetStringAsync(Url + id);
            var res = JsonSerializer.Deserialize<List<Meter>>(result, options);

            for (int i = 0; i < res.Count; i++)
                res[i].Category = await categoryService.GetMeterCategory(res[i].Id_category);

            return res;
        }

        public async void UpdateReading(int id, int reading)
        {
            await App.client.PutAsync(Url + id + "/" + reading, null);
                //new StringContent(
                //    JsonSerializer.Serialize(reading),
                //    Encoding.UTF8, "application/json"));
        }
    }
}
