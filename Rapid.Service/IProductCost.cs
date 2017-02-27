using Rapid.Data;
using Rapid.Model.Models;
using Rapid.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rapid.Service
{
    public interface IProductCost
    {
        IEnumerable<ProductViewModel> GetProductList();
        ProductViewModel GetById(int id);
        int Add(ProductViewModel product);
        int Update(ProductViewModel product);
        int Delete(int id);
        int GetProductRepositoryHashCode();

        string StateTotalCost(String State);
        string ThrowError();
    }
}
