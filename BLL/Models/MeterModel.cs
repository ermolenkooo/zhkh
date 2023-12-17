using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Models
{
    public class MeterModel
    {
        public int Id { get; set; }
        public int Id_address { get; set; }
        public string Number { get; set; }
        public int Id_category { get; set; }
        public DateTime Date { get; set; }
        public int? Reading { get; set; }

        public MeterModel()
        {

        }

        public MeterModel(METER m)
        {
            Id = m.id;
            Id_address = m.id_address;
            Number = m.number;
            Id_category = m.id_category;
            Date = m.date;
            Reading = m.reading;
        }
    }
}
