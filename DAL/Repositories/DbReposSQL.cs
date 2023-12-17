using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DbReposSQL : IDbRepos
    {
        private zhkh db; //контекст базы данных
        private AddressRepositorySQL addressRepository;
        private MeterCategoryRepositorySQL meterCategoryRepository;
        private MeterRepositorySQL meterRepository;
        private ServiceCategoryRepositorySQL serviceCategoryRepository;
        private ServiceRepositorySQL serviceRepository;
        private UserRepositorySQL userRepository;

        public DbReposSQL()
        {
            db = new zhkh(); //создание контекста
        }

        public DbReposSQL(zhkh context)
        {
            db = context; //создание контекста
        }

        public IRepository<ADDRESS> Addresses
        {
            get
            {
                if (addressRepository == null)
                    addressRepository = new AddressRepositorySQL(db);
                return addressRepository;
            }
        }

        public IRepository<METER_CATEGORY> MeterCategories
        {
            get
            {
                if (meterCategoryRepository == null)
                    meterCategoryRepository = new MeterCategoryRepositorySQL(db);
                return meterCategoryRepository;
            }
        }

        public IRepository<METER> Meters
        {
            get
            {
                if (meterRepository == null)
                    meterRepository = new MeterRepositorySQL(db);
                return meterRepository;
            }
        }

        public IRepository<SERVICE_CATEGORY> ServiceCategories
        {
            get
            {
                if (serviceCategoryRepository == null)
                    serviceCategoryRepository = new ServiceCategoryRepositorySQL(db);
                return serviceCategoryRepository;
            }
        }

        public IRepository<SERVICE> Services
        {
            get
            {
                if (serviceRepository == null)
                    serviceRepository = new ServiceRepositorySQL(db);
                return serviceRepository;
            }
        }

        public IRepository<USER> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepositorySQL(db);
                return userRepository;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
