using OnlineStore.BLL.Dtos.Manufacturer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Contracts.Manufacturer
{
    public interface IManufacturerService
    {
        void Create(ManufacturerBllDto model);
        ManufacturerBllDto GetManufacturer(Guid id);
        IEnumerable<ManufacturerBllDto> GetManufacturer();
    }
}
