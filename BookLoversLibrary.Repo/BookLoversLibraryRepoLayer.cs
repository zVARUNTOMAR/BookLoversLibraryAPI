using BookLoversLibrary.Repo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoversLibrary.Repo
{
    public class BookLoversLibraryRepoLayer : IBookLoversLibraryRepoLayer
    {
        private readonly LibraryDbContext _dbContext;
        public BookLoversLibraryRepoLayer(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddUser(User user)
        {
            if (await _dbContext.users.AnyAsync(x => x.MobileNumber == user.MobileNumber)) {
                return -1;
            }
            else {
                await _dbContext.users.AddAsync(user);
                await _dbContext.SaveChangesAsync();

                return user.Id;
            }
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _dbContext.users.ToListAsync();
        }
    }
}
