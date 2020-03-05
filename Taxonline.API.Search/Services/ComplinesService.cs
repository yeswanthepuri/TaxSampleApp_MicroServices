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
    public class ComplinesService : IComplinesService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<ComplinesService> logger;

        public ComplinesService(IHttpClientFactory httpClientFactory,
            ILogger<ComplinesService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }
        public async Task<(bool IsSuccess, IEnumerable<ComplainesModel> ComplainFiles, string errorMessage)> GetComplainesAsync(int UserId)
        {
            try
            {
                var client = httpClientFactory.CreateClient("UploadComplaines");
                var response = await client.GetAsync($"api/UploadFile/{UserId}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var option = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<IEnumerable<ComplainesModel>>(content, option);
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
