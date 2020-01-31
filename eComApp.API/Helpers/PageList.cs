using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace eComApp.API.Helpers
{
    public class PagedList<T> : List<T>
    {
        public PagedList(List<T> items)
        {
            this.AddRange(items);
        }
        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source)
        {
            var items = await source.ToListAsync();
            return new PagedList<T>(items);
        }
    }
}