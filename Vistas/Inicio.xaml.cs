using msanchezS7.Modelos;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace msanchezS7.Vistas;

public partial class Inicio : ContentPage
{
	private const string Url = "http://192.168.1.178/moviles/post.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> estud;

	public Inicio()
	{
		InitializeComponent();
		Obtener();
	}

	public async void Obtener()
	{
		var content = await cliente.GetStringAsync(Url);
		List<Estudiante> mostrarEst = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		estud = new ObservableCollection<Estudiante>(mostrarEst);
		listaEstudiantes.ItemsSource = estud;
	}

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new AgregarEstudiante());
    }

    private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var ObjEstudiante = (Estudiante)e.SelectedItem;
		Navigation.PushAsync(new ActEliminar(ObjEstudiante));
    }
}