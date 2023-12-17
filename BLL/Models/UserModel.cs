using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public UserModel()
        {

        }

        public UserModel(USER u)
        {
            Id = u.id;
            Phone = u.phone;
            Password = u.password;
        }
    }
}
