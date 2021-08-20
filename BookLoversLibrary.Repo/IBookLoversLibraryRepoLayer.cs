using BookLoversLibrary.Repo.DTOs;
using BookLoversLibrary.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoversLibrary.Repo
{
    public interface IBookLoversLibraryRepoLayer
    {
        //To Add New User
        public Task<int> AddUser(User user);

        //To Show Users
        public Task<IEnumerable<User>> GetUsers();

        //Register Admin
        public Task<int> RegisterAdmin(LoginDTO loginDTO);
    }
}
