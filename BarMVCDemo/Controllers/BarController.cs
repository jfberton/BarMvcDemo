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
            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    _barman.AtenderPedido(TipoCerveza.Rubia);
                    _view.Pausa();
                    break;
                case "2":
                    _barman.AtenderPedido(TipoCerveza.Negra);
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