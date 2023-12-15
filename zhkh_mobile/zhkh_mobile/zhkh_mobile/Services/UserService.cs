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
    public class UserService
    {
        public async Task<User> Reg(User user)
        {
            if (user.Phone == "88005553535") 
                return null;
            else
                return new User { Id = 1, Phone = "88005553535", Password = "123" };
        }

        public async Task<User> Login(User user)
        {
            if (user.Phone == "88005553535" && user.Password == "123")
                return new User { Id = 1, Phone = "88005553535", Password = "123" };
            else
                return null;
        }
    }
}
