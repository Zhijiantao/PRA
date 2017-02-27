using AutoMapper;
using Rapid.Model.Models;
using Rapid.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapid.Service
{
    public static class MapConfig
    {
        public static void RegisterMappings()
        {
            
            Mapper.CreateMap<Product, ProductViewModel>()
              .ForMember(t => t.ProductId, opt => opt.MapFrom(s => s.ProductId))
              .ForMember(t => t.ProductName, opt => opt.MapFrom(s => s.ProductName))
              .ForMember(t => t.Price, opt => opt.MapFrom(s => s.Price))
               .ForMember(t => t.State, opt => opt.MapFrom(s => s.State))
              .ForMember(t => t.TaxRate, opt => opt.Ignore());

            Mapper.CreateMap<ProductViewModel, Product>()
                .ForMember(t => t.ProductId, opt => opt.MapFrom(s => s.ProductId))
                .ForMember(t => t.ProductName, opt => opt.MapFrom(s => s.ProductName))
                .ForSourceMember(t => t.TaxRate, opt => opt.Ignore());
        }

        internal static string combineName(string lastName, string firstName)
        {
            return string.Format("{0}, {1}", lastName, firstName);
        }

        internal static List<string> splitName(string fullName)
        {
            var names = fullName.Split(',').Where(t => !string.IsNullOrWhiteSpace(t)).Select(t => t.Trim()).ToList();
            if (names.Count == 0)
            {
                names.Add(string.Empty);
            }
            if (names.Count == 1)
            {
                names.Add(string.Empty);
            }
            return names;
        }

    }
}
