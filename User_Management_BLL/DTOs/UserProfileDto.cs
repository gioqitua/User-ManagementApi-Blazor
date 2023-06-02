using System.ComponentModel.DataAnnotations;

namespace User_Management_BLL.DTOs
{
    public class UserProfileDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PersonalNumber { get; set; } = string.Empty;
        public int? UserId { get; set; }
    }
}
