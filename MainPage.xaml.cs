
namespace ProyectoSQLite;

public partial class MainPage : ContentPage
{
	public MainPage()
    {
		InitializeComponent();
    }

    private async void btpagdb(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Firma());
    }

    private async void btFirma(object sender, EventArgs e)
    {
        var dbService = new BaseDeDatos();
        await Navigation.PushAsync(new PagDB(dbService));
    }

    private void btCV(object sender, EventArgs e)
    {
        string url = "https://drive.google.com/file/d/15gHDy5jQXAM5snDCpnjrpYiPnpoz3Mg6/view?usp=sharing";
        Launcher.OpenAsync(new Uri(url));
    }
}