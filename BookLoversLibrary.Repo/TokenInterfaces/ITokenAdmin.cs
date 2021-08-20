using BookLoversLibrary.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLoversLibrary.Repo.TokenInterfaces
{
    public interface ITokenAdmin
    {
        public string CreateToken(Admin admin);
    }
}
