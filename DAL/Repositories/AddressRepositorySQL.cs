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
    public class AddressRepositorySQL : IRepository<ADDRESS>
    {
        private zhkh db; //контекст базы данных

        public AddressRepositorySQL(zhkh dbcontext)
        {
            this.db = dbcontext;
        }

        public List<ADDRESS> GetList() //получение списка
        {
            return db.ADDRESS.ToList();
        }

        public ADDRESS GetItem(int id) //получение по id
        {
            return db.ADDRESS.Find(id);
        }

        public ADDRESS Create(ADDRESS a) //добавление нового
        {
            return db.ADDRESS.Add(a).Entity;
        }

        public void Update(ADDRESS a) //обновление
        {
            db.Entry(a).State = EntityState.Modified;
        }

        public void Delete(int id) //удаление
        {
            ADDRESS a = db.ADDRESS.Find(id);
            if (a != null)
                db.ADDRESS.Remove(a);
        }
    }
}
