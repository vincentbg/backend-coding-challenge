using CoveoApiVbg.Data;
using CoveoApiVbg.Interfaces;
using CoveoApiVbg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoveoApiVbg.Logics
{
    public class SuggestionFactory : ISuggestionFactory
    {
        public Suggestion Create(int id, string name, string tz, string country, float score, double latitude, double longitude)
        {
            return new Suggestion { Id = id, Name = name + ", " + tz + ", " + country, Score = score, Latitude = latitude, Longitude = longitude };
        }
    }
}
