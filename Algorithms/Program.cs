using Algorithms.Test;
using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var result1 = TestWithLinq.AuthorBooks(Source.Books);
            var result2 = TestWithLinq.MaxPagesBook(Source.Books);
            var result3 = TestWithLinq.OrderByPages(Source.Books);
            var result4 = TestWithoutLinq.AuthorBooks(Source.Books);
            var result5 = TestWithoutLinq.OrderByPages(Source.Books);
            var result6 = TestWithoutLinq.FindById(Source.Books, 6);
            var result7 = TestWithLinq.SecondHigestPagesBook(Source.Books);
            var result8 = TestWithoutLinq.SecondHigestPagesBook(Source.Books);
            var result9 = TestWithoutLinq.MaxPagesBook(Source.Books);
        }
    }
}
