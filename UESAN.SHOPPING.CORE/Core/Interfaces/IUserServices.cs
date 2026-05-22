using UESAN.SHOPPING.CORE.Core.DTOs;

namespace UESAN.SHOPPING.CORE.Core.Services
{
    public interface IUserServices
    {
        Task<UserDTO> SignIn(string email, string password);
        Task<int> SignUp(UserCreateDTO userCreateDTO);
    }
}