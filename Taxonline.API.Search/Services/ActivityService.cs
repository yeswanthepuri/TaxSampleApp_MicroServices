using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Taxonline.API.Search.Interfaces;
using Taxonline.API.Search.Models;

namespace Taxonline.API.Search.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<ComplinesService> logger;

        public ActivityService(IHttpClientFactory httpClientFactory,
            ILogger<ComplinesService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }
        public async Task<(bool IsSuccess, IEnumerable<ActivityModel> ActivityModel, string errorMessage)> GetActivitysAsync()
        {
            try
            {
                var client = httpClientFactory.CreateClient("Activity");
                var response = await client.GetAsync($"api/Activity");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var option = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<IEnumerable<ActivityModel>>(content, option);
                    return (true, result, null);
                }
                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return (false, null, ex.Message);
            }
        }
    }
}
