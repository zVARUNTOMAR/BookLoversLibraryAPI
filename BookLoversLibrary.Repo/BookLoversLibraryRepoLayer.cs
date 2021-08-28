using BookLoversLibrary.Repo.DTOs;
using BookLoversLibrary.Repo.Models;
using BookLoversLibrary.Repo.TokenInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookLoversLibrary.Repo
{
    public class BookLoversLibraryRepoLayer : IBookLoversLibraryRepoLayer
    {
        private readonly LibraryDbContext _dbContext;

        private readonly ITokenAdmin _tokenService;
        public BookLoversLibraryRepoLayer(LibraryDbContext dbContext,ITokenAdmin tokenService)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
        }

        public async Task<int> RegisterAdmin(LoginDTO loginDTO) {

            Admin admin = new Admin();

            using var hmac = new HMACSHA512();
            var ad = new Admin {
                Username = loginDTO.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password)),
                PasswordSalt = hmac.Key
            };

            _dbContext.admins.Add(ad);
            await _dbContext.SaveChangesAsync();
            return ad.AdminId;
        }
        public async Task<int> AddUser(User user)
        {
            if (await _dbContext.users.AnyAsync(x => x.MobileNumber == user.MobileNumber)) {
                return -1;
            }
            else {
                user.ResponseTime = DateTime.Now;
                await _dbContext.users.AddAsync(user);
                await _dbContext.SaveChangesAsync();

                return user.Id;
            }
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            var responses =  await _dbContext.users.ToListAsync();
            responses.Reverse();
            return responses;
        }
    }
}
