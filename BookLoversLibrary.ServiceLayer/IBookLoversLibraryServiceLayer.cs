using BookLoversLibrary.Repo.DTOs;
using BookLoversLibrary.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoversLibrary.ServiceLayer
{
    public interface IBookLoversLibraryServiceLayer
    {
        //To Add New User
        public Task<int> AddUser(User user);

        //To Get All User
        public Task<IEnumerable<User>> GetUsers();

        public Task<int> RegisterAdmin(LoginDTO loginDTO);
    }
}
