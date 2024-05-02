using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe.Models
{
    //[Table("Users")]
    //[Comment("База для користувачів")]
    [Index(nameof(IdCode), IsUnique = true)]
    public class User
    {
        public static User Admin => new User {Id=1,Name="Administartor",Password="12345",Birthday=DateTime.Parse("01.01.2000"),IdCode="1234567890" };
        public static User Waiter => new User { Id=2,Name="Waiter",Password="12345",Birthday=DateTime.Parse("01.01.2000"), IdCode="1234567891" };
        public static User Manager => new User { Id = 3, Name = "Manager", Password = "12345", Birthday = DateTime.Parse("01.01.2000"), IdCode = "1234567892" };
        public static User Barmen => new User { Id = 4, Name = "Barmen", Password = "12345", Birthday = DateTime.Parse("01.01.2000"), IdCode = "1234567893" };
        public static User Cook => new User { Id = 5, Name = "Cook", Password = "12345", Birthday = DateTime.Parse("01.01.2000"), IdCode = "1234567894" };
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        [Unicode(false)]
        public string IdCode { get; set; }
        public string Name { get; set; } = default!;
        
        [MaxLength(100)]
        [Unicode(false)]
        [Required]
        public string? Password { get; set; }
        
        public DateTime Birthday { get; set; }
         //public IEnumerable<Order>? Orders { get; set; }
        public override string ToString()
        {
            return $"{Name} - {Birthday}";
        }
    }
}
