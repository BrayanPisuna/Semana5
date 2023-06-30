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

namespace Semana5
{
    public partial class MainPage : ContentPage
    {
        private String url = "http://l192.168.10.47/ws_uisrael/post.php";
        private readonly HttpClient cliente = new HttpClient();
        private ObservableCollection<Estudiante> post;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnConsultar_Clicked(object sender, EventArgs e)
        {
            var contenido = await cliente.GetStringAsync(url);
            List<Estudiante> datosPost = JsonConvert.DeserializeObject<List<Estudiante>>(contenido);

            post = new ObservableCollection<Estudiante>(datosPost);
            listarEstudiante.ItemsSource = post;


        }
    }
}
