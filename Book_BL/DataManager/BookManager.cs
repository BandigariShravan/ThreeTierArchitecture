using Book_BL.Repository;
using Book_DAL.Models;
using Microsoft.EntityFrameworkCore;
namespace Book_BL.DataManager
{

    public class BookManager : IDataRepository<Book>
    {
        readonly BookDBContext _BookContext;
        public BookManager(BookDBContext context)
        {
            _BookContext = context;
        }
        public IEnumerable<Book> GetAll()
        {
            return _BookContext.Books.ToList();
        }
        public Book Get(int id)
        {
            return _BookContext.Books.Include("bookUsers")
                  .FirstOrDefault(e => e.Book_Id == id);
        }
        public void Insert(Book entity)
        {
            var adding = new Book
            {
                Book_Name = entity.Book_Name,
                Author = entity.Author,
                Published_Time = entity.Published_Time,
                ISBN = entity.ISBN,
            };
            
            _BookContext.Add(adding);


        }
        public void Update(Book Book, Book entity)
        {
            Book.Book_Name = entity.Book_Name;
            Book.Author = entity.Author;
            Book.Published_Time = entity.Published_Time;
            Book.ISBN = entity.ISBN;
           
            _BookContext.SaveChanges();
        }
        public void Delete(Book Book)
        {
            _BookContext.Books.Remove(Book);
            _BookContext.SaveChanges();
        }
    }

}