using System.Linq;
using System.Linq.Expressions;
using Identity.Data.Extensions;
using Identity.Domain.Models;
using Identity.Domain.Repositories;
using static Identity.Domain.Models.User;

namespace Identity.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
            
        }

        public void Delete(int id)
        {
            if (!Exists(id))
                throw new System.Exception("User does Not Exists");

            _context.Users.Remove(GetById(id));
            _context.SaveChanges();
        }

        public virtual IQueryable<User> Get(Expression<System.Func<User, bool>> filter = null)
        {
            filter ??= x => true;
            var query = _context.Users.Where(filter);

            return query;
        }

        public User GetByEmailAndPassword(string email, string encriptedPassword)
        {
            var user = Get(x => x.Email == email && x.Password == encriptedPassword)
                .SingleOrDefault();

            return user ?? NullUser;
        }

        public User GetById(int id)
        {
            var user = Get(u => u.Id == id)
                .DefaultIfEmpty(User.NullUser)
                .SingleOrDefault();

            return user;
        }

        public string GetSha256EncryptedPassword(string Password)
        {
            throw new System.NotImplementedException();
        }

        public void Save(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Update<TData>(int id, TData updatedData)
        {
            var user = GetById(id);

            if (user == NullUser)
                throw new System.Exception("Not found");

            _context.Entry(user).CurrentValues.SetValues(updatedData);
        }

        bool Exists(int id) => _context.Users.Any(user => user.Id == id);
    }
}