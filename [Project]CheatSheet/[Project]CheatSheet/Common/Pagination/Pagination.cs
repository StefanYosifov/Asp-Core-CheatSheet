namespace _Project_CheatSheet.Common.Pagination
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class Pagination<T> : List<T>
    {
        private const byte PageSize = 12;

        public Pagination(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            AddRange(items);
        }

        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public static async Task<Pagination<T>> CreateAsync(IQueryable<T> source, int pageIndex = 1,
            byte itemsPerPage = PageSize)
        {
            var count = await source.CountAsync();
            if (pageIndex <= 0)
            {
                pageIndex = 1;
            }

            var items = await source.Skip((pageIndex - 1) * itemsPerPage).Take(itemsPerPage).ToListAsync();
            return new Pagination<T>(items, count, pageIndex, itemsPerPage);
        }
    }
}