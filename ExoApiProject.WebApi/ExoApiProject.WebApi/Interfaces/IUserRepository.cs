using ExoApiProject.WebApi.Models;

namespace ExoApiProject.WebApi.Interfaces
{
    public interface IUserRepository
    {
        List<User> ListUsers();
        void Register(User user);
        void Update(int Id, User user);
        void Delete(int Id);
        User SearchById(int Id);
        User Login(string email, string password);
    }
}
