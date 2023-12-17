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
    public class ServiceCategoryRepositorySQL : IRepository<SERVICE_CATEGORY>
    {
        private zhkh db; //контекст базы данных

        public ServiceCategoryRepositorySQL(zhkh dbcontext)
        {
            this.db = dbcontext;
        }

        public List<SERVICE_CATEGORY> GetList() //получение списка
        {
            return db.SERVICE_CATEGORY.ToList();
        }

        public SERVICE_CATEGORY GetItem(int id) //получение по id
        {
            return db.SERVICE_CATEGORY.Find(id);
        }

        public SERVICE_CATEGORY Create(SERVICE_CATEGORY c) //добавление нового
        {
            return db.SERVICE_CATEGORY.Add(c).Entity;
        }

        public void Update(SERVICE_CATEGORY c) //обновление
        {
            db.Entry(c).State = EntityState.Modified;
        }

        public void Delete(int id) //удаление
        {
            SERVICE_CATEGORY c = db.SERVICE_CATEGORY.Find(id);
            if (c != null)
                db.SERVICE_CATEGORY.Remove(c);
        }
    }
}
