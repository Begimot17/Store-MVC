using OnlineStore.BLL.Contracts.Manufacturer;
using OnlineStore.BLL.Dtos.Manufacturer;
using Store.Dal.CodeFirst.Contracts;
using Store.Dtos.Data.Manufacturer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Services
{
    public class ManufacturerService: IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepository;

        public ManufacturerService(IManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }

        internal ManufacturerDto ToData(ManufacturerBllDto model)
        {
            return new ManufacturerDto
            {
                Id = model.Id,
                Name = model.Name,
                Logo = model.Logo
            };
        }
        internal ManufacturerBllDto ToBusiness(ManufacturerDto model)
        {
            return new ManufacturerBllDto
            {
                Id = model.Id,
                Name = model.Name,
                Logo = model.Logo
            };
        }
        public void Create(ManufacturerBllDto model)
        {
            _manufacturerRepository.Create(ToData(model));

        }

        public ManufacturerBllDto GetManufacturer(Guid id)
        {
            return ToBusiness(_manufacturerRepository.GetManufacturer(id));

        }

        public IEnumerable<ManufacturerBllDto> GetManufacturer() =>
            _manufacturerRepository.GetManufacturer().Select(ToBusiness);
    }
}
