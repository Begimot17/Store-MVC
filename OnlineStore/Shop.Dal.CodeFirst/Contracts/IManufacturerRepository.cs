﻿using Store.Dtos.Data.Manufacturer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.CodeFirst.Contracts
{
    public interface IManufacturerRepository
    {
        ManufacturerDto GetManufacturer(Guid id);
        IEnumerable<ManufacturerDto> GetManufacturer();

    }
}