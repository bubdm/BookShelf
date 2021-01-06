using BookShelf;

namespace BooksShelf
{
    class Program
    {
        
        static void Main(string[] args)
        {

            Book bookList = new Book();
            bookList.FillList();
            bookList.OrderByTitle();
            
        }

       
    }
}
