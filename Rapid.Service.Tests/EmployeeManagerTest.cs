using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rapid.Data;
using Rapid.Model.Models;
using Rapid.Model.ViewModels;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapid.Service.Tests
{
    [TestClass]
    public class EmployeeManagerTest
    {
        private IEmployeeRepository _employeeRepository;
        private IProductCost _productRepository;
        private EmployeeManager _manager;
        private ProductCost _cost;

        [TestInitialize]
        public void TestInitialize()
        {
            MapConfig.RegisterMappings();
            _employeeRepository = MockRepository.GenerateStub<IEmployeeRepository>();
            _productRepository = MockRepository.GenerateStub<IProductCost>();
            _manager = MockRepository.GeneratePartialMock<EmployeeManager>(_employeeRepository);
            _cost = MockRepository.GeneratePartialMock<ProductCost>(_productRepository);
        }

        [TestMethod, TestCategory("Rapid.Service")]
        public void GetProductList()
        {
            //arrange
        
        var productList=new List<Product>()
        {
        
        new Product()
        {
        ProductId=1,
        ProductName="Item 1",
        Price=8
        },
        new Product()
        {
        ProductId=2,
        ProductName="Item 2",
        Price=16
        }
        };

        _productRepository.Stub(t => t.GetProductList()).Return(productList);

            //act
            var actual = _cost.GetProductList();

            //assert
            Assert.AreEqual(new DateTime(2015, 12, 7), actual.First().Birthday);
            Assert.AreEqual(1, actual.First().EmployeeId);
            Assert.AreEqual("^&*", actual.First().LastName);
            Assert.AreEqual("(&^&*(", actual.First().FirstName);
            Assert.AreEqual(new DateTime(2015, 12, 8), actual.Last().Birthday);
            Assert.AreEqual(2, actual.Last().EmployeeId);
            Assert.AreEqual("^@@&*", actual.Last().LastName);
            Assert.AreEqual("(&^&~!~!*(", actual.Last().FirstName);
            _employeeRepository.AssertWasCalled(t => t.GetEmployeeList());



        }

       
    }
}
