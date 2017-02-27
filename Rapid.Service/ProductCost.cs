using AutoMapper;
using Microsoft.Practices.Unity;
using Rapid.Core.Logging;
using Rapid.Data;
using Rapid.Model.Models;
using Rapid.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapid.Service
{
    public class ProductCost : IProductCost
    {
        private IProductRepository _productRepository;

        public ProductCost(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductViewModel> GetProductList()
        {
            var productList = _productRepository.GetProductList();
            return Mapper.Map<IEnumerable<ProductViewModel>>(productList);
        }

        public ProductViewModel GetById(int id)
        {
            var product = _productRepository.GetById(id);
            return Mapper.Map<ProductViewModel>(product);

        }

        public int Add(ProductViewModel productViewModel)
        {
            var product = Mapper.Map<Product>(productViewModel);
            return _productRepository.Add(product);
        }

        public int Update(ProductViewModel productViewModel)
        {
            var product = Mapper.Map<Product>(productViewModel);
            return _productRepository.Update(product);
        }

        public int Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public int GetProductRepositoryHashCode()
        {
            return _productRepository.GetHashCode();
        }

        /// <summary>
        /// DI Test
        /// </summary>
        public string StateTotalCost(string State)
        {
            return ServiceLocator.Resolve<IState>(State).TotalCost();
        }

        public string ThrowError()
        {
            try
            {
                int i = 0;
                var j = 10 / i;
                return j.ToString();
            }
            catch (Exception ex)
            {
                RapidLogger.Error(ex, "Jason's test error");
                throw ex;
            }
        }

        internal virtual void save(ProductViewModel productViewModel, string method)
        {
            var product = Mapper.Map<Product>(productViewModel);

            if (method == "Get")
            {
                _productRepository.GetById(product.ProductId);
            }
            else if (method == "Update")
            {
                if (product.ProductId == 0)
                {
                    _productRepository.Add(product);
                }
                else
                {
                    _productRepository.Update(product);
                }
            }
            else if (method == "Delete")
            {
                _productRepository.Delete(product.ProductId);
            }
        }
    }
}
