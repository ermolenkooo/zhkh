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
    public class MeterCategoryRepositorySQL : IRepository<METER_CATEGORY>
    {
        private zhkh db; //контекст базы данных

        public MeterCategoryRepositorySQL(zhkh dbcontext)
        {
            this.db = dbcontext;
        }

        public List<METER_CATEGORY> GetList() //получение списка
        {
            return db.METER_CATEGORY.ToList();
        }

        public METER_CATEGORY GetItem(int id) //получение по id
        {
            return db.METER_CATEGORY.Find(id);
        }

        public METER_CATEGORY Create(METER_CATEGORY c) //добавление нового
        {
            return db.METER_CATEGORY.Add(c).Entity;
        }

        public void Update(METER_CATEGORY c) //обновление
        {
            db.Entry(c).State = EntityState.Modified;
        }

        public void Delete(int id) //удаление
        {
            METER_CATEGORY c = db.METER_CATEGORY.Find(id);
            if (c != null)
                db.METER_CATEGORY.Remove(c);
        }
    }
}
