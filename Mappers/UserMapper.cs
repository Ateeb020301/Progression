using Progression.Dtos.Goal;
using Progression.Dtos.Milestone;
using Progression.Dtos.User;
using Progression.Models;

namespace Progression.Mappers
{
    public static class UserMapper
    {
        public static User ToUserFromCreateDto(this UserDto goalModel)
        {
            return new User
            {
                Id = goalModel.Id,
                Email = goalModel.Email,
                PasswordHash = goalModel.Password,
            };
        }

        public static User ToUserDto(this User goalModel)
        {
            return new User
            {
                Id = goalModel.Id,
                Email = goalModel.Email,
                PasswordHash = goalModel.PasswordHash,
                
            };
        }
    }
}
