using BookLoversLibrary.Repo.Models;
using BookLoversLibrary.ServiceLayer;
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

            if (await _bookLibraryServiceLayer.AddUser(user)!=-1)
            {
                return Ok("Your Response Added Successfully");
            }
            else {
                return BadRequest("Response from this mobile number already recorded");
            }
        }
    }
}
