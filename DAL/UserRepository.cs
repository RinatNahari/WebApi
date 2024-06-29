using DTO;
using DynamicData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class UserRepository : IUserRepository
    {
        List<UserDTO> _users;
        public UserRepository()
        {
            _users = new List<UserDTO>();
            Init();
        }
        private void Init()
        {
            Add(new UserDTO() { UserId = 1, Password = "User1@123", UserName = "User1" });
            Add(new UserDTO() { UserId = 2, Password = "User2@123", UserName = "User2" });
        }
        public List<UserDTO> GetUsers() => _users;
        public UserDTO Add(UserDTO userDTO)
        {
            if (!_users.Contains(userDTO))
            {
                _users.Add(userDTO);
                return userDTO;
            }
            return userDTO;
        }
        public void DeleteUser(int id)
        {
            var userDTO = _users.Where(u => u.UserId == id).Select(u => u);
            if (userDTO != null)
                _users.Remove(userDTO);
        }
    }
}
