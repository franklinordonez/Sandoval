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

namespace Sandoval
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.100.55/RinconManabitaJessy/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Sandoval.Datos> _post;


        public MainPage()
        {
            InitializeComponent();
            get();
        }
           public async void get() 
        
        {
            var content = await client.GetStringAsync(Url);
            List<Sandoval.Datos> posts = JsonConvert.DeserializeObject<List<Sandoval.Datos>>(content);
            _post = new ObservableCollection<Sandoval.Datos>(posts);
            MyListView.ItemsSource = _post;
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VentanaIngreso());
        }
    }
    
}
