using BCrypt.Net;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MovieDbAngDotNet.Models;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace MovieDbAngDotNet.DataAccessLayer
{
    public class UserDataAccess : IUserDb
    {
        private readonly MoviesContext _context;
        public UserDataAccess(MoviesContext context) {
            this._context = context;
        }
        public async Task<UserDb?> Login(string email, string password)
        {
            try {
                UserDb? userDb = await _context.UserDbs.FirstOrDefaultAsync(x => x.Email == email);
                if(userDb != null && BCrypt.Net.BCrypt.Verify(password,userDb.Password)) {
                    return userDb;
                }
                return null;    
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void Register(string email, string name, string password)
        {
            try {
                    password = BCrypt.Net.BCrypt.HashPassword(password);
                    UserDb userDb = new(email, name, password);
                    _context.UserDbs.Add(userDb);
                    _context.SaveChanges();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        public async Task<bool> UserAlreadyExists(string email)
        {
            try
            {
                UserDb? userDb = await _context.UserDbs.FirstOrDefaultAsync(x => x.Email == email);
                return userDb == null;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool IsEmail(string email)
        {
            try { 
                MailAddress mailAddress = new(email);
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        public bool IsStrongPassword(string password)
        {
            return true;
            //return Regex.IsMatch(password,(@"^.* (?=.{ 8,})(?=.*[\d])(?=.*[\W]).*$"));
        }

    }
}
