namespace BarMvcDemo.Views;

using BarMvcDemo.Models;

// PASO 3 - APLICACIÓN DE ISP (Interface Segregation Principle) y DIP (Dependency Inversion Principle)
// Contrato específico para la vista que necesita el controlador.
// Permite sustituir ConsolaView por una vista Web, Gráfica o un Mock de pruebas sin tocar el controlador.
public interface IBarView
{
    void MostrarMenu(IReadOnlyList<Cerveza> cervezasDisponibles);
    string? LeerOpcion();
    void MostrarCervezaServida(string detalle);
    void MostrarMensaje(string mensaje);
    void Pausa();
}

