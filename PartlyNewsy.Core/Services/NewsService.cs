using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PartlyNewsy.Models;
using Refit;
using Xamarin.Essentials;

namespace PartlyNewsy.Core
{
    public class NewsService
    {
        readonly string newsFunctionUrl = "http://192.168.86.209:7071/api";
        readonly INewsFunctionAPI newsFunctionAPI;

        public NewsService()
        {
            // this is to account for Android emulator pecularities in local networking
            // https://developer.android.com/studio/run/emulator-networking.html
            if (DeviceInfo.DeviceType == DeviceType.Virtual && DeviceInfo.Platform == DevicePlatform.Android)
                newsFunctionUrl = "http://10.0.2.2:7071/api";

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
