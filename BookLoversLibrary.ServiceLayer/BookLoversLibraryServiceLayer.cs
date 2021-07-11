using BookLoversLibrary.Repo;
using BookLoversLibrary.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoversLibrary.ServiceLayer
{
    public class BookLoversLibraryServiceLayer : IBookLoversLibraryServiceLayer
    {
        IBookLoversLibraryRepoLayer _bookLoversLibraryRepoLayer;
        public BookLoversLibraryServiceLayer(IBookLoversLibraryRepoLayer bookLoversLibraryRepoLayer)
        {
            _bookLoversLibraryRepoLayer = bookLoversLibraryRepoLayer;
        }

        public async Task<int> AddUser(User user)
        {
            return await _bookLoversLibraryRepoLayer.AddUser(user);
        }
    }
}
