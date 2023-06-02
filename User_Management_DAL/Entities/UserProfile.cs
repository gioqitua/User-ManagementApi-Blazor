using System.ComponentModel.DataAnnotations;

namespace User_Management_DAL.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        [StringLength(11)] public string PersonalNumber { get; set; } = string.Empty;

        [Required]
        public virtual User User { get; set; } = null!;

    }
}
