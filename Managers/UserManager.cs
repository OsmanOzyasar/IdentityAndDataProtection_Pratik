using IdentityAndDataProtection_Pratik.Data;
using IdentityAndDataProtection_Pratik.Dtos;
using IdentityAndDataProtection_Pratik.Entities;
using IdentityAndDataProtection_Pratik.Services;
using IdentityAndDataProtection_Pratik.Types;

namespace IdentityAndDataProtection_Pratik.Managers
{
    public class UserManager : IUserService
    {
        private readonly IdentityDbContext _context;

        public UserManager(IdentityDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceMessage> AddUser(AddUserDto user)
        {
            var entity = new UserEntity
            {
                Email = user.Email,
                Password = user.Password
            };
            _context.Users.Add(entity);
            _context.SaveChanges();

            return new ServiceMessage
            {
                Message = "User added successfully",
                IsSucceed = true
            };
        }

        public async Task<ServiceMessage<UserInfoDto>> LoginUser(LoginUserDto user)
        {
            var userEntity = _context.Users.Where(x => x.Email.ToLower() == user.Email.ToLower()).FirstOrDefault();

            if (userEntity is null)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    Message = "Kullanıcı ya da şifre hatalı",
                    IsSucceed = false
                };
            }

            if (userEntity.Password == user.Password)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    Message = "Giriş Başarılı",
                    IsSucceed = true,
                    Data = new UserInfoDto
                    {
                        Id = userEntity.Id,
                        Email = userEntity.Email,
                        UserType = userEntity.UserType
                    }
                };
            }
            else
            {
                return new ServiceMessage<UserInfoDto>
                {
                    Message = "Kullanıcı ya da şifre hatalı",
                    IsSucceed = false
                };
            }
        }
    }
}
