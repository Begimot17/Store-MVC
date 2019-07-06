using Store.Dtos.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dtos.Data.User
{
    public class FullUserDto
    {
        public IEnumerable<ShortDto> Articles { get; set; }
    }
}
