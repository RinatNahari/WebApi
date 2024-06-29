using DAL;
using DTO;

namespace BLL
{
    public class UserManager
    {
        IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
            => _userRepository = userRepository;

        public List<UserDTO> GetUsers() => _userRepository.GetUsers();
        public bool Add(UserDTO userDTO)
        {
            if (_userRepository.GetById(userDTO.UserId) != null)
                return false;
            if (userDTO.UserId <= 0
                || string.IsNullOrEmpty(userDTO.UserName)
                || string.IsNullOrEmpty(userDTO.Password))
                return false;

            _userRepository.Add(userDTO);
            return true;
        }
        public bool Delete(int userId)
        {
            var userDTO = _userRepository.GetById(userId);
            if (userDTO == null)
                return false;
            _userRepository.Delete(userDTO);
            return true;
        }
        public bool Validate(UserDTO userDTO, string password)
        {
            var user = _userRepository.GetById(userDTO.UserId);
            if (user != null && user.Password == password)
                return true;
            return false;
        }
    }
}