# 🍻 Bar MVC Demo — Arquitectura & Refactorización SOLID

¡Bienvenidos a **Bar MVC Demo**! Este es un proyecto en **C# / .NET** diseñado para estudiar, analizar y poner en práctica:
1. El patrón de arquitectura **MVC (Modelo - Vista - Controlador)** en una aplicación de consola.
2. Los principios de diseño de software **SOLID**.
3. El proceso de **refactorización progresiva**, comparando el código antes y después de aplicar buenas prácticas.

---

## 🏛️ ¿Cómo está pensado el patrón MVC aquí?

La aplicación simula la atención en la barra de un bar:
* **Modelo (`Models/`)**: Contiene las entidades y la lógica de negocio del dominio (`Cerveza`, `Barman`).
* **Vista (`Views/`)**: Encargada de mostrar la información al usuario y solicitar entradas (`ConsolaView`).
* **Controlador (`Controllers/`)**: Orquesta el flujo de la aplicación (`BarController`), respondiendo a las acciones del usuario, invocando al Modelo y ordenando a la Vista qué presentar.

---

## 🧭 ¿Cómo navegar por la evolución del proyecto?

El repositorio está organizado de forma cronológica mediante **Tags (etiquetas de Git)** para que puedas viajar en el tiempo y ver exactamente cómo fue evolucionando el diseño:

```bash
# Ver el estado inicial (con trampas):
git checkout paso-0-inicial

# Ver la corrección de SRP y MVC:
git checkout paso-1-srp

# Ver la corrección de OCP (polimorfismo y extensibilidad):
git checkout paso-2-ocp

# Ver la arquitectura final desacoplada con DIP e ISP:
git checkout paso-3-dip-isp

# Volver a la última versión disponible:
git checkout main
```

> **Tip:** También podés ver las diferencias directamente en GitHub ingresando a la pestaña **Commits** o comparando las versiones para ver en verde y rojo qué líneas cambiaron en cada refactorización.

---

## 📍 Paso 0: Estado Inicial (¡Trampas y violaciones adrede!)

La versión identificada con la etiqueta `paso-0-inicial` compila y funciona, pero fue programada **con errores y antipatrones adrede** para analizar.

### 🔍 Preguntas disparadoras para analizar el código:
1. **Responsabilidades mezcladas (SRP & MVC):**
   * ¿Qué método del Modelo está haciendo operaciones de entrada/salida que deberían pertenecer a la interfaz de usuario?
   * ¿El Controlador le pide a la Vista que capture los datos, o accede directamente a recursos de la consola?
2. **Dificultad de extensión (OCP):**
   * Si el bar decide incorporar cerveza *IPA*, *Roja* o *Honey*, ¿cuántos archivos y estructuras (`enum`, `if/else`, `switch`) tendríamos que modificar? ¿Qué principio estamos violando?
3. **Acoplamiento rígido (DIP):**
   * ¿Qué clases instancian directamente a otras usando `new`? 
   * ¿Podríamos cambiar la consola por una interfaz gráfica (WPF/MAUI) o probar el controlador con pruebas unitarias sin modificar el código fuente?

---

## 📍 Paso 1: Principio de Responsabilidad Única (SRP) y Limpieza de MVC

En esta etapa corregimos las fugas de responsabilidades y restauramos la separación limpia de capas en MVC:

1. **`Cerveza.cs` (Modelo):**
   * **Antes:** Hacía `Console.WriteLine(...)` dentro de `Servir()`.
   * **Problema:** Violaba **SRP** y **MVC**, ya que el Modelo asumía la responsabilidad de presentar información y quedaba fuertemente acoplado a la consola.
   * **Solución:** Ahora `Servir()` retorna un `string`. El Modelo procesa datos y reglas de negocio, dejando la presentación a quien le corresponde.

2. **`ConsolaView.cs` (Vista):**
   * **Mejora:** Se crearon los métodos `LeerOpcion()` (para centralizar la captura del teclado) y `MostrarCervezaServida(mensaje)` (para presentar el texto producido por el Modelo).

3. **`Barman.cs` (Modelo):**
   * **Mejora:** `AtenderPedido()` ahora retorna el resultado de la acción en lugar de depender de efectos colaterales de consola.

4. **`BarController.cs` (Controlador):**
   * **Antes:** Ejecutaba `Console.ReadLine()` directamente.
   * **Problema:** Violaba **SRP**, involucrando al Controlador en detalles de I/O de bajo nivel.
   * **Solución:** Delega la captura a `_view.LeerOpcion()` y coordina el flujo enviando los resultados a la Vista.

---

## 🗺️ Hoja de Ruta de la Refactorización

- [x] **Paso 0 (`paso-0-inicial`)**: Estado base funcional con violaciones intencionales a SOLID y MVC.
- [x] **Paso 1 (`paso-1-srp`)**: Aplicación del Principio de Responsabilidad Única (SRP) y delimitación estricta de MVC.
- [ ] **Paso 2 (`paso-2-ocp`)**: Aplicación del Principio Abierto/Cerrado (OCP) mediante polimorfismo.
- [ ] **Paso 3 (`paso-3-dip-isp`)**: Inversión de Dependencias (DIP) y Segregación de Interfaces (ISP).
