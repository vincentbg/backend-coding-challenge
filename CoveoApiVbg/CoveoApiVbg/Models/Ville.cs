using CoveoApiVbg.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoveoApiVbg.Models
{
    public class Ville : IEntity
    {
        public int Id { get ; set ; }
        public string Name { get; set; }
        public string Ascii { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Country { get; set; }
        public string Tz { get; set; }





    }
}
