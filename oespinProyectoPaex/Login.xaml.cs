using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using SQLite;

namespace oespinProyectoPaex
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {

        //crear una variable global de tipo conexion
        private SQLiteAsyncConnection con;
        public Login()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        //creo el metodo que me permite general el sql 

        public static IEnumerable<Estudiante> select_where(SQLiteConnection db, string usuario, string contrasena)
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante where Usuario=? and Contrasena=?", usuario, contrasena);

        }

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {

            String usuario = txtUsuario.Text;
            try
            {
                //accedo a la ruta donde esta la base de datos
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "oespin.db3");
                var db = new SQLiteConnection(ruta);

                //creo la tabla 
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = select_where(db, txtUsuario.Text, txtContrasena.Text);

                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new Reporte(txtUsuario.Text));
                }
                else
                {
                    DisplayAlert("ERROR", "USUARIO/CONTRASEÑA INCORRECTA", "Cerrar");
                }
            }
            catch (Exception)
            {

                //throw;
            }

        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
    }
}