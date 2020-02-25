using System.Collections.Generic;

namespace eShopSolution.Application.Catalog.zz
{
    public class PagedResult<T>
    {
        public List<T> items { get; set; }

        public int TotalRecord { get; set; }


    }
}
