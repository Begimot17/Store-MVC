using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.CodeFirst.Repository
{
    public class BaseRepository
    {
        protected void WithContext(Action<StoreContext> handler)
        {
            using (var context = new StoreContext())
            {
                handler(context);
            }
        }
    }
}
