using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore;

namespace Data.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Account : BaseEntity
    {
        public string Name { get; set; }
        [Required]
        public Contact Contact { get; set; }
        public Guid ContactId { get; set; }
        public ICollection<Incident> Incidents { get; set; }
    }
}