
using System;
using System.Collections.Generic;
using System.Text;
using eShopSolution.Application.Catalog.DTOs;
using eShopSolution.Application.Catalog.DTOs.Manage;
using eShopSolution.Application.Catalog.DTOs.Public;
using eShopSolution.Application.Catalog.zz;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        public PagedResult<ProductViewModel> GetAllByCategory(GetProductPagingRequest request);
    }
}
