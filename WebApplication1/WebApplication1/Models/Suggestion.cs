using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Suggestion
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Score { get; set; }

    }
}
