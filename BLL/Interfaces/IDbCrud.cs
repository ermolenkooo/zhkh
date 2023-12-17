using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDbCrud //интерфейс для crud-функций
    {
        UserModel Login(UserModel user);
        UserModel Reg(UserModel user);

        void UpdateStatusOfService(int id);
        List<ServiceModel> GetUnpaidServices(int id);
        List<ServiceModel> GetPaidServices(int id);

        List<MeterModel> GetMetersOfAddress(int id);
        void UpdateReading(int id, int reading);

        MeterCategoryModel GetMeterCategory(int id);

        ServiceCategoryModel GetServiceCategory(int id);

        AddressModel AddAddress(AddressModel address);
        AddressModel GetAddressOfUser(int id);
    }
}
