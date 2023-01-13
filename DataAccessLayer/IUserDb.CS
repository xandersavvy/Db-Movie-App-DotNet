using MovieDbAngDotNet.Models;

namespace MovieDbAngDotNet.DataAccessLayer
{
    public interface IUserDb
    {
        Task<UserDb?> Login(string email, string password);
        void Register(string email,string name, string password);

        Task<bool> UserAlreadyExists(string email);
        bool IsEmail(string email);
        bool IsStrongPassword(string password);
    }
}
