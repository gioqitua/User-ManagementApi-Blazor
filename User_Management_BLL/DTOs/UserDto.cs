

namespace User_Management_BLL.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int? UserProfileId { get; set; } = null;
    }
}
