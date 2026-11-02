namespace BarMvcDemo.Models;

public class Barman
{
    public string Nombre { get; set; } = "Moe";


    
    // CORRECCIÓN - PASO 1 - APLICACIÓN DE SRP:
    // ANTES: el metodo era void ya que se hacia la impresion dentro de la clase Cerveza, y la misma no devolvia nada.
    // AHORA: AtenderPedido retorna el resultado de la acción en lugar de ejecutar
    // efectos secundarios de consola ocultos en el Modelo.
    public string AtenderPedido(TipoCerveza tipo)
    {
        Cerveza cerveza = new Cerveza(tipo);
        //cerveza.Servir(); //antes era un void, ahora es un return.
        return cerveza.Servir();
    }
}
