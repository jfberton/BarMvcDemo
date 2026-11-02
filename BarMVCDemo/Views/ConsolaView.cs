namespace BarMvcDemo.Views;

using BarMvcDemo.Models;

// PASO 3 - Implementamos IBarView para cumplir con DIP e ISP
public class ConsolaView : IBarView
{
    public void MostrarMenu(IReadOnlyList<Cerveza> cervezasDisponibles)
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("    BIENVENIDO AL BAR (PATRÓN MVC)     ");
        Console.WriteLine("========================================");

        for (int i = 0; i < cervezasDisponibles.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Pedir Cerveza {cervezasDisponibles[i].Nombre}");
        }

        Console.WriteLine($"{cervezasDisponibles.Count + 1}. Salir");
        Console.Write("\nSeleccione una opción: ");
    }

    public string? LeerOpcion()
    {
        return Console.ReadLine();
    }

    public void MostrarCervezaServida(string detalle)
    {
        Console.WriteLine($"\n{detalle}");
    }

    public void MostrarMensaje(string mensaje)
    {
        Console.WriteLine($"\n>> {mensaje}");
    }

    public void Pausa()
    {
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}
