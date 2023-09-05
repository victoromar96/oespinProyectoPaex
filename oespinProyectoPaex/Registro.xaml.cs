using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
namespace oespinProyectoPaex
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {

        private SQLiteAsyncConnection con;

        public Registro()
        {
            InitializeComponent();

            con = DependencyService.Get<DataBase>().GetConnection();
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            var datos = new Estudiante
            {
                //se guarden las cajas de texto, guardo los datos en un nuevo estudiante 
                Nombre = txtNombre.Text,
                Usuario = txtUsuario.Text,
                Contrasena = txtContrasena.Text,

            };

            //inserto el dato y regreso al login 
            con.InsertAsync(datos);
            DisplayAlert("Alerta", "Se inserto el dato", "CErrar");
            Navigation.PushAsync(new Login());
            



        }
    }
}