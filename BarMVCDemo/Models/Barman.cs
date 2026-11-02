namespace BarMvcDemo.Models;

// PASO 3 - Implementamos IBarman para cumplir con DIP
public class Barman : IBarman
{
    public string Nombre { get; set; } = "Moe";

    public string ServirCerveza(Cerveza cerveza)
    {
        return cerveza.Servir();
    }
}
