using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xam.EnterpriseSample.ViewModels;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace Xam.EnterpriseSample
{
	public partial class MainPage : ContentPage
	{
        private Random _random = new Random();
        public HttpClient client = new HttpClient();

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
            var id = _random.Next(1, 10);
            var response = await client.GetAsync("http://jsonplaceholder.typicode.com/posts/" + id.ToString());
            var body = await response.Content.ReadAsStringAsync();
            var post = JsonConvert.DeserializeObject<DataContracts.TypicodePost>(body);
            
            Model.Id = post.Id;
            Model.Title = post.Title;
            Model.Description = post.Body;
        }
	}
}
