using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Common.User
{
    public class UserFilterOption
    {
        public string SearchQuery { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public bool CanDrink { get; set; }
    }
}
