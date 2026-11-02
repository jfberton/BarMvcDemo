namespace BarMvcDemo.Models;

public enum TipoCerveza
{
    Rubia,
    Negra
}

public class Cerveza
{
    public TipoCerveza Tipo { get; set; }

    public Cerveza(TipoCerveza tipo)
    {
        Tipo = tipo;
    }

    public void Servir()
    {
        if (Tipo == TipoCerveza.Rubia)
        {
            Console.WriteLine("🍺 [Modelo] Tirando una pinta de Rubia suave y refrescante...");
        }
        else
        {
            Console.WriteLine("🍺 [Modelo] Tirando una pinta de Negra tostada con espuma cremosa...");
        }
    }
}