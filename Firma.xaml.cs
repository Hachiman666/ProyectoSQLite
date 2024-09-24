namespace ProyectoSQLite;

public partial class Firma : ContentPage
{
	public Firma()
	{
		InitializeComponent();
	}

    private void btipn(System.Object sender, System.EventArgs e)
    {
        DisplayAlert("IPN", "Instituto Politecnico Nacional", "Ok");
    }

    private void btesime(System.Object sender, System.EventArgs e)
    {
        DisplayAlert("ESIME", "Escuela Superior de Ingenieria Mecanica y Electrica", "Ok");
    }

    private void btfoto(object sender, EventArgs e)
    {
        DisplayAlert("Alumno", "Alonso Rodríguez Erick Daniel 2019301253", "Ok");
    }
}