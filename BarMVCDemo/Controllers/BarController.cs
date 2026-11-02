namespace BarMvcDemo.Controllers;

using BarMvcDemo.Models;
using BarMvcDemo.Views;

// PASO 3 - APLICACIÓN DE DIP (Dependency Inversion Principle) e ISP (Interface Segregation Principle)
//
// ANTES:
// BarController dependía de clases concretas (Barman, ConsolaView) y hacía 'new' de las cervezas.
// VIOLACIÓN: Módulos de alto nivel acoplados a detalles de bajo nivel. Imposible testear con mocks
// o cambiar a otra interfaz de usuario (web/GUI).
//
// AHORA:
// BarController depende EXCLUSIVAMENTE de abstracciones (IBarman, IBarView) y recibe la carta
// inyectada desde el exterior (Inversión de Control / Inyección de Dependencias).
public class BarController
{
    private readonly IBarman _barman;
    private readonly IBarView _view;
    private readonly IReadOnlyList<Cerveza> _cartaDeCervezas;

    public BarController(IBarman barman, IBarView view, IReadOnlyList<Cerveza> cartaDeCervezas)
    {
        _barman = barman;
        _view = view;
        _cartaDeCervezas = cartaDeCervezas;
    }

    public void Iniciar()
    {
        bool ejecutando = true;

        while (ejecutando)
        {
            _view.MostrarMenu(_cartaDeCervezas);
            string? opcion = _view.LeerOpcion();

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
