using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dtos.Data.User
{
    public class UserFilterOptions
    {
        public string SearchQuery { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public bool CanDrink { get; set; }
    }
}
