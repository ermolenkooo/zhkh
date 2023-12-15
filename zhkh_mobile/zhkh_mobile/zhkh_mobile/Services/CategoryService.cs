﻿using System;
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
        public async Task<ServiceCategory> GetServiceCategory(int id)
        {
            switch (id)
            {
                case 1: return new ServiceCategory { Id = 1, Name = "Водоснабжение" };
                case 2: return new ServiceCategory { Id = 2, Name = "Квартплата" };
                case 3: return new ServiceCategory { Id = 3, Name = "Охрана" };
                case 4: return new ServiceCategory { Id = 4, Name = "Вывоз мусора" };
                default: return null;
            }
        }
    }
}