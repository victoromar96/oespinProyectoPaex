using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace oespinProyectoPaex
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrarEstudiante : ContentPage
	{
		public RegistrarEstudiante ()
		{
			InitializeComponent ();
		}

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                //contenenedor de una coleccion para  guardar temporalmente los datos 
                var parametros = new System.Collections.Specialized.NameValueCollection();
                var parametros2 = new System.Collections.Specialized.NameValueCollection();

                //agrego los datos 
                parametros.Add("codigo", txtID.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                parametros.Add("correo", txtCorreo.Text);
                parametros.Add("celular", txtCelular.Text);
                parametros.Add("estadoCivil", txtEstadoCivil.Text);
                parametros.Add("tipoSangre", txtTipoSangre.Text);
                //post2

                

                

                cliente.UploadValues("http://192.168.17.45/oespin/post.php", "POST", parametros);
             
                DisplayAlert("Alerta", "Ingreso correcto", "Cerrar");

                Navigation.PushAsync(new ListaEstudiantes());
            }
            catch (Exception)
            {

                //throw;
            }
        }
    }
}