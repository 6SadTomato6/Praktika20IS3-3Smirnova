using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Interfaces;
using Domain.Wrapper;
using SmirnovaPR5._1.Contracts.User;
using Mapster;

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
        /// <summary>
        /// Просмотр всех записей в БД
        /// </summary>
        // POST api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }
        /// <summary>
        /// Просмотр всех записей по id
        /// </summary>
        // POST api/<UsersController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetById(id);
            var response = new GetUserResponse()
            {
                CustomerId = result.CustomerId,
                CustomerFname = result.CustomerFname,
                CustomerLname = result.CustomerLname,
                Role = result.Role,
            };
            return Ok(response);
        }
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///         "customerID" = 5,
        ///         "customerFname" = "Иван",
        ///         "customerLname" = "Иванво",
        ///         "customerEmail" = "email@mail.ru",
        ///         "role" = "user"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var userDto = request.Adapt<Customer>();
            await _userService.Create(userDto);
            return Ok();
        }
        /// <summary>
        /// Обновление пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///         "customerID" = 5,
        ///         "customerFname" = "Иван",
        ///         "customerLname" = "Иванво",
        ///         "customerEmail" = "email@mail.ru",
        ///         "role" = "user"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>

        // POST api/<UsersController>
        [HttpPut]
        public async Task<IActionResult> Update(CreateUserRequest request)
        {
            var userDto = request.Adapt<Customer>();
            await _userService.Update(userDto);
            return Ok();
        }
        /// <summary>
        /// Удаление записей по id
        /// </summary>
        // POST api/<UsersController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}
