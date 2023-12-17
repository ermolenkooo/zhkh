using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MeterRepositorySQL : IRepository<METER>
    {
        private zhkh db; //контекст базы данных

        public MeterRepositorySQL(zhkh dbcontext)
        {
            this.db = dbcontext;
        }

        public List<METER> GetList() //получение списка
        {
            return db.METER.ToList();
        }

        public METER GetItem(int id) //получение по id
        {
            return db.METER.Find(id);
        }

        public METER Create(METER m) //добавление нового
        {
            return db.METER.Add(m).Entity;
        }

        public void Update(METER m) //обновление
        {
            db.Entry(m).State = EntityState.Modified;
        }

        public void Delete(int id) //удаление
        {
            METER m = db.METER.Find(id);
            if (m != null)
                db.METER.Remove(m);
        }
    }
}
