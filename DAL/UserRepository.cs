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
        public UserDTO GetById(int userId) => _users.FirstOrDefault(x => x.UserId == userId);
        public void Add(UserDTO userDTO) => _users.Add(userDTO);
        public void Delete(UserDTO userDTO) => _users.Remove(userDTO);
    }
}
