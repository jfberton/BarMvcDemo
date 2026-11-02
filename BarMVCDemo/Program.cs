using BarMvcDemo.Models;
using BarMvcDemo.Views;
using BarMvcDemo.Controllers;

namespace BarMvcDemo;

internal class Program
{
    static void Main(string[] args)
    {
        // PASO 3 - COMPOSITION ROOT (Inversión de Dependencias - DIP)
        // Aquí configuramos e instanciamos las dependencias concretas
        // e inyectamos las abstracciones en el controlador.

        // 1. Instanciamos el Modelo (bajo su abstracción IBarman)
        IBarman barman = new Barman();

        // 2. Instanciamos la Vista (bajo su abstracción IBarView)
        IBarView view = new ConsolaView();

        // 3. Configuramos la carta de cervezas disponibles
        var cartaDeCervezas = new List<Cerveza>
        {
            new CervezaRubia(),
            new CervezaNegra(),
            new CervezaRoja()
        };

        // 4. Inyectamos dependencias en el Controlador
        var controller = new BarController(barman, view, cartaDeCervezas);

        // 5. Arranca el ciclo de la aplicación
        controller.Iniciar();
    }
}
