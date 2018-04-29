using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Test
{

    public static class TestWithLinq
    {

        public static Dictionary<string, List<Book>> AuthorBooks(IEnumerable<Book> books)
        {
            return books.ToLookup(x => x.Author).ToDictionary(x => x.Key, x => x.ToList());
        }
        public static Book MaxPagesBook(IEnumerable<Book> books)
        {
            var max = books.Max(y => y.Pages);
            return books.Where(x => x.Pages == max).FirstOrDefault();
        }
        public static Book SecondHigestPagesBook(IEnumerable<Book> books)
        {
            return books.OrderByDescending(x => x.Pages).Skip(1).FirstOrDefault();
        }
        public static Book FindById(List<Book> books, int id)
        {
            return books.Where(x => x.Id == id).FirstOrDefault();
        }
        public static IEnumerable<Book> OrderByPages(IEnumerable<Book> books)
        {
            return books.OrderBy(x => x.Pages).ToList();

        }
    }
}
