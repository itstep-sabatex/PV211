using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe.Models
{
    //[Table("Users")]
    //[Comment("База для користувачів")]
    [Index(nameof(IdCode), IsUnique = true)]
    public class Waiter
    {
        public static Waiter Admin => new Waiter {Id=1,Name="Administartor",Password="12345",Birthday=DateTime.Parse("01.01.2000") };
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        [Unicode(false)]
        public string IdCode { get; set; }

        public  bool State { get; set; }
        public string Name { get; set; } = default!;
        [MaxLength(100)]
        [Unicode(false)]
        [Required]
        public string? Password { get; set; }
        public DateTime Birthday { get; set; }
        [Precision(18,2)]
        public double Counter { get; set; } //double,float,decimal   [digit] * 10[mantise]   9.99999999999 10^100  double (64)
        //public IEnumerable<Order>? Orders { get; set; }
        public override string ToString()
        {
            return $"{Name} - {Birthday}";
        }
    }
}
