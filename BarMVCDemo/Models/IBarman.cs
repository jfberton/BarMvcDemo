namespace BarMvcDemo.Models;

// PASO 3 - APLICACIÓN DE DIP (Dependency Inversion Principle)
// Abstracción de alto nivel para el servicio del barman.
// El controlador no depende de la clase concreta 'Barman', sino de este contrato.
public interface IBarman
{
    string Nombre { get; }
    string ServirCerveza(Cerveza cerveza);
}

