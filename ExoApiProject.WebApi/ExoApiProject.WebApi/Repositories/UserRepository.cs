using ExoApiProject.WebApi.Contexts;
using ExoApiProject.WebApi.Interfaces;
using ExoApiProject.WebApi.Models;

namespace ExoApiProject.WebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ExoApiProjectContext _exoApiProjectContext;
        public UserRepository(ExoApiProjectContext context)
        {
            _exoApiProjectContext = context;
        }

        public void Delete(int Id)
        {
            User researchedUser = _exoApiProjectContext.Users.Find(Id);
            _exoApiProjectContext.Users.Remove(researchedUser);
            _exoApiProjectContext.SaveChanges();
        }

        public List<User> ListUsers()
        {
            return _exoApiProjectContext.Users.ToList();
        }

        public User Login(string email, string password)
        {
            return _exoApiProjectContext.Users.FirstOrDefault(u => u.Email == email && u.PassWrd == password);
        }

        public void Register(User user)
        {
            _exoApiProjectContext.Users.Add(user);
            _exoApiProjectContext.SaveChanges();
        }

        public User SearchById(int Id)
        {
            return _exoApiProjectContext.Users.Find(Id);
        }

        public void Update(int Id, User user)
        {
            User researchedUser = _exoApiProjectContext.Users.Find(Id);
            {
                if (researchedUser != null)
                {
                    researchedUser.Email= user.Email;
                    researchedUser.PassWrd= user.PassWrd;
                    researchedUser.Category= user.Category;
                }
            }
        }
    }
}
