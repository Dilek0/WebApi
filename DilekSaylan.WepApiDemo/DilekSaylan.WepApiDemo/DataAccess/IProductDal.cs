using DilekSaylan.WepApiDemo.Entities;
using DilekSaylan.WepApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DilekSaylan.WepApiDemo.DataAccess
{
    public interface IProductDal :IEntityRepository<Product> 
    {
        List<ProductModel> GetProductsWithDetails();
    }
}
