using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using zhkh_mobile.Models;
using System.ComponentModel;

namespace zhkh_mobile.Services
{
    public class ServiceService
    {
        CategoryService categoryService = new CategoryService();

        public async Task<int> UpdateStatusOfService(int id)
        {
            return 0;
        }

        public async Task<List<Service>> GetUnpaidServices(int id)
        {
            List<Service> services = new List<Service>();
            services.Add(new Service
            {
                Id = 1,
                Id_address = id,
                Id_category = 1,
                IsSelect = false,
                Status = false,
                Year = 2023,
                Month = "октябрь",
                Company = "Горводоканал",
                Account = "111 111",
                Amount = 1000.0,
                Category = await categoryService.GetServiceCategory(1)
            });

            services.Add(new Service
            {
                Id = 2,
                Id_address = id,
                Id_category = 2,
                IsSelect = false,
                Status = false,
                Year = 2023,
                Month = "октябрь",
                Company = "УК Просторы",
                Account = "111 111",
                Amount = 2000.0,
                Category = await categoryService.GetServiceCategory(2)
            });

            services.Add(new Service
            {
                Id = 3,
                Id_address = id,
                Id_category = 3,
                IsSelect = false,
                Status = false,
                Year = 2023,
                Month = "октябрь",
                Company = "Гарант",
                Account = "111 111",
                Amount = 500.0,
                Category = await categoryService.GetServiceCategory(3)
            });

            services.Add(new Service
            {
                Id = 4,
                Id_address = id,
                Id_category = 4,
                IsSelect = false,
                Status = false,
                Year = 2023,
                Month = "ноябрь",
                Company = "Чистый город",
                Account = "111 111",
                Amount = 100.0,
                Category = await categoryService.GetServiceCategory(4)
            });

            return services;
        }

        public async Task<List<Service>> GetPaidServices(int id)
        {
            List<Service> services = new List<Service>();
            services.Add(new Service
            {
                Id = 1,
                Id_address = id,
                Id_category = 1,
                IsSelect = false,
                Status = true,
                Year = 2023,
                Month = "сентябрь",
                Company = "Горводоканал",
                Account = "111 111",
                Amount = 2310,
                Category = await categoryService.GetServiceCategory(1)
            });

            services.Add(new Service
            {
                Id = 2,
                Id_address = id,
                Id_category = 2,
                IsSelect = false,
                Status = true,
                Year = 2023,
                Month = "октябрь",
                Company = "УК Просторы",
                Account = "111 111",
                Amount = 2000.0,
                Category = await categoryService.GetServiceCategory(2)
            });

            services.Add(new Service
            {
                Id = 3,
                Id_address = id,
                Id_category = 3,
                IsSelect = false,
                Status = true,
                Year = 2023,
                Month = "сентябрь",
                Company = "Гарант",
                Account = "111 111",
                Amount = 500.0,
                Category = await categoryService.GetServiceCategory(3)
            });

            services.Add(new Service
            {
                Id = 4,
                Id_address = id,
                Id_category = 4,
                IsSelect = false,
                Status = true,
                Year = 2023,
                Month = "сентябрь",
                Company = "Чистый город",
                Account = "111 111",
                Amount = 120.0,
                Category = await categoryService.GetServiceCategory(4)
            });

            services.Add(new Service
            {
                Id = 2,
                Id_address = id,
                Id_category = 2,
                IsSelect = false,
                Status = true,
                Year = 2023,
                Month = "сентябрь",
                Company = "УК Просторы",
                Account = "111 111",
                Amount = 2000.0,
                Category = await categoryService.GetServiceCategory(2)
            });
            return services;
        }
    }
}
