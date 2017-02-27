using Microsoft.Practices.Unity;
using Rapid.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rapid.Model.ViewModels;

namespace Rapid.Service
{
    public abstract class StateBaseCost
    {
        [Dependency]
        public IConfigGateway ConfigGateway { get; set; }

        public virtual string TotalCost()
        {
            return "105";
            // return string.Format("{0} Your total amount for this item is $", getprefix());
        }

        //internal virtual string getprefix()
        //{
        //    return ConfigGateway.GetAppSetting<string>(Constants.ConfigAppSettings.ANIMAL_PREFIX);
           // return "test";
        //}
    }
}
