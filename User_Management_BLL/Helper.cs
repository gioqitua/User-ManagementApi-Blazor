using User_Management_BLL.DTOs;
using User_Management_DAL.Entities;

namespace User_Management_BLL
{
    public static class Helper
    {
        public static UserDto Map(this User user) => new()
        {
            Email = user.Email,
            Id = user.Id,
            IsActive = user.IsActive,
            PasswordHash = user.PasswordHash,
            UserName = user.UserName,
            UserProfileId = user.UserProfileId,
        };

        public static User Map(this UserDto userDto) => new()
        {
            Email = userDto.Email,
            Id = userDto.Id,
            IsActive = userDto.IsActive,
            PasswordHash = userDto.PasswordHash,
            UserName = userDto.UserName,
            UserProfileId = userDto.UserProfileId,
        };
        public static UserProfile Map(this UserProfileDto userDto) => new()
        {
            Id = userDto.Id,
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            PersonalNumber = userDto.PersonalNumber
        };
    }
}
