using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUserRepository
    {
        List<UserDTO> GetUsers();
        UserDTO GetById(int userId);
        void Add(UserDTO userDTO);
        void Delete(UserDTO userDTO);
    }
}
