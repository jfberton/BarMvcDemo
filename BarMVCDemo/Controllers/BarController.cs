namespace BarMvcDemo.Controllers;

using BarMvcDemo.Models;
using BarMvcDemo.Views;

public class BarController
{
    private readonly Barman _barman;
    private readonly ConsolaView _view;
    private readonly List<Cerveza> _cartaDeCervezas;

    public BarController(Barman barman, ConsolaView view)
    {
        _barman = barman;
        _view = view;

        // PASO 2 - APLICACIÓN DE OCP:
        // Definimos la carta de cervezas disponibles usando polimorfismo.
        // (Nota para Paso 3: Instanciar clases concretas aquí viola DIP; 
        // en el siguiente paso abstraeremos esto con un catálogo o fábrica inyectada).
        _cartaDeCervezas = new List<Cerveza>
        {
            new CervezaRubia(),
            new CervezaNegra(),
            new CervezaRoja() // Nueva variedad incorporada sin tocar las anteriores
        };
    }

    public void Iniciar()
    {
        bool ejecutando = true;

        while (ejecutando)
        {
            _view.MostrarMenu(_cartaDeCervezas);
            string? opcion = _view.LeerOpcion();

            // PASO 2 - APLICACIÓN DE OCP:
            // Eliminamos el switch rígido (case "1", case "2", etc.).
            // Ahora la selección se procesa dinámicamente según las cervezas disponibles en la carta.
            if (int.TryParse(opcion, out int seleccion) && seleccion >= 1 && seleccion <= _cartaDeCervezas.Count)
            {
                var cervezaSeleccionada = _cartaDeCervezas[seleccion - 1];
                string mensaje = _barman.ServirCerveza(cervezaSeleccionada);
                _view.MostrarCervezaServida(mensaje);
                _view.Pausa();
            }
            else if (seleccion == _cartaDeCervezas.Count + 1)
            {
                ejecutando = false;
                _view.MostrarMensaje("Cerrando el bar. ¡Hasta la próxima!");
            }
            else
            {
                _view.MostrarMensaje("Opción inválida. Intente de nuevo.");
                _view.Pausa();
            }
        }
    }
}
