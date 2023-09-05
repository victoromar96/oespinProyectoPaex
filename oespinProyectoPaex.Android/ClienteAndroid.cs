using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using oespinProyectoPaex.Droid;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(ClienteAndroid))]


namespace oespinProyectoPaex.Droid
{
    public class ClienteAndroid : DataBase
    {
        public SQLiteAsyncConnection GetConnection()
        {
            //crear el archivo para la base de datos en mis documentos
            var ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            //la base de datos 
            var baseDatos = Path.Combine(ruta, "oespin.db3");
            return new SQLiteAsyncConnection(baseDatos);
            //creado el metodo 



        }
    }
}