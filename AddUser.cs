using AddUser.API.Models;
using AddUser.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddUser.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddUserController : ControllerBase
    {
        private readonly IUserRepository _UserRepository;

        public AddUserController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        [HttpGet("")]
        
        public async Task<IActionResult> GetAllUser()
        {
            var User = await _UserRepository.GetAllUserAsync();
            return Ok(User);
        }

        [HttpGet("{Userid}")]
        public async Task<IActionResult> GetUserById([FromRoute] int Userid)
        {
            var Userid = await _UserRepository.GetUserByIdAsync(Userid);
            if (Userid == null)
            {
                return NotFound();
            }
            return Ok(Userid);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewUser([FromBody] IDUser IDUser)
        {
            var IdUser = await _UserRepository.AddUserAsync(IDUser);
            return CreatedAtAction(nameof(GetUserById), new { IdUser = IdUser, controller = "User" }, IdUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Updateid([FromBody] IDUser IDUser, [FromRoute] int id)
        {
            await _UserRepository.UpdateidkAsync(id, IDUser);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUserPatch([FromBody] JsonPatchDocument IDUser, [FromRoute] int id)
        {
            await _UserRepository.UpdateUserPatchAsync(id, IDUser);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            await _UserRepository.DeleteUserAsync(id);
            return Ok();
        }
    }
}