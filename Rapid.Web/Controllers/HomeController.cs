 using Rapid.Model.ViewModels;
using Rapid.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace Rapid.Web.Controllers
{
    public class HomeController : Controller
    {
   
        private IProductCost _productCost;

        public HomeController(IProductCost productCost)
        {
        
            _productCost = productCost;

        }


        public ActionResult ProductList()
        {
            var productList = _productCost.GetProductList();

            return View(productList);
        }


        public ActionResult Calculate(int? id)
        {
            var product = new ProductViewModel();

            if ((id ?? 0) != 0)
            {
                product = _productCost.GetById(id.Value);
            }

            SelectListItem item;
            List<SelectListItem> myList = new List<SelectListItem>();
            item = new SelectListItem();
            item.Text = "NY";
            item.Value = "NY";
            myList.Add(item);
            item = new SelectListItem();
            item.Text = "NJ";
            item.Value = "NJ";
            item.Selected = true;
            myList.Add(item);
            item = new SelectListItem();
            item.Text = "FL";
            item.Value = "FL";
            myList.Add(item);
            item = new SelectListItem();
            item.Text = "TX";
            item.Value = "TX";
            myList.Add(item);
            item = new SelectListItem();
            item.Text = "MD";
            item.Value = "MD";
            myList.Add(item);

            item = new SelectListItem();
            item.Text = "VA";
            item.Value = "VA";
            myList.Add(item);

            item = new SelectListItem();
            item.Text = "PA";
            item.Value = "PA";
            myList.Add(item);

            item = new SelectListItem();
            item.Text = "Other";
            item.Value = "Other";
            myList.Add(item);



            ViewBag.MyList = myList;
            return View(product);
        
        }



        [HttpPost]
        public ActionResult DependencyInjectionDemo(ProductViewModel model)
        {
            decimal totalCost;
            decimal Tax;


            string GetTax = string.Empty;

            if (!string.IsNullOrWhiteSpace(model.State))
            {
                GetTax = _productCost.StateTotalCost(model.State);
            }

            Tax = Convert.ToDecimal(GetTax);


            if (model.DiscountIndicator == true)
            {
                totalCost = model.Price * model.TotalQuantity * Tax * 9 / 10 / 100;
            }
            else
            { totalCost = model.Price * model.TotalQuantity * Tax / 100; }


            StringBuilder sbCost = new StringBuilder();
            sbCost.Append("You have selected " + model.TotalQuantity + " pieces of product " + model.ProductName + ". This would cost you $" + totalCost + " in total at " + model.State);
       
           

      return View((object)sbCost.ToString());
          
        }


        public ActionResult DependencyInjectionTest()
        {
            List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();

            list.Add(new KeyValuePair<string, int>("_productCost_1",  _productCost.GetHashCode()));

            var _productCostr_2 = ServiceLocator.Resolve<IProductCost>();
            list.Add(new KeyValuePair<string, int>("_productCost_2", _productCostr_2.GetHashCode()));

            list.Add(new KeyValuePair<string, int>("productCost_1", _productCost.GetProductRepositoryHashCode()));

            list.Add(new KeyValuePair<string, int>("productCost_2", _productCostr_2.GetProductRepositoryHashCode()));

            return View(list);
        }
 

        public ActionResult WebApiDemo()
        {
            return View();
        }

        public ActionResult ThrowError()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThrowError(int? id)
        {
            _productCost.ThrowError();
            return View();
        }
    }
}
