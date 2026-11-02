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

    // PASO 1 - APLICACIÓN DE SRP (Single Responsibility Principle)
    // Se centraliza la captura de entrada por consola en la Vista.
    // El Controlador ya no debe acceder a Console.ReadLine() directamente.
    public string? LeerOpcion()
    {
        return Console.ReadLine();
    }

    // PASO 1 - APLICACIÓN DE SRP:
    // La Vista asume la responsabilidad de mostrar el resultado del servicio,
    // que antes el Modelo imprimía indebidamente por su cuenta.
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