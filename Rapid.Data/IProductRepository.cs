using Rapid.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rapid.Data
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProductList();
        Product GetById(int id);
        int Add(Product product);
        int Update(Product product);
        int Delete(int id);


    }
}
