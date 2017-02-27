using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Rapid.Model.ViewModels;
using Rapid.Data;

namespace Rapid.Service
{
    public class TXFLTax : StateBaseCost, IState
    {

        public override string TotalCost()
        {
            return "100";
        
        }
    
    }
}
