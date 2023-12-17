using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Operations
{
    public class DbDataOperations : IDbCrud
    {
        IDbRepos db; // реализация репозитория

        public DbDataOperations()
        {
            try
            {
                db = new DbReposSQL(); //создание репозитория
            }
            catch
            {
                //ошибка и выход из приложения
            }
        }

        public DbDataOperations(zhkh context)
        {
            try
            {
                db = new DbReposSQL(context); //создание репозитория
            }
            catch
            {
                //ошибка и выход из приложения
            }
        }

        public UserModel Login(UserModel u)
        {
            var user = db.Users.GetList().Where(i => i.phone == u.Phone && i.password == u.Password).FirstOrDefault();
            if (user == null)
                return null;
            else
                return new UserModel(user);
        }

        public UserModel Reg(UserModel u)
        {
            var users = db.Users.GetList();
            if (users.Where(i => i.phone == u.Phone).Count() != 0)
                return null;
            else
            {
                var user = db.Users.Create(new USER()
                {
                    phone = u.Phone,
                    password = u.Password
                });
                Save();
                return new UserModel(user);
            }
        }

        public void UpdateStatusOfService(int id)
        {
            var s = db.Services.GetItem(id);
            s.status = true;
            db.Services.Update(s);
            Save();
        }

        public List<ServiceModel> GetUnpaidServices(int id)
        {
            return db.Services.GetList().Where(i => i.id_address == id && i.status == false).Select(i => new ServiceModel(i)).ToList();
        }

        public List<ServiceModel> GetPaidServices(int id)
        {
            return db.Services.GetList().Where(i => i.id_address == id && i.status == true).Select(i => new ServiceModel(i)).ToList();
        }

        public List<MeterModel> GetMetersOfAddress(int id)
        {
            return db.Meters.GetList().Where(i => i.id_address == id).Select(i => new MeterModel(i)).ToList();
        }

        public void UpdateReading(int id, int reading)
        {
            var m = db.Meters.GetItem(id);
            m.reading = reading;
            db.Meters.Update(m);
            Save();
        }

        public MeterCategoryModel GetMeterCategory(int id)
        {
            return new MeterCategoryModel(db.MeterCategories.GetItem(id));
        }

        public ServiceCategoryModel GetServiceCategory(int id)
        {
            return new ServiceCategoryModel(db.ServiceCategories.GetItem(id));
        }

        public AddressModel AddAddress(AddressModel a)
        {
            var address = db.Addresses.Create(new ADDRESS()
            {
                city = a.City,
                street = a.Street,
                house = a.House,
                flat = a.Flat,
                id_user = a.Id_user
            });
            Save();

            List<ServiceModel> services = new List<ServiceModel>();
            services.Add(new ServiceModel
            {
                Id_address = address.id,
                Id_category = 1,
                Status = false,
                Year = 2023,
                Month = "ноябрь",
                Company = "Горводоканал",
                Account = "111 111",
                Amount = 1000.0
            });

            services.Add(new ServiceModel
            {
                Id_address = address.id,
                Id_category = 2,
                Status = false,
                Year = 2023,
                Month = "ноябрь",
                Company = "УК Просторы",
                Account = "111 111",
                Amount = 2000.0
            });

            services.Add(new ServiceModel
            {
                Id_address = address.id,
                Id_category = 3,
                Status = false,
                Year = 2023,
                Month = "ноябрь",
                Company = "Гарант",
                Account = "111 111",
                Amount = 500.0
            });

            services.Add(new ServiceModel
            {
                Id_address = address.id,
                Id_category = 4,
                Status = false,
                Year = 2023,
                Month = "декабрь",
                Company = "Чистый город",
                Account = "111 111",
                Amount = 100.0
            });

            foreach (var service in services)
                db.Services.Create(new SERVICE
                {
                    id_address = service.Id_address,
                    id_category = service.Id_category,
                    status = service.Status,
                    year = service.Year,
                    month = service.Month,
                    company = service.Company,
                    account = service.Account,
                    amount = service.Amount
                });

            List<MeterModel> meters = new List<MeterModel>();
            meters.Add(new MeterModel
            {
                Id_address = address.id,
                Id_category = 1,
                Number = "111 111",
                Date = DateTime.Now,
                Reading = null
            });

            meters.Add(new MeterModel
            {
                Id_address = address.id,
                Id_category = 2,
                Number = "111 111",
                Date = DateTime.Now,
                Reading = null
            });

            meters.Add(new MeterModel
            {
                Id_address = address.id,
                Id_category = 3,
                Number = "111 111",
                Date = DateTime.Now,
                Reading = null
            });

            foreach (var meter in meters)
                db.Meters.Create(new METER
                {
                    id_address = meter.Id_address,
                    id_category = meter.Id_category,
                    number = meter.Number,
                    date = meter.Date,
                    reading = meter.Reading
                });

            Save();
            return new AddressModel(address);
        }
        public AddressModel GetAddressOfUser(int id)
        {
            return db.Addresses.GetList().Where(i => i.id_user == id).Select(i => new AddressModel(i)).FirstOrDefault();
        }

        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }
    }
}
