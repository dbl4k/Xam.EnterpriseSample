using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xam.EnterpriseSample.ViewModels;
using Xamarin.Forms;
using Newtonsoft.Json;
using Xam.EnterpriseSample.Services;

namespace Xam.EnterpriseSample
{
	public partial class MainPage : ContentPage
	{
        private const string postsurl = "http://jsonplaceholder.typicode.com/posts/";

        private Random _random = new Random();
      
		public MainPage()
		{
			InitializeComponent();
            BindingContext = new SimpleViewModel();
		}

        public SimpleViewModel Model
        {
            get
            {
                return (SimpleViewModel)BindingContext;
            }
        }

        public async void Button_OnClick(object sender, EventArgs args)
        {
            Model.ProgressIndicatorVisible = true;

            var id = _random.Next(1, 10);
            var post = await GetPost(id);

            Model.Id = post.Id;
            Model.Title = post.Title;
            Model.Description = post.Body;

            Model.ProgressIndicatorVisible = false;
        }

        private async Task<DataContracts.TypicodePost> GetPost(int id)
        {
            string body;
            try
            {
                var response = await HttpService.Client.GetAsync(postsurl + id.ToString());
                body = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
            return JsonConvert.DeserializeObject<DataContracts.TypicodePost>(body);
        }

	}
}
