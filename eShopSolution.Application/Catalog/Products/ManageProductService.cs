using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShopSolution.Application.Catalog.DTOs;
using eShopSolution.Application.Catalog.DTOs.Manage;
using eShopSolution.Application.Catalog.DTOs.Public;
using eShopSolution.Application.Catalog.zz;
using eShopSolutionData.EF;
using eShopSolutionData.Entities;
using eShopSolutionUtilties.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace eShopSolution.Application.Catalog.Products
{
    class ManageProductService : IMangeProductService
    {
        private IMangeProductService _mangeProductServiceImplementation;


        private readonly EShopDBContext _context;

        public ManageProductService(EShopDBContext context)
        {
            _context = context;
        }


        public async Task<int> Create(ProductCreateRequest request)
        {

            var product = new Product()
            {
                OriginalPrice = request.OriginalPrice,
                Price = request.Price,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Details = request.Details,
                        SeoAlias = request.SeoAlias,
                        SeoDescription = request.SeoDescription,
                        LanguageId = request.LanguageId
                    }
                }

            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return await _mangeProductServiceImplementation.Create(request);
        }

        public Task<int> Update(ProductUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new EShopException($"Cant find a product have id {productId}");
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }


        public Task<bool> UpdatePrice(int productId, decimal pice)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateStock(int productId, int addedQuantity)
        {
            throw new NotImplementedException();
        }

        public async Task AddViewCount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            //1 select join
            var query = from p in _context.Products
                join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                join c in _context.Categories on pic.CategoryId equals c.Id
                select new
                {
                    p, pt,pic
                };
            //2 filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));
            
            if (request.CategoryIds.Count > 0)
            {
                query = query.Where(x => request.CategoryIds.Contains(x.pic.CategoryId));
            }

            //3 paging
            int totalRow = await query.CountAsync();

            var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x=> new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount
                    
                }).ToListAsync();

            //4 select and projection

            var result = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                items = await  data

            };

            return result;


        }

        public Task<int> Delete(ProductDeleteRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
