
using Book_BL.Repository;
using Book_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_BL.DataManager
{
    public class BookUserManager : IDataRepository<BookUser>
    {
        readonly BookDBContext _BookUserContext;

        public BookUserManager(BookDBContext context)
        {
            _BookUserContext = context;
        }
        public void Delete(BookUser entity)
        {
            _BookUserContext.Remove(entity);
        }

       

        public BookUser Get(int id)
        {
            return _BookUserContext.bookUsers
                  .FirstOrDefault(e => e.BookUserId == id);
        }
        public IEnumerable<BookUser> GetAll()
        {
            return _BookUserContext.bookUsers.ToList();
        }

       

       

        public void Insert(BookUser entity)
        {
            var en = new BookUser()
            {
                BookId = entity.BookId,
                UserId = entity.UserId
            };
            _BookUserContext.bookUsers.Add(en);
            _BookUserContext.SaveChanges();
        }
        public void Update(BookUser dbEntity, BookUser entity)
        {
            dbEntity.UserId = entity.UserId;
            dbEntity.BookId = entity.BookId;
            _BookUserContext.bookUsers.Update(dbEntity);
        }
    }
}