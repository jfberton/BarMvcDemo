namespace BarMvcDemo.Models;

public class Barman
{
    public string Nombre { get; set; } = "Moe";

    public void AtenderPedido(TipoCerveza tipo)
    {
        Cerveza cerveza = new Cerveza(tipo);
        cerveza.Servir();
    }
}
