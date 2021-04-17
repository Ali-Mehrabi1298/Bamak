using BookAudiomak.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BookAudiomak.Data.Repository
{
    public interface IUserRepository
    {
        //bool IsExistUserByEmail(string email);
        //void AddUser(Users users);

        IdentityUser GetUserForLogin(string Email, string password);
        //object GenerateEmailConfirmationTokenAsync(Users user);

    }

    public class UserRepository : IUserRepository
    {
        private Bookmakcontex _context;
        public UserRepository(Bookmakcontex context)
        {
            _context = context;
        }

        //public void AddUser(Users users)
        //{
        //  _context.Add(users);
        //    _context.SaveChanges();
        //}


        public IdentityUser GetUserForLogin(string Email, string password)
        {
            return _context.Users.SingleOrDefault(U => U.Email == Email && U.PasswordHash == password);
        }



        //public bool IsExistUserByEmail(string email)
        //{
        //    return _context.users.Any(o => o.Email == email);

        //}


    }
}
