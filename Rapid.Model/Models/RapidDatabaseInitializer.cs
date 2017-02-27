using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Rapid.Model.Models
{
    public class RapidDatabaseInitializer : DropCreateDatabaseAlways<RapidDbContext>
    {
        protected override void Seed(RapidDbContext context)
        {
            initializer(context);
            base.Seed(context);
        }

        private void initializer(RapidDbContext context)
        {
            var ids = Enumerable.Range(1, 10);

            foreach (var id in ids)
            {
                var product = new Product()
                {
                    ProductId = id,
                    ProductName = "Item " + id.ToString(),
                    Price = id*8,
                    DiscountIndicator= (id%2 == 0 ? true : false),
                
                };

           
                context.Products.Add(product);
            }
        }
    }
}
