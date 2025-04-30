using glopezS5A.Models;

namespace glopezS5A.Views;

public partial class vHome : ContentPage
{
	public vHome()
	{
		InitializeComponent();
	}
	private void btnInsertar_Clicked(object sender, EventArgs e)
	{
		statusMessage.Text = "";
		App.personRepo.AddNewPerson(txtNombre.Text);
		statusMessage.Text = App.personRepo.statusMessage;
	}
    private void btnListar_Clicked(object sender, EventArgs e)
	{
		statusMessage.Text = "";
		List<Persona> lista = App.personRepo.GetPersonas();
		listaPersonas.ItemsSource = lista;

	}
}