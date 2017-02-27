using Rapid.Core.Data;
using Rapid.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapid.Data
{
    public class ProductRepository : IProductRepository
    {
        private RapidDbContext _context;
        private IDatabase _database;

        public ProductRepository(IDatabase database)
        {
            //only in order to create db with entity framework.
            _context = new RapidDbContext();
            _database = database;
        }

        public IEnumerable<Product> GetProductList()
        {
            var result= _context.Products.ToList();
            string sql = "select top 100 * from Products";
            var command = _database.GetSqlStringCommand(sql);
            return _database.ExecuteAndReturn<Product>(command);
        }

        public Product GetById(int id)
        {
            string sql = "select top 100 * from Products where ProductId=@Id";
            var command = _database.GetSqlStringCommand(sql);
            _database.AddParametersFrom(command, new { Id = id });
            return _database.ExecuteAndReturn<Product>(command).FirstOrDefault();
        }

        public int Add(Product product)
        {
            string sql = "insert into Products(ProductName,State)values(@ProductName,@State)";
            var command = _database.GetSqlStringCommand(sql);
            _database.AddParametersFrom(command, new
            {
                ProductName = product.ProductName,
                State = product.State
            });

            return _database.ExecuteNonQueryCommand(command);
        }

        public int Update(Product product)
        {
            string sql = "update Products set ProductName=@ProductName,State=@State, Price=@Price,TaxRate =@TaxRate ,TotalQuantity=@TotalQuantity, TotalAmount=@TotalAmount     where ProductId=@ProductId";
            var command = _database.GetSqlStringCommand(sql);
            _database.AddParametersFrom(command, product);

            return _database.ExecuteNonQueryCommand(command);
        }

        public int Delete(int id)
        {
            string sql = "delete from Products where ProductId=@ProductId";
            var command = _database.GetSqlStringCommand(sql);
            _database.AddParametersFrom(command, new { ProductId = id });

            return _database.ExecuteNonQueryCommand(command);
        }
    }
}
