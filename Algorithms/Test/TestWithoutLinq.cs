using System;
using System.Collections.Generic;


namespace Algorithms.Test
{
    public static class TestWithoutLinq
    {
        public static Dictionary<string, List<Book>> AuthorBooks(IEnumerable<Book> books)
        {
            var result = new Dictionary<string, List<Book>>();

            if (books == null)
                return result;

            foreach (var item in books)
            {
                if (result.ContainsKey(item.Author))
                    result[item.Author].Add(item);
                else
                    result.Add(item.Author, new List<Book> { item });
            }
            return result;
        }
        public static Book MaxPagesBook(IEnumerable<Book> books)
        {
            int max = 0;
            Book result = null;

            if (books == null)
                return result;

            foreach (var item in books)
            {
                if (item.Pages > max)
                {
                    max = item.Pages;
                    result = item;
                }

            }
            return result;
        }
        public static Book SecondHigestPagesBook(IEnumerable<Book> books)
        {
            Book result = null;
            Book temp = null;

            if (books == null)
                return result;
            foreach (var item in books)
            {
                if (temp==null || item.Pages > temp.Pages)
                {
                    result = temp;
                    temp = item;
                }
                else if(temp.Pages> item.Pages && result.Pages < item.Pages)
                {
                  
                    result = item;
                }
            }
            return result;
        }
        public static Book FindById(List<Book> books, int id)
        {
            int length = books != null ? books.Count : -1;
            int first, last, mid;
            for (int i = 0; i < length; i++)
            {
                first = i;
                last = length - 1;
                mid = (first + last) / 2;
                while (mid >= 0 && first <= last)
                {
                    if (books[mid].Id == id)
                        return books[mid];
                    else if (books[mid].Id < id)
                        first = mid + 1;
                    else if (books[mid].Id > id)
                        last = mid - 1;
                    mid = (first + last) / 2;
                }

            }
            return null;
        }
        public static IEnumerable<Book> OrderByPages(List<Book> books)
        {
            return Sort(books);

        }
        private static List<Book> Sort(List<Book> books)
        {
            Random r = new Random();
            var less = new List<Book>();
            var greater = new List<Book>();
            if (books==null || books.Count <= 1)
                return books;

            int pos = r.Next(books.Count);
            var pivot = books[pos];
            books.RemoveAt(pos);
            foreach (var x in books)
            {
                if (x.Pages <= pivot.Pages)
                    less.Add(x);
                else
                    greater.Add(x);
            }
            return Concat(Sort(less), pivot, Sort(greater));
        }
        private static List<Book> Concat(List<Book> less, Book pivot, List<Book> greater)
        {
            var sorted = new List<Book>(less);
            sorted.Add(pivot);
            foreach (var i in greater)
                sorted.Add(i);

            return sorted;
        }
    }
}
