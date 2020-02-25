using System;
using System.Collections.Generic;
using System.Text;
using eShopSolution.Application.Dtos;

namespace eShopSolution.Application.Catalog.DTOs.Public
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        public List<int> CategoryIds { get; set; }
    }
}
