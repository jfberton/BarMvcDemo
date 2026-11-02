using BarMvcDemo.Models;
using BarMvcDemo.Views;
using BarMvcDemo.Controllers;

namespace BarMvcDemo;

internal class Program
{
    static void Main(string[] args)
    {
        // 1. Instanciamos el Modelo
        var barman = new Barman();

        // 2. Instanciamos la Vista
        var view = new ConsolaView();

        // 3. Inyectamos Modelo y Vista en el Controlador
        var controller = new BarController(barman, view);

        // 4. Arranca el ciclo de la aplicación
        controller.Iniciar();
    }
}