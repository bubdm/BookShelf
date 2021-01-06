using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace BookShelf
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Year { get; set; }
        public string Pages { get; set; }

        public List<Book> books = new List<Book>();

        public void FillList()
        {
        
            XElement xTree = XElement.Load(@"books.xml");
            IEnumerable<XElement> elements = xTree.Elements();

            foreach (XElement el in elements)
            {
                Book book = new Book();
                IEnumerable<XElement> props = el.Elements();
                foreach (XElement p in props)
                {
                    if (p.Name.ToString().ToLower() == "title")
                    {
                        book.Title = p.Value;
                    }
                    else if (p.Name.ToString().ToLower() == "author")
                    {
                        book.Author = p.Value;
                    }
                    else if (p.Name.ToString().ToLower() == "publisher")
                    {
                        book.Publisher = p.Value;
                    }
                    else if (p.Name.ToString().ToLower() == "year")
                    {
                        book.Year = p.Value;
                    }
                    else if (p.Name.ToString().ToLower() == "pages")
                    {
                        book.Pages = p.Value;
                    }
                }

                books.Add(book);               
            }
            //DisplayResults(books, "All books: \n");         
        }

        public void OrderByTitle()
        {
            IEnumerable<Book> titleOrder = books.AsQueryable().OrderBy(book => book.Title);
            Console.WriteLine("Books sorted by title: \n");
            foreach (Book book in titleOrder)
            {
                DisplayResult(book);
            }
                                
        }

        public void DisplayResult(Book result)
        {
            Console.WriteLine("Title: {0}\tAuthor: {1}\nPublisher: {2}\tYear: {3}\nNo of pages: {4}\n", result.Title, result.Author, result.Publisher, result.Year, result.Pages);
        }

        public void DisplayResults(List<Book> result, string title)
        {
            Console.WriteLine(title);
            foreach (Book b in result)
            {
                Console.WriteLine("Title: {0}\tAuthor: {1}\nPublisher: {2}\tYear: {3}\nNo of pages: {4}\n", b.Title, b.Author, b.Publisher, b.Year, b.Pages);
            }
        }

    }

}
