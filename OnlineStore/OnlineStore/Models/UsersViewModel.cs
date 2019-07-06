using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class UsersViewModel
    {
        public string SearchQuery { get; set; }
        public IEnumerable<UserViewModel> Users { get; set; }
    }
}