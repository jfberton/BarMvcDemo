namespace BarMvcDemo.Models;

public class Barman
{
    public string Nombre { get; set; } = "Moe";

    // PASO 2 - APLICACIÓN DE OCP (Open/Closed Principle):
    // El Barman ahora trabaja con la abstracción polimórfica 'Cerveza'.
    // Puede servir cualquier tipo presente o futuro (Rubia, Negra, Roja, etc.)
    // sin necesidad de modificar este método.
    //
    // (Nota: En el Paso 3 resolveremos la inyección de dependencias y contratos con DIP/ISP).
    public string ServirCerveza(Cerveza cerveza)
    {
        return cerveza.Servir();
    }
}
