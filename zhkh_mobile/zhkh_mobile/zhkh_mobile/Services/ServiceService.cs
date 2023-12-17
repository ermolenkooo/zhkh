using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using zhkh_mobile.Models;
using System.ComponentModel;
using Xamarin.Forms;

namespace zhkh_mobile.Services
{
    public class ServiceService
    {
        string Url = App.ip + "service/";
        // настройки для десериализации для нечувствительности к регистру символов
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        CategoryService categoryService = new CategoryService();

        public async Task<int> UpdateStatusOfService(int id)
        {
            var response = await App.client.PutAsync(Url + id, null);
            //new StringContent(
            //        JsonSerializer.Serialize(id),
            //        Encoding.UTF8, "application/json"));

            return 0;
        }

        public async Task<List<Service>> GetUnpaidServices(int id)
        {
            string result = await App.client.GetStringAsync(Url + "unpaid/" + id);
            var res = JsonSerializer.Deserialize<List<Service>>(result, options);

            for (int i = 0; i < res.Count; i++)
                res[i].Category = await categoryService.GetServiceCategory(res[i].Id_category);

            return res;
        }

        public async Task<List<Service>> GetPaidServices(int id)
        {
            string result = await App.client.GetStringAsync(Url + "paid/" + id);
            var res = JsonSerializer.Deserialize<List<Service>>(result, options);

            for (int i = 0; i < res.Count; i++)
                res[i].Category = await categoryService.GetServiceCategory(res[i].Id_category);

            return res;
        }
    }
}
