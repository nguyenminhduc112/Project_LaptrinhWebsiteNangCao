using blogAPI.Data;
using blogAPI.Dto.User;
using blogAPI.Responsitories;
using Microsoft.AspNetCore.Mvc;
namespace blogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRespository _context;
        public UserController(UserRespository context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ListUser()
        {

            var listUser = await _context.GetUsers();

            return Ok(listUser);
        }

        [HttpPost]
        public IActionResult addUser(CreateUserDto createUserDto)
        {
            if (ModelState.IsValid)
            {
                var user = _context.InserUser(new Models.User()
                {
                    DisplayName = createUserDto.DisplayName,
                    Email = createUserDto.Email,
                    Phone = createUserDto.Phone,
                    DateOfBirth = createUserDto.DateOfBirth,
                    Address = createUserDto.Address,
                });
                return Ok(user);
            }else{
                return BadRequest(ModelState.ErrorCount);
            }
        }
    }
}