
using msanchezS7.Modelos;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace msanchezS7.Vistas;

public partial class ActEliminar : ContentPage
{
    public ActEliminar(Estudiante datos)
	{
        InitializeComponent();

        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre;
        txtApellido.Text = datos.apellido;
        txtEdad.Text = datos.edad.ToString();

	}

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string edad = txtEdad.Text;


            string url = "http://192.168.1.178/moviles/post.php?codigo=" + codigo + "&nombre=" + nombre + "&apellido=" + apellido + "&edad=" + edad;
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            cliente.UploadValues(url, "PUT", parametros);

            await DisplayAlert("Éxito", "Estudiante actualizado correctamente", "Aceptar");


           await  Navigation.PushAsync(new Inicio());

        }
        catch (Exception ex)
        {

           await DisplayAlert("ERROR", ex.Message, "CERRAR");
        }
    }



private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string codigo = txtCodigo.Text;

            string url = "http://192.168.1.178/moviles/post.php?codigo=" + codigo;
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            cliente.UploadValues(url, "DELETE", parametros);

            await DisplayAlert("Éxito", "Estudiante eliminado correctamente", "Aceptar");

            await Navigation.PushAsync(new Inicio());
        }
        catch (Exception ex)
        {

           await  DisplayAlert("ERROR", ex.Message, "CERRAR");
        }

    }
}