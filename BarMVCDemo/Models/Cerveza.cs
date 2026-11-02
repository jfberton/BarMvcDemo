namespace BarMvcDemo.Models;

// PASO 2 - APLICACIÓN DE OCP (Open/Closed Principle)
//
// ANTES (Paso 0 y 1):
// Existía un enum 'TipoCerveza' y una única clase 'Cerveza' con condicionales (if/else).
// VIOLACIÓN: Para agregar un nuevo tipo (ej. Roja o IPA), estábamos obligados a MODIFICAR
// el enum y la clase Cerveza existente. El código no estaba "cerrado a la modificación".
//
// AHORA:
// Convertimos 'Cerveza' en una clase base abstracta con polimorfismo.
// Cada variedad es una clase que extiende de Cerveza.
// El sistema queda "abierto a la extensión y cerrado a la modificación":
// para agregar una nueva cerveza, creamos una nueva clase sin tocar las anteriores.

public abstract class Cerveza
{
    public abstract string Nombre { get; }
    public abstract string Servir();
}

public class CervezaRubia : Cerveza
{
    public override string Nombre => "Rubia";

    public override string Servir()
    {
        return "🍺 Tirando una pinta de Rubia suave y refrescante...";
    }
}

public class CervezaNegra : Cerveza
{
    public override string Nombre => "Negra";

    public override string Servir()
    {
        return "🍺 Tirando una pinta de Negra tostada con espuma cremosa...";
    }
}

// ¡Demostración de OCP!: Agregamos CervezaRoja sin tener que modificar CervezaRubia ni CervezaNegra.
public class CervezaRoja : Cerveza
{
    public override string Nombre => "Roja";

    public override string Servir()
    {
        return "🍺 Tirando una pinta de Roja caramelizada y maltosa...";
    }
}