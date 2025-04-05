namespace HotelTelaApp.Views;

public partial class HospedagemContratadaPage : ContentPage
{
    public HospedagemContratadaPage()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PopAsync();
        }
        catch (Exception ex)
        {

            DisplayAlert("Erro", ex.Message, "ok");
        }
    }
}