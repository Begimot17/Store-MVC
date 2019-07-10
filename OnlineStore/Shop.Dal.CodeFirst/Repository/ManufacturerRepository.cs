using Store.Dal.CodeFirst.Contracts;
using Store.Dal.CodeFirst.Mappers;
using Store.Dtos.Data.Manufacturer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.CodeFirst.Repository
{
    public class ManufacturerRepository :BaseRepository, IManufacturerRepository
    {
        public void Create(ManufacturerDto model)
        {
            var entity = model.ToEntity();

            WithContext(context =>
            {
                context.Manufacturers.Add(entity);
                context.SaveChanges();
            });
        }

        public ManufacturerDto GetManufacturer(Guid id)
        {
            ManufacturerDto user = null;
            WithContext(context =>
            {
                user = context.Manufacturers.Single(x => x.Id.Equals(id)).ToDto();
            });

            return user;
        }
        public IEnumerable<ManufacturerDto> GetManufacturer()
        {
            var result = new ManufacturerDto[] { };

            WithContext(context =>
            {
                result = context.Manufacturers
                .Select(x => new ManufacturerDto
                {
                        Id = x.Id,
                        Name = x.Name,
                        Logo = x.Logo
                }).ToArray();
            });

            return result;
        }
    }
}
