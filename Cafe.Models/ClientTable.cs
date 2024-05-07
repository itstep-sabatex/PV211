using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cafe.Models
{
    public class ClientTable
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        [JsonIgnore]
        public IEnumerable<Order>? Orders { get; set; }

        public static ClientTable Table1=> new ClientTable { Id = 2, Name = "Столик 1" };
        public static ClientTable Table2=> new ClientTable { Id = 3, Name = "Столик 2" };
        public static ClientTable Table3=>new ClientTable { Id = 1, Name = "Столик біля вікна" };


        public static IEnumerable<ClientTable> DefaultClientTables()
        {
            yield return Table1;
            yield return Table2;
            yield return Table3;
        }
    }
}
