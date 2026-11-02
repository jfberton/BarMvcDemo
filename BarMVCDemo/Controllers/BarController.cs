namespace BarMvcDemo.Controllers;

using BarMvcDemo.Models;
using BarMvcDemo.Views;

public class BarController
{
    private readonly Barman _barman;
    private readonly ConsolaView _view;

    public BarController(Barman barman, ConsolaView view)
    {
        _barman = barman;
        _view = view;
    }

    public void Iniciar()
    {
        bool ejecutando = true;

        while (ejecutando)
        {
            _view.MostrarMenu();
            
            // PASO 1 - APLICACIÓN DE SRP:
            // ANTES: string? opcion = Console.ReadLine();
            // VIOLACIÓN: El Controlador asumía la responsabilidad de interactuar con el dispositivo de entrada (I/O).
            // AHORA: Delegamos la lectura a la Vista (_view.LeerOpcion()).
            string? opcion = _view.LeerOpcion();

            switch (opcion)
            {
                case "1":
                    // PASO 1 - APLICACIÓN DE SRP:
                    // ANTES: _barman.AtenderPedido(TipoCerveza.Rubia); -> la clase Cerveza hacia la impresion directamente.
                    // AHORA: El Modelo retorna el mensaje de la cerveza servida, y el Controlador
                    // orquesta el flujo enviándolo a la Vista para su presentación.
                    string mensajeRubia = _barman.AtenderPedido(TipoCerveza.Rubia);
                    _view.MostrarCervezaServida(mensajeRubia);
                    _view.Pausa();
                    break;
                case "2":
                    string mensajeNegra = _barman.AtenderPedido(TipoCerveza.Negra);
                    _view.MostrarCervezaServida(mensajeNegra);
                    _view.Pausa();
                    break;
                case "3":
                    ejecutando = false;
                    _view.MostrarMensaje("Cerrando el bar. ¡Hasta la próxima!");
                    break;
                default:
                    _view.MostrarMensaje("Opción inválida. Intente de nuevo.");
                    _view.Pausa();
                    break;
            }
        }
    }
}