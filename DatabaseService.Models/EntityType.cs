using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseService.Models
{
   public class EntityType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<IdNamePair> Categories { get; set; }
        public bool Active { get; set; }
    }
    public class IdNamePair
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
