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
    public class WorkItesmService : IWorkItesmService
    {
        private readonly ILogger<WorkItesmService> logger;
        private readonly IHttpClientFactory httpClientFactory;

        public WorkItesmService(ILogger<WorkItesmService> logger, IHttpClientFactory httpClientFactory)
        {
            this.logger = logger;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<(bool IsSuccess, WorkItemModel workitem, string errorMessage)> GetWorkItemAsync(int ID)
        {
            try
            {
                var client = httpClientFactory.CreateClient("WorkItem");
                var response = await client.GetAsync($"api/WorkItem/{ID}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var option = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<WorkItemModel>(content, option);
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

        public async Task<(bool IsSuccess, IEnumerable<WorkItemModel> workitem, string errorMessage)> GetWorkItemsAsync()
        {
            try
            {
                var client = httpClientFactory.CreateClient("WorkItem");
                var response = await client.GetAsync($"api/WorkItem");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var option = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<IEnumerable<WorkItemModel>>(content, option);
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
