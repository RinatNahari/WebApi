using DAL;
using DTO;

namespace BLL
{
    public class UserManager
    {
        IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
            =>_userRepository = userRepository;
        
        public List<UserDTO> GetUsers() => _userRepository.GetUsers();
        public UserDTO Add(UserDTO userDTO)
        {
            if (userDTO.UserId != null && userDTO.UserId != 0
                && !string.IsNullOrEmpty(userDTO.UserName)
                && !string.IsNullOrEmpty(userDTO.Password))
            {
                _userRepository.Add(userDTO);
                return userDTO;
            }
            return null;
        }
        public int Delete(int id)
        {
            if (id > 0)
                _userRepository.DeleteUser(id);
            return id;
        }
        public bool Validate(UserDTO userDTO, string password)
        {
            var user = _userRepository.GetUsers().Where(u => u.UserId == userDTO.UserId && u.Password == password)
                                      .Select(u => u);
            return user != null;
        }
    }
}