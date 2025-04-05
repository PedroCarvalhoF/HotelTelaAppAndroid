using HotelTelaApp.Models;
using HotelTelaApp.Views;

namespace HotelTelaApp
{
    public partial class App : Application
    {
        public List<Quarto> ListaQuartos = new List<Quarto>
        {
            new Quarto
            {
                Descricao= "Suíte Super Luxo",
                ValorDiariaAdulto=100.00,
                ValorDiariaCrianca=50.00,
            },
            new Quarto
            {
                Descricao= "Suíte Luxo",
                ValorDiariaAdulto=80,
                ValorDiariaCrianca=40,
            },
            new Quarto
            {
                Descricao= "Suíte Single",
                ValorDiariaAdulto=50,
                ValorDiariaCrianca=25,
            },
            new Quarto
            {
                Descricao= "Suíte Crise",
                ValorDiariaAdulto=25,
                ValorDiariaCrianca=12.50,
            }
        };


        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new ContratacaoHospedagemPage()));
        }
    }
}
