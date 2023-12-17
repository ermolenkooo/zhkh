using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDbRepos //интерфейс для взаимодействия с репозиториями
    {
        IRepository<ADDRESS> Addresses { get; }
        IRepository<METER> Meters { get; }
        IRepository<METER_CATEGORY> MeterCategories { get; }
        IRepository<SERVICE> Services { get; }
        IRepository<SERVICE_CATEGORY> ServiceCategories { get; }
        IRepository<USER> Users { get; }
        int Save();
    }
}
