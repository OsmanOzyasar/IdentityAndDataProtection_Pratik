using IdentityAndDataProtection_Pratik.Data;
using IdentityAndDataProtection_Pratik.Dtos;
using IdentityAndDataProtection_Pratik.Entities;
using IdentityAndDataProtection_Pratik.Services;
using IdentityAndDataProtection_Pratik.Types;
using Microsoft.AspNetCore.Identity;

namespace IdentityAndDataProtection_Pratik.Managers
{
    public class UserManager : IUserService
    {
        private readonly IdentityDbContext _context;
        private readonly IPasswordHasher<string> _passwordHasher;

        public UserManager(IdentityDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<string>();
        }

        public async Task<ServiceMessage> AddUser(AddUserDto user)
        {
            var hashedPassword = _passwordHasher.HashPassword(user.Email, user.Password);
            var entity = new UserEntity
            {
                Email = user.Email,
                Password = hashedPassword
            };
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();

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
                    Message = "Invalid email or password",
                    IsSucceed = false
                };
            }

            var verificationResult = _passwordHasher.VerifyHashedPassword(userEntity.Email, userEntity.Password, user.Password);
            if (verificationResult == PasswordVerificationResult.Success)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    Message = "Login successful",
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
                    Message = "Invalid email or password",
                    IsSucceed = false
                };
            }
        }
    }
}
