using PrevisionBackend.DTO;
using PrevisionBackend.Models;
using PrevisionBackend.Repositories;

namespace PrevisionBackend.Service
{
    public class UserService
    {
        private UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserReadDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();

            // Map each User entity to a UserReadDto
            return users.Select(fromUserToUserReadDto).ToList();
        }

        public UserReadDto fromUserToUserReadDto(User user )
        {
            return new UserReadDto
            {
                Id = user.UserID,
                FirstName = user.FirstName,
                LastName = user.LastName,

            };
        }
    }
}
