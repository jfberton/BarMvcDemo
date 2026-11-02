namespace BarMvcDemo.Views;

public class ConsolaView
{
    public void MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("    BIENVENIDO AL BAR (PATRÓN MVC)     ");
        Console.WriteLine("========================================");
        Console.WriteLine("1. Pedir Cerveza Rubia");
        Console.WriteLine("2. Pedir Cerveza Negra");
        Console.WriteLine("3. Salir");
        Console.Write("\nSeleccione una opción: ");
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