using Book_BL.Repository;
using Book_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_BL.DataManager
{

    public class UserManager : IDataRepository<User>
    {
        readonly BookDBContext _UserContext;
        public UserManager(BookDBContext context)
        {
            _UserContext = context;
        }
        public IEnumerable<User> GetAll()
        {
            return _UserContext.Users.Include("bookUsers").ToList();
        }
        public User Get(int id)
        {
            return _UserContext.Users.Include("bookUsers")
                  .FirstOrDefault(e => e.User_Id == id);
        }
        public void Insert(User entity)
        {
            var addingUser = new User
            {
                Full_Name = entity.Full_Name,
                Enabled = entity.Enabled,
                Last_Login = entity.Last_Login
            };
            _UserContext.Users.Add(addingUser);
            _UserContext.SaveChanges();
        }
        public void Update(User User, User entity)
        {
            User.Full_Name = entity.Full_Name;
            User.Enabled = entity.Enabled;
            User.Last_Login = entity.Last_Login;

            _UserContext.SaveChanges();

        }
        public void Delete(User User)
        {
            _UserContext.Users.Remove(User);
            _UserContext.SaveChanges();
        }
    }
}

