using IdentityAndDataProtection_Pratik.Dtos;
using IdentityAndDataProtection_Pratik.Types;

namespace IdentityAndDataProtection_Pratik.Services
{
    public interface IUserService
    {
        Task<ServiceMessage> AddUser(AddUserDto user);
        Task<ServiceMessage<UserInfoDto>> LoginUser(LoginUserDto user);
    }
}
