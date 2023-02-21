using FastFood.Domain.Commons;
using FastFood.Domain.Enums;

namespace FastFood.Domain.Entities
{
    public class User : Auditable
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public UserRole Role { get; set; }
    }
}
