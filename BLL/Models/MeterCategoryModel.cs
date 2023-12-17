using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Models
{
    public class MeterCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }

        public MeterCategoryModel()
        {

        }

        public MeterCategoryModel(METER_CATEGORY c)
        {
            Id = c.id;
            Name = c.name;
            Unit = c.unit;
        }
    }
}
