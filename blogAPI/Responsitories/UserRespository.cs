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
        public async Task< List<UserDto>> GetUsers(){
            return await _context.Users.Select(user=>new UserDto(){
                DisplayName = user.DisplayName,
                Email = user.Email,
                Phone = user.Phone,
                ID = user.Id,
                DateOfBirth = user.DateOfBirth,
                Address = user.Address,
            }).AsNoTracking().ToListAsync();
            
        }

        public async Task<bool> DeleteUser(Guid Id){
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == Id);
            if(user == null){
                return false;
               
            };
             _context.Users.Remove(user);
             await _context.SaveChangesAsync();
             return true;
        }   

        public async UserDto EditUser(User user)
        {
            var userExist = await _context.Users.FirstOrDefaultAsync(user => user.Id == Id);
            if(userExist == null){
                return null;
            };
            userExist.DisplayName = user.DisplayName;
            userExist.Email = user.Email;
            userExist.Phone = user.Phone;
            userExist.DateOfBirth = user.DateOfBirth;
            userExist.Address = user.Address;
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