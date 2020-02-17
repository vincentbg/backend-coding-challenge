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
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Country { get; set; }
        public string Tz { get; set; }





    }
}
