using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogAPI.Data;
using blogAPI.Dto.User;
using blogAPI.Models;

namespace blogAPI.Responsitories
{
    public class UserRespository
    {
        private readonly AppDbContext _context;
        public UserRespository(AppDbContext context)
        {
            _context = context;
        }
        public UserDto InserUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            var result = new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Phone = user.Phone,
                ID = user.Id,
                DateOfBirth = user.DateOfBirth,
                Address = user.Address,
            };
        return result;

        }
    }
}