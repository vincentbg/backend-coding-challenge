using CoveoApiVbg.Data;
using CoveoApiVbg.Helper;
using CoveoApiVbg.Interfaces;
using CoveoApiVbg.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoveoApiVbg.Logics
{
    public class SuggestionLogic : ISugggestionLogic
    {
        private readonly ILogger<SuggestionLogic> _logger;
        private readonly IRepository _repo;
        private ISuggestionFactory _suggestionFactory;
        private VilleSuggereeDto villeSuggereeDto;

        public SuggestionLogic(ILogger<SuggestionLogic> logger, IRepository repo, ISuggestionFactory suggestionFactory)
        {
            _logger = logger;
            _repo = repo;
            _suggestionFactory = suggestionFactory;
        }

        public async Task<IEnumerable<Suggestion>> GetSuggestionsAsync(string q, double? latitude, double? longitude)
        {
            _logger.Log(LogLevel.Debug, "Starting searching suggestions for city named {0}",q);
            bool calculateWithCoordonate = false;
            if (latitude != null && longitude!= null )
            {
                calculateWithCoordonate = true;
            }

            this.villeSuggereeDto = new VilleSuggereeDto
            {
                Name = q
            };

            if (latitude.HasValue && longitude.HasValue)
            {
                this.villeSuggereeDto.Latitude = latitude;
                this.villeSuggereeDto.Longitude = longitude;
            }

            IEnumerable<Ville> villes = await _repo.GetAll();
            List<Suggestion> suggestions = new List<Suggestion>();
            var comp = StringComparison.OrdinalIgnoreCase;
            string villeRecherchee = this.villeSuggereeDto.Name;
            
            foreach (var item in villes){
                float score;
                if (item.Name.Contains(villeRecherchee, comp) && !String.IsNullOrEmpty(item.Name) && villeRecherchee.Length == item.Name.Length)
                {
                    score = (float)0.7;
                    AddSuggestion(item.Id, item.Name, item.Tz, item.Country, score, item.Latitude, item.Longitude, calculateWithCoordonate,ref suggestions);
                    
                }
                else if(item.Name.Contains(villeRecherchee, comp) && !String.IsNullOrEmpty(item.Name))
                {
                    if(item.Name.Length - villeRecherchee.Length < 2)
                    {
                        score = (float)0.5;
                        AddSuggestion(item.Id, item.Name, item.Tz, item.Country, score, item.Latitude, item.Longitude, calculateWithCoordonate, ref suggestions);
                    }
                    else
                    {
                        score = (float)0.3;
                        AddSuggestion(item.Id, item.Name, item.Tz, item.Country, score, item.Latitude, item.Longitude, calculateWithCoordonate, ref suggestions);
                    }
                }

               
            }
            return suggestions.OrderByDescending(x => x.Score).ToList();
        }

        private void AddSuggestion(int id, string name, string tz, string country, float score, double latitude, double longitude, bool calculateWithCoordonate, ref List<Suggestion> suggestions)
        {
            double distance = -1;
            if (calculateWithCoordonate && (latitude != double.MinValue && longitude != double.MinValue))
            {
                distance = LatitudeLongitudeCalculator.Distance((double)this.villeSuggereeDto.Latitude, (double) this.villeSuggereeDto.Longitude, latitude, longitude, (char)075);
                if (distance == 0)
                {
                    score = 1;
                }
                else if (distance <= 400)
                {
                    score += (float)0.2;
                }
                else if (distance <= 600 && distance > 400)
                {
                    score += (float)0.1;
                }
            }
            suggestions.Add(_suggestionFactory.Create( id, name, tz, country, score, latitude, longitude));
        }
    }
}
