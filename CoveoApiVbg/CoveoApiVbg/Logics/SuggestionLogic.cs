using CoveoApiVbg.Interfaces;
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

        public SuggestionLogic(ILogger<SuggestionLogic> logger)
        {
            _logger = logger;
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
