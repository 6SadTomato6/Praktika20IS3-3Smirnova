using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using BusinessLogic.Interfaces;

namespace SmirnovaPR5._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _userService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Add(Customer user)
        {
            await _userService.Create(user);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(Customer user)
        {
            await _userService.Update(user);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}
