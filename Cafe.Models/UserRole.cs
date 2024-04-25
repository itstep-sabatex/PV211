using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Models
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        //[Column("ROLE")] // rOLE
        public Role Role { get; set; }
        //public int RoleId { get; set; }
        public User? Waiter { get; set; } // 7 -9 12 ID NAME CODE MAX_LENGS  [Code]  'Code'
        public int WaiterId { get; set; }

    }
}
