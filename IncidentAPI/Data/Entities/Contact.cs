using Microsoft.EntityFrameworkCore;

namespace Data.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class Contact : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}