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

    // PASO 1 - APLICACIÓN DE SRP (Single Responsibility Principle)
    // ANTES: Este método hacía Console.WriteLine(...) directamente.
    // VIOLACIÓN: Violaba SRP y la arquitectura MVC porque el Modelo asumía la responsabilidad
    //     de la presentación (I/O de consola), acoplándose al medio visual. 
    //     Si mañana este modelo se usa en una API Web o app móvil, ese Console.WriteLine no sirve
    // AHORA: El Modelo solo procesa la lógica y retorna información (string).
    //     La responsabilidad de imprimir en pantalla pasa exclusivamente a la Vista.
    public string Servir()
    {
        if (Tipo == TipoCerveza.Rubia)
        {
            //Console.WriteLine("🍺 [Modelo] Tirando una pinta de Rubia suave y refrescante...");
            return "🍺 Tirando una pinta de Rubia suave y refrescante...";
        }
        else
        {
            //Console.WriteLine("🍺 [Modelo] Tirando una pinta de Negra tostada con espuma cremosa...");
            return "🍺 Tirando una pinta de Negra tostada con espuma cremosa...";
        }
    }
}