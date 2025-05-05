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
    private async void OnEliminarClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var persona = button?.CommandParameter as Persona;
        if (persona != null)
        {
            bool confirm = await DisplayAlert("Confirmar", $"¿Eliminar a {persona.Name}?", "Sí", "No");
            if (confirm)
            {
                App.personRepo.DeletePerson(persona.Id);
                statusMessage.Text = App.personRepo.statusMessage;
                listaPersonas.ItemsSource = App.personRepo.GetPersonas();
            }
        }
    }

    private async void OnEditarClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var persona = button?.CommandParameter as Persona;
        if (persona != null)
        {
            string nuevoNombre = await DisplayPromptAsync("Editar", $"Nuevo nombre para {persona.Name}:", initialValue: persona.Name);
            if (!string.IsNullOrWhiteSpace(nuevoNombre))
            {
                App.personRepo.UpdatePerson(persona.Id, nuevoNombre);
                statusMessage.Text = App.personRepo.statusMessage;
                listaPersonas.ItemsSource = App.personRepo.GetPersonas();
            }
        }
    }
}