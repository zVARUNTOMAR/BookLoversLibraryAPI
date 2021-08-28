using BookLoversLibrary.Repo.DTOs;
using BookLoversLibrary.Repo.Models;
using BookLoversLibrary.ServiceLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLoversLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly IBookLoversLibraryServiceLayer _bookLibraryServiceLayer;
        public LibraryController(IBookLoversLibraryServiceLayer bookLoversLibraryServiceLayer)
        {
            _bookLibraryServiceLayer = bookLoversLibraryServiceLayer;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user) {

            int id = 0;
            id = await _bookLibraryServiceLayer.AddUser(user);
            if (id!=-1)
            {
                return Ok(id);
            }
            else {
                return BadRequest("Response from this mobile number already recorded");
            }
        }

        
        [HttpGet]
        public async Task<IActionResult> GetUsers() {

            return Ok(await _bookLibraryServiceLayer.GetUsers());
        }

        [HttpPost("register")]

        public async Task<IActionResult> RegisterAdmin(LoginDTO loginDTO) {

            int adminId = await _bookLibraryServiceLayer.RegisterAdmin(loginDTO);
            return Ok(adminId);
        }
    }
}
