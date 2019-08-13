using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PartlyNewsy.Models;
using Refit;

namespace PartlyNewsy.Core
{
    public class NewsService
    {
        readonly string newsFunctionUrl = "http://localhost:7071/api";
        readonly INewsFunctionAPI newsFunctionAPI;

        public NewsService()
        {
            newsFunctionAPI = RestService.For<INewsFunctionAPI>(newsFunctionUrl);
        }

        public async Task<List<Article>> GetTopNews()
        {
            return await newsFunctionAPI.GetTopNewsFromFunction();
        }
    }

    public interface INewsFunctionAPI
    {
        [Get("/GetTopNews")]
        Task<List<Article>> GetTopNewsFromFunction();
    }
}
