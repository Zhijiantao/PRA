using Rapid.Model.ViewModels;
using Rapid.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Rapid.Web.Controllers
{
    public class ValuesController : ApiController
    {
        private IProductCost _productCost;

        public ValuesController(IProductCost productCost)
        {
            _productCost = productCost;
        }

        // GET api/values
        public IEnumerable<ProductViewModel> Get()
        {
            return _productCost.GetProductList();
        }

        // GET api/values/5
        public ProductViewModel Get(int id)
        {
            return _productCost.GetById(id);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
