using CoveoApiVbg.Data;
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
        private VilleSuggereeDto villeSuggereeDto;

        public SuggestionLogic(ILogger<SuggestionLogic> logger, IRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<IEnumerable<Suggestion>> GetSuggestionsAsync(string q, float? latitude, float? longitude)
        {
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

            foreach (var item in villes){
                if (item.Name.Contains(this.villeSuggereeDto.Name, comp) && !String.IsNullOrEmpty(item.Name) && this.villeSuggereeDto.Name.Length == item.Name.Length)
                {
                    suggestions.Add(new Suggestion { Id = item.Id, Name = item.Name + ", "+item.Tz + ", " + item.Country , Score = (float)0.9});
                }
                else if(item.Name.Contains(this.villeSuggereeDto.Name, comp) && !String.IsNullOrEmpty(item.Name) && this.villeSuggereeDto.Name.Length != item.Name.Length)
                {
                    suggestions.Add(new Suggestion { Id = item.Id, Name = item.Name + ", " + item.Tz + ", " + item.Country, Score = (float)0.6 });

                }

            }

            return suggestions;
        }

        public Task WriteMessage(string message)
        {
            _logger.LogInformation(
                "MyDependency.WriteMessage called. Message: {MESSAGE}",
                message);

            return Task.FromResult(0);
        }
    }
}
