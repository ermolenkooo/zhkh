using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Models
{
    public class ServiceCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ServiceCategoryModel()
        {

        }

        public ServiceCategoryModel(SERVICE_CATEGORY c)
        {
            Id = c.id;
            Name = c.name;
        }
    }
}
