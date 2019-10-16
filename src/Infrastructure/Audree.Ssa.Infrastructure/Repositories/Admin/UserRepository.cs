using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audree.Ssa.Core.Contracts.Repositories.Admin;
using Audree.Ssa.Core.Contracts.UnitOfWork;
using Audree.Ssa.Core.Model.Admin;

using Audree.Ssa.Infrastructure.Data;
using Audree.SSA.AppException;
using Microsoft.EntityFrameworkCore;

namespace Audree.Ssa.Infrastructure.Repositories.Admin
{
    public class UserRepository:IUserRepository
    {

       private readonly IUnitOfWork _unitOfWork;
        private readonly ISSADbContexts _context;

        public UserRepository( ISSADbContexts db, IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
            _context = db;
        }
        public  async Task<User> Authenticate(string username, string password)
        {
            using (_unitOfWork)
            {

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    return null;

                var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);

                // check if username exists
                if (user == null)
                    return null;

                // check if password is correct
                if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                    return null;

                // authentication successful
                return user;

            }


        }

        public async Task<List<User>> GetAllAsync()
        {

            using (_unitOfWork)
            {
                return await _context.Users.ToListAsync();
            }
            
        }
      
    public User GetById(int id)
        {
            using (_unitOfWork)
            {
                return _context.Users.Find(id);
            }
        }

        public   async  Task<User> Create(User user, string password)
        {

            using (_unitOfWork)
            {
                if (string.IsNullOrWhiteSpace(password))
                    throw new AppException("Password is required");

                if (_context.Users.Any(x => x.Username == user.Username))
                    throw new AppException("Username " + user.Username + " is already taken");

                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                await _context.Users.AddAsync(user);
                _context.SaveChanges();

                return user;
            }
            
        }
            // validation


            public async  Task Update(User userParam, string password = null)
            {



                using (_unitOfWork)
                {
                    var user =  await _context.Users.FindAsync(userParam.Id);

                    if (user == null)
                        throw new AppException("User not found");

                    if (userParam.Username != user.Username)
                    {
                        // username has changed so check if the new username is already taken
                        if (_context.Users.Any(x => x.Username == userParam.Username))
                            throw new AppException("Username " + userParam.Username + " is already taken");
                    }

                    // update user properties
                    user.FirstName = userParam.FirstName;
                    user.LastName = userParam.LastName;
                    user.Username = userParam.Username;

                    // update password if it was entered
                    if (!string.IsNullOrWhiteSpace(password))
                    {
                        byte[] passwordHash, passwordSalt;
                        CreatePasswordHash(password, out passwordHash, out passwordSalt);

                        user.PasswordHash = passwordHash;
                        user.PasswordSalt = passwordSalt;
                    }
                    _context.Users.Update(user);
                    _context.SaveChanges();
                }
                
            }

            public void Delete(int id)
        {
            using (_unitOfWork)
            {
                var user = _context.Users.Find(id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                }
            }
        }

        // private helper methods

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

    }
}
