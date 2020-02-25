using CoveoApiVbg.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoveoApiVbg.Models
{
    public class Suggestion: IEntity
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public float Score { get; set; }
    }
}
