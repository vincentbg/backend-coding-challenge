using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoveoApiVbg.Data;
using CoveoApiVbg.Interfaces;
using CoveoApiVbg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoveoApiVbg.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SuggestionsController : ControllerBase
    {
        private readonly ISugggestionLogic suggestionLogic;

        public SuggestionsController(ISugggestionLogic suggestionLogic)
        {
            this.suggestionLogic = suggestionLogic;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Suggestion>>> Get(string q, double? latitude, double? longitude)
        {
            if (string.IsNullOrEmpty(q))
            {
                return BadRequest();
            }
         
            IEnumerable<Suggestion> suggestions = await this.suggestionLogic.GetSuggestionsAsync(q, latitude, longitude);

            return Ok(suggestions);

        }

    }
}