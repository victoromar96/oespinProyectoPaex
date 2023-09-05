using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace oespinProyectoPaex
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {

        //creo tres variables
        public int IDseleccionado;
        SQLiteAsyncConnection con;
        IEnumerable<Estudiante> REliminar;
        IEnumerable<Estudiante> RActualizar;
        public Elemento(Estudiante datos)
        {
            InitializeComponent();
            //visualizar los datos
            
            txtID.Text = datos.Id.ToString();
            txtNombre.Text = datos.Nombre;
            txtUsuario.Text = datos.Usuario;
            txtContrasena.Text = datos.Contrasena;
            con = DependencyService.Get<DataBase>().GetConnection();
            //va a permitar actualizar y eliminar 
            IDseleccionado = datos.Id;

        }

        //creo los dos metodos 
        public static IEnumerable<Estudiante> Eliminar(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("Delete from Estudiante where Id=?", id);
        }

        public static IEnumerable<Estudiante> Actualizar(SQLiteConnection db, int id, string nombre, string usuario, string contrasena)
        {
            return db.Query<Estudiante>("UPDATE Estudiante set Nombre=?, Usuario=?, Contrasena=? where Id=?", nombre, usuario, contrasena, id);
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "oespin.db3");
            var db = new SQLiteConnection(ruta);

            RActualizar = Actualizar(db, IDseleccionado, txtNombre.Text, txtUsuario.Text, txtContrasena.Text);
            DisplayAlert("ALerta", "Actualizado COrrectamente", "Cerrar");
            //para consultar al registrop a ver si se actualizo 
            Navigation.PushAsync(new ConsultarRegistro());
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "oespin.db3");
            var db = new SQLiteConnection(ruta);

            //envio los datos del ID para eliminar 
            REliminar = Eliminar(db, IDseleccionado);
            DisplayAlert("ALerta", "Eliminado COrrectamente", "Cerrar");
            //para consultar al registrop a ver si se elimino 
            Navigation.PushAsync(new ConsultarRegistro());
        }
    }
}