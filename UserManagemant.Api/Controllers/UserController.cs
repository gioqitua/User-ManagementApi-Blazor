using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User_Management_BLL.DTOs;
using User_Management_BLL.Services;

namespace UserManagemant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        readonly ICrudService<UserDto> _userService;
        public UserController(ICrudService<UserDto> userService) => _userService = userService;

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll() => await Task.FromResult(Ok(_userService.GetAll()));
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int Id) => await Task.FromResult(Ok(_userService.GetById(Id)));

        [HttpPost("Add")]
        public async Task<IActionResult> Add(UserDto user)
        {
            await Task.Run(() =>
            {
                _userService.Save(user);
            });

            return Ok("User Added");
        }
        [HttpDelete("Update")]
        public async Task<IActionResult> Update(UserDto user)
        {
            await Task.Run(() =>
            {
                _userService.Save(user);
            });

            return Ok("User Added");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            await Task.Run(() =>
            {
                _userService.Delete(Id);
            });

            return Ok("User Removed");
        }
    }
}
