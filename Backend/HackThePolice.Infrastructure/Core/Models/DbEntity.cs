using System;
using System.ComponentModel.DataAnnotations;

namespace HackThePolice.Infrastructure.Core.Models
{
    public class DBEntity
    {
        [Key]
        public Guid? Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public DBEntity()
        {
            CreatedAt = ModifiedAt = DateTime.UtcNow;
        }
    }
}