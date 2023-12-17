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
    public class ServiceRepositorySQL : IRepository<SERVICE>
    {
        private zhkh db; //контекст базы данных

        public ServiceRepositorySQL(zhkh dbcontext)
        {
            this.db = dbcontext;
        }

        public List<SERVICE> GetList() //получение списка
        {
            return db.SERVICE.ToList();
        }

        public SERVICE GetItem(int id) //получение по id
        {
            return db.SERVICE.Find(id);
        }

        public SERVICE Create(SERVICE s) //добавление нового
        {
            return db.SERVICE.Add(s).Entity;
        }

        public void Update(SERVICE s) //обновление
        {
            db.Entry(s).State = EntityState.Modified;
        }

        public void Delete(int id) //удаление
        {
            SERVICE s = db.SERVICE.Find(id);
            if (s != null)
                db.SERVICE.Remove(s);
        }
    }
}
