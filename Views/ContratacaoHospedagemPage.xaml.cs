using HotelTelaApp.Models;

namespace HotelTelaApp.Views;

public partial class ContratacaoHospedagemPage : ContentPage
{
    App? PropriedadesApp;
    public ContratacaoHospedagemPage()
    {
        InitializeComponent();

        PropriedadesApp = (App)Application.Current! ?? throw new ArgumentException("Erro de compilação");
        pckQuarto.ItemsSource = PropriedadesApp.ListaQuartos;

        dtpCheckIn.MinimumDate = DateTime.Now;
        dtpCheckIn.MaximumDate = DateTime.Now.AddDays(30);

        dtpCheckOut.MinimumDate = dtpCheckIn.Date.AddDays(1);
        dtpCheckOut.MaximumDate = dtpCheckIn.Date.AddMonths(6);

    }

    private async void btnAvancar_Clicked(object sender, EventArgs e)
    {
        try
        {
            var quarto_selecionado = pckQuarto.SelectedItem as Quarto;

            if (quarto_selecionado == null)
                throw new ArgumentException("Selecione um quarto");

            HospedagemModel h = new HospedagemModel
            {
                QuartoSelecionado = quarto_selecionado,
                QtdAdultos = Convert.ToInt32(stpAdultos.Value),
                QtdCriancas = Convert.ToInt32(stpCriancas.Value),
                DataCheckIn = dtpCheckIn.Date,
                DataCheckOut = dtpCheckOut.Date,
            };
            await Navigation.PushAsync(new HospedagemContratadaPage()
            {
                BindingContext = h
            });
        }
        catch (Exception ex)
        {

            DisplayAlert("Algo deu errado", ex.Message, "ok");
        }
    }

    private void dtpCheckIn_DateSelected(object sender, DateChangedEventArgs e)
    {
        try
        {
            DatePicker elemento = (DatePicker)sender;

            DateTime data_selecionada_checkin = elemento.Date;

            dtpCheckOut.MinimumDate = data_selecionada_checkin.AddDays(1);
            dtpCheckOut.MaximumDate = data_selecionada_checkin.AddMonths(6);
        }
        catch (Exception ex)
        {

            DisplayAlert("Algo deu errado", ex.Message, "ok");
        }
    }
}