namespace HotelTelaApp.Models;
public class HospedagemModel
{
    public Quarto? QuartoSelecionado { get; set; }
    public int QtdAdultos { get; set; }
    public int QtdCriancas { get; set; }
    public DateTime DataCheckIn { get; set; }
    public DateTime DataCheckOut { get; set; }

    public int Estadia
    {
        get
        {
            return DataCheckOut.Subtract(DataCheckIn).Days;
        }
    }

    public double ValorTotal
    {
        get
        {
            double valorTotal = 0;
            if (QuartoSelecionado != null)
            {
                valorTotal += (QtdAdultos * QuartoSelecionado.ValorDiariaAdulto * Estadia);
                valorTotal += (QtdCriancas * QuartoSelecionado.ValorDiariaCrianca * Estadia);
            }
            return valorTotal;
        }
    }
}
