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
    public class UserRepositorySQL : IRepository<USER>
    {
        private zhkh db; //контекст базы данных

        public UserRepositorySQL(zhkh dbcontext)
        {
            this.db = dbcontext;
        }

        public List<USER> GetList() //получение списка
        {
            return db.USER.ToList();
        }

        public USER GetItem(int id) //получение по id
        {
            return db.USER.Find(id);
        }

        public USER Create(USER u) //добавление нового
        {
            return db.USER.Add(u).Entity;
        }

        public void Update(USER u) //обновление
        {
            db.Entry(u).State = EntityState.Modified;
        }

        public void Delete(int id) //удаление
        {
            USER u = db.USER.Find(id);
            if (u != null)
                db.USER.Remove(u);
        }
    }
}
