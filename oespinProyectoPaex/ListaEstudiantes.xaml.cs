using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace oespinProyectoPaex
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaEstudiantes : ContentPage
	{

        //acede al servidor con esta direccion
        private const string Url = "http://192.168.17.45/oespin/post.php";

        private readonly HttpClient cliente = new HttpClient();

        //variable global 
        private ObservableCollection<Estudiante1> destudiante;

        public ListaEstudiantes ()
		{
			InitializeComponent ();
            mostrar();
        }

        //agrego un metodo 
        public async void mostrar()
        {
            //capturando los datos en la url con el metodo get
            var content = await cliente.GetStringAsync(Url);

            //llamar a un list de estudiante, le guardo en una variable y el convierto 

            List<Estudiante1> gestudiante = JsonConvert.DeserializeObject<List<Estudiante1>>(content);
            //aggregamos esa variable
            destudiante = new ObservableCollection<Estudiante1>(gestudiante);

            ListaEstudiante.ItemsSource = destudiante;




        }

        private void ListaEstudiante_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objetoEstudiante = (Estudiante1)e.SelectedItem;
            Navigation.PushAsync(new ActualizarEliminar(objetoEstudiante));


        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistrarEstudiante());
        }
    }
}