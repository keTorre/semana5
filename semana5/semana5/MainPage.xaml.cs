using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace semana5
{
    public partial class MainPage : ContentPage
    {
        public const string Url = "http://192.168.21.145/uisrael2023/post.php";
        private readonly HttpClient _client = new HttpClient();
        private ObservableCollection<semana5.Ws.Datos> _post;
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            var content = await _client.GetStringAsync(Url);
            List<semana5.Ws.Datos> posts = JsonConvert.DeserializeObject<List<semana5.Ws.Datos>>(content);
            _post = new ObservableCollection<semana5.Ws.Datos>(posts);
            MyListView.ItemsSource = posts;
        }
    }
}
