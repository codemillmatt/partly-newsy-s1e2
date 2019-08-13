using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Microsoft.Azure.CognitiveServices.Search.NewsSearch.Models;
using Microsoft.Azure.CognitiveServices.Search.NewsSearch;

using System.Collections.Generic;
using System.Linq;

using PartlyNewsy.Models;

namespace PartlyNewsy.Functions
{
    public static class GetTopNews
    {
        [FunctionName("GetTopNews")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var credentials = new ApiKeyServiceClientCredentials(Environment.GetEnvironmentVariable("NewsSearchApiKey"));

            var newsClient = new NewsSearchClient(credentials) {
                Endpoint = Environment.GetEnvironmentVariable("NewsSearchUrl")
            };

            var allTheNews = await newsClient.News.SearchAsync(query:"");

            var allArticles = new List<PartlyNewsy.Models.Article>();

            foreach(var item in allTheNews.Value)
            {
                var article = new PartlyNewsy.Models.Article {
                    ArticleUrl = item.Url,
                    Category = item.Category,
                    DatePublished = DateTime.Parse(item.DatePublished),
                    FeaturedImage = item.Image.Thumbnail.ContentUrl,
                    Headline = item.Name,
                    NewsProviderImageUrl = item.Provider.First().Image.Thumbnail.ContentUrl,
                    NewsProviderName = item.Provider.First().Name
                };

                allArticles.Add(article);
            }

            return new OkObjectResult(allArticles);
        }
    }
}
