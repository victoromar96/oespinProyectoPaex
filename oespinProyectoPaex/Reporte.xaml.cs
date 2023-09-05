using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace oespinProyectoPaex
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reporte : ContentPage
    {
        public Reporte()
        {
            InitializeComponent();

            
        }

        private void txtVentanaUsuario_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConsultarRegistro());
        }

        private void txtVentanaEstudiante_Clicked(object sender, EventArgs e)
        {

        }
    }
}