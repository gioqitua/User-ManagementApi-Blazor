namespace User_Management_DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int? UserProfileId { get; set; }
        public virtual UserProfile? UserProfile { get; set; } = null!;
    }
}
