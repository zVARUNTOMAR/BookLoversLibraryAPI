using BookLoversLibrary.Repo.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLoversLibrary.Repo.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using BookLoversLibrary.Repo.TokenInterfaces;

namespace BookLoversLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly LibraryDbContext _dataContext;
        private readonly ITokenAdmin _tokenAdmin;
        public AuthController(LibraryDbContext dataContext,ITokenAdmin tokenAdmin)
        {
            _dataContext = dataContext;
            _tokenAdmin = tokenAdmin;
        }
        [HttpPost,Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            if (login == null) {
                return BadRequest("Invalid Client Request");
            }
            else {
                var user = await _dataContext.admins.SingleOrDefaultAsync(x => x.Username == login.Username);

                if (user == null)
                {
                    return Unauthorized("Invalid Username");
                }
                else {
                    using var hmac = new HMACSHA512(user.PasswordSalt);

                    var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));

                    for(int i = 0; i < computedHash.Length; i++)
                    {
                        if (computedHash[i]!= user.PasswordHash[i]) {
                            return Unauthorized("Invalid Passoword");
                        }
                    }

                    Admin admin = new Admin();
                    admin.AdminId = user.AdminId;
                    admin.PasswordHash = user.PasswordHash;
                    admin.PasswordSalt = user.PasswordSalt;
                    admin.Username = user.Username;

                    return Ok(new UserDTO
                    {
                        Username = login.Username,
                        Token = _tokenAdmin.CreateToken(admin)
                    });
                }
            }
        }
    }
}
