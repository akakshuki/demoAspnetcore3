using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eShopSolution.Application.Catalog.DTOs;
using eShopSolution.Application.Catalog.DTOs.Manage;
using eShopSolution.Application.Catalog.DTOs.Public;
using eShopSolution.Application.Catalog.zz;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IMangeProductService
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);


        Task<bool> UpdatePrice(int productId, decimal pice);

        Task<bool> UpdateStock(int productId, int addedQuantity);

        Task AddViewCount(int productId);

        Task<List<ProductViewModel>> GetAll();

       Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);
      
    }
}
