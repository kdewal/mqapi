using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseService.Models
{
    public class Location
    {
        public IEnumerable<Country> Countries { get; set; }
    }
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<State> States { get; set; }
    }
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public IEnumerable<IdNamePair> Cities { get; set; }
    }
    public class Cities
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
