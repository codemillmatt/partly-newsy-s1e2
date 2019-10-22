using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartlyNewsy.Core;
using PartlyNewsy.Models;
using Xamarin.Forms;

namespace PartlyNewsy
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();            
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await GetData();
        }

        async Task GetData()
        {
            var svc = new NewsService();

            var articles = await svc.GetTopNews();

            newsList.ItemsSource = articles;
        }
    }
}
