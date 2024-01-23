using System.Net;

namespace msanchezS7.Vistas;

public partial class AgregarEstudiante : ContentPage
{
	public AgregarEstudiante()
	{
		InitializeComponent();
	}

    private async void btnAgregar_Clicked(object sender, EventArgs e)
    {
		try
		{
			WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre", txtNombre.Text);
			parametros.Add("apellido", txtApellido.Text);
			parametros.Add("edad", txtEdad.Text);
			cliente.UploadValues("http://192.168.1.178/moviles/post.php", "POST", parametros);

            await DisplayAlert("Éxito", "Estudiante actualizado correctamente", "Aceptar");

            await Navigation.PushAsync(new Inicio());

		}
		catch (Exception ex)
		{

			await DisplayAlert("ERROR", ex.Message, "CERRAR");
		}
    }
}