using blogAPI.Data;
using blogAPI.Dto.User;
using Microsoft.AspNetCore.Mvc;
namespace blogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult addUser(CreateUserDto createUserDto)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.Add(new Models.User()
                {
                    DisplayName = createUserDto.DisplayName,
                    Email = createUserDto.Email,
                    Phone = createUserDto.Phone,
                    DateOfBirth = createUserDto.DateOfBirth,
                    Address = createUserDto.Address,
                });
                _context.SaveChanges();
                return Ok(user);
            }else{
                return BadRequest(ModelState.ErrorCount);
            }
        }
    }
}