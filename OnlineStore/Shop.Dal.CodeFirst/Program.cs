using Store.Dal.CodeFirst;
using Store.Dal.CodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Dal.CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StoreContext db = new StoreContext())
            {
                // создаем два объекта User
                Product user1 = new Product
                {
                    Price = 100000,
                    Name = "Lenovo",
                    Description="Black",
                    Logo= @"https://images.app.goo.gl/EuE1CJ5qUBsbeycU7",
                    Currency="UAH",
                    Category=new Category
                    {
                        Name="Tablet"
                    },
                    Manufacturer=new Manufacturer
                    {
                        Logo= "https://images.app.goo.gl/EuE1CJ5qUBsbeycU7",
                        Name="Lenovo"
                    }
                    
    
                };

                // добавляем их в бд
                db.Products.Add(user1);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");
            }
            Console.Read();
        }
    }
}
