﻿using BookLoversLibrary.Repo.Models;
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
    }
}
