## 🟡 NIVEL MEDIO (Mid-level / 2-5 años)

### C# Avanzado

26. **¿Qué son los delegates y eventos en C#? ¿Cuál es la diferencia?**

    ### **Delegates (Delegados)**

    Un delegado es un **tipo** que representa una referencia a un método con una firma específica (parámetros y valor de retorno). Piénsalo como un "puntero a funciones" seguro y tipado.
    - **Función:** Permite pasar métodos como si fueran variables o parámetros.
    - **Multicast:** Un solo delegado puede apuntar a varios métodos a la vez y ejecutarlos todos en orden.

    ### **Events (Eventos)**

    Es una encapsulación sobre los delegados que sigue el patrón **Publicador/Suscriptor**. Permite que una clase notifique a otras cuando sucede algo importante (como un clic, un cambio de estado o la llegada de un mensaje).
    - **Seguridad:** A diferencia de un delegado puro, un evento solo puede ser "disparado" (invocado) por la clase que lo contiene. Los externos solo pueden suscribirse (`+=`) o desuscribirse (`-=`).

    ### **Diferencias Clave**

    | Característica | Delegate                                                    | Event                                              |
    | -------------- | ----------------------------------------------------------- | -------------------------------------------------- |
    | **Naturaleza** | Es un tipo de dato (una variable).                          | Es un modificador/capa sobre un delegado.          |
    | **Invocación** | Cualquier clase que tenga acceso puede invocarlo.           | **Solo** la clase que lo define puede invocarlo.   |
    | **Uso común**  | Callbacks, LINQ, pasar lógica como parámetro.               | Comunicación entre objetos, interfaces de usuario. |
    | **Seguridad**  | Baja (alguien externo puede borrar todos los suscriptores). | Alta (protege la lista de suscriptores).           |

    > **En resumen:** Un delegado es la herramienta técnica para referenciar métodos, mientras que un evento es un patrón de diseño que usa delegados de forma segura para notificar cambios.

27. **Explica qué son los generics (tipos genéricos) y por qué son útiles.**
    **¿Qué son los Generics?**
    Son una funcionalidad que permite escribir clases, interfaces o métodos con un "marcador de posición" (usualmente `<T>`) para el tipo de dato. El tipo real se define recién cuando el código es utilizado, no cuando se escribe.

    ### **¿Por qué son útiles?**
    - **Seguridad de tipos (Type Safety):** El compilador verifica que solo uses el tipo de dato correcto. Si intentas meter un `string` en una `List<int>`, el código no compilará, evitando errores en tiempo de ejecución.
    - **Rendimiento (Performance):** Evitan el proceso de **Boxing y Unboxing** al trabajar con tipos por valor (como `int` o `struct`). No hay necesidad de convertir todo a `object`.
    - **Reutilización de código:** Puedes escribir una sola lógica de ordenamiento o almacenamiento (como un repositorio) que funcione para cualquier clase de tu sistema sin repetir código.

    > **Ejemplo rápido:** En lugar de crear una `ListaDeEnteros` y una `ListaDeStrings`, usas la clase genérica `List<T>`, donde `T` puede ser `int`, `string` o cualquier objeto personalizado.

28. **¿Qué es el patrón `IDisposable` y cuándo deberías implementarlo?**
    Es una interfaz que permite liberar **recursos no administrados** (memoria fuera del control del Garbage Collector) de forma manual y predecible.

    ### **¿Qué limpia?**
    - **Recursos no administrados:** Conexiones a bases de datos, punteros de archivos (streams), sockets de red o manejadores de ventanas (GDI+).
    - **Recursos administrados:** Otros objetos que también implementen `IDisposable`.

    ### **¿Cuándo implementarlo?**
    1. **Si tu clase usa recursos del SO:** Si abres archivos o conexiones directamente.
    2. **Si tu clase "es dueña" de otros objetos Disposable:** Si tienes un `HttpClient` o un `DbContext` como campo privado en tu clase, debes ser `IDisposable` para cerrarlos correctamente.

    ### **El bloque `using**`

    Al implementar esta interfaz, permites el uso de la instrucción `using`, la cual garantiza que el método `Dispose()` se llame automáticamente, incluso si ocurre una excepción, evitando fugas de memoria (_memory leaks_).

29. **Explica la diferencia entre `async/await` y el uso de `Task`. ¿Qué es `Task.Run()`?**

    ### **Async / Await vs. Task**
    - **`Task`:** Es un **objeto** que representa una operación en curso. Piénsalo como una "promesa" de que algo se completará. Contiene información sobre si la operación terminó, si falló o cuál fue el resultado.
    - **`async` / `await`:** Son **palabras clave** (azúcar sintáctico) que facilitan el uso de las `Task`.
    - `async` permite que un método use `await`.
    - `await` le dice al programa: "Pausa la ejecución de este método hasta que esta tarea termine, pero mientras tanto, **libera el hilo actual** para que pueda hacer otros trabajos (como mantener la interfaz fluida o atender otras peticiones)".

    ### **¿Qué es `Task.Run()`?**
    - Es un método que se utiliza para mover una tarea a un **hilo secundario** del _Thread Pool_ (pila de hilos).
    - **Propósito:** Ejecutar código que consume mucha **CPU** (cálculos matemáticos complejos, procesamiento de imágenes) sin bloquear el hilo principal.
    - **Diferencia clave:** Mientras que el `await` normal en una base de datos "libera" el hilo para que nadie lo use mientras espera, `Task.Run()` "ocupa" un hilo nuevo para ponerlo a trabajar activamente.

    ### **Comparativa de Uso**

    | Escenario                            | Herramienta       | Acción                                                                        |
    | ------------------------------------ | ----------------- | ----------------------------------------------------------------------------- |
    | **I/O Bound** (BD, APIs, Archivos)   | `async` / `await` | El hilo se libera para otros; nadie trabaja mientras el disco/red responde.   |
    | **CPU Bound** (Cálculos, Algoritmos) | `Task.Run()`      | Se asigna un hilo trabajador para procesar la lógica pesada en segundo plano. |

    > **Advertencia de Arquitecto:** En ASP.NET Core, usar `Task.Run()` dentro de un controlador se considera generalmente una mala práctica (anti-pattern), ya que agota los hilos disponibles para atender a otros usuarios.

30. **¿Qué son las extension methods y cómo se crean?**
    **¿Qué son?**
    Son una forma de "agregar" nuevos métodos a tipos de datos ya existentes (como `string`, `int` o incluso interfaces de terceros) sin necesidad de modificar el código fuente original ni usar herencia. Permiten que el nuevo método aparezca en el IntelliSense como si fuera un método nativo del objeto.

    **¿Cómo se crean?**
    Para crear una extension method, debes cumplir tres reglas estrictas:
    1. **Clase estática:** El método debe estar dentro de una clase marcada como `static`.
    2. **Método estático:** El método en sí mismo debe ser `static`.
    3. **Palabra clave `this`:** El primer parámetro del método debe llevar el modificador `this`, seguido del tipo de dato que quieres extender.

    **Ejemplo rápido:**
    Si quieres agregar un método a todos los `string` para contar palabras:

    ```csharp
    public static class StringExtensions
    {
        public static int ContarPalabras(this string texto)
        {
            return texto.Split(' ').Length;
        }
    }

    // Uso:
    string frase = "Hola .NET";
    int total = frase.ContarPalabras(); // Aparece como si fuera nativo

    ```

    **¿Por qué son útiles?**
    - **Legibilidad:** Hacen el código más limpio y "fluido".
    - **LINQ:** Toda la potencia de LINQ (como `.Where()` o `.Select()`) está construida precisamente usando extension methods sobre la interfaz `IEnumerable`.

31. **Explica qué es reflection y da un ejemplo de uso práctico.**
    **¿Qué es?**
    Es la capacidad de un programa en .NET para inspeccionar sus propios metadatos en **tiempo de ejecución**. Permite que tu código "se mire al espejo" para descubrir qué clases, métodos, propiedades o atributos existen, incluso si no los conocías al momento de compilar.

    **¿Para qué sirve? (Uso práctico)**
    Se utiliza principalmente en herramientas que deben trabajar con tipos de datos de forma dinámica. Algunos ejemplos reales son:
    - **Serialización:** Convertir un objeto a JSON (como hace `System.Text.Json`) leyendo sus propiedades dinámicamente.
    - **Mapeo de objetos:** Herramientas como **AutoMapper** usan Reflection para encontrar propiedades con el mismo nombre en diferentes clases.
    - **Inyección de Dependencias:** El contenedor de .NET escanea tus clases para saber cuáles debe instanciar automáticamente.

    **Ejemplo rápido:**

    ```csharp
    var miObjeto = new { Id = 1, Nombre = "Jose" };
    var tipo = miObjeto.GetType();

    // Inspeccionamos las propiedades dinámicamente
    foreach (var prop in tipo.GetProperties()) {
        Console.WriteLine($"{prop.Name}: {prop.GetValue(miObjeto)}");
    }

    ```

    ### **Pros y Contras**

    | Ventaja                                                                           | Desventaja                                                                                     |
    | --------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------- |
    | **Flexibilidad:** Permite crear código genérico que funciona con cualquier clase. | **Rendimiento:** Es mucho más lento que el acceso directo a los datos.                         |
    | **Poder:** Puede acceder incluso a miembros privados o protegidos.                | **Seguridad:** Aumenta el riesgo de errores en tiempo de ejecución al perder el tipado fuerte. |

32. **¿Qué son los atributos (attributes) en C#? Da ejemplos.**
    Son etiquetas o metadatos que se añaden a tu código (clases, métodos, propiedades) para proporcionar información adicional. No cambian la lógica del código por sí mismos, sino que sirven para que el compilador o herramientas externas (como Entity Framework o ASP.NET) sepan cómo tratar ese elemento.

    **Sintaxis:** Se colocan entre corchetes `[]` justo encima del elemento que quieres "decorar".

    ### **Ejemplos comunes:**
    - **`[Required]`:** En validación de datos, indica que una propiedad no puede ser nula.
    - **`[Authorize]`:** En ASP.NET, restringe el acceso a un controlador solo a usuarios autenticados.
    - **`[Serializable]`:** Indica que una clase puede convertirse en un formato para ser guardada o enviada (como binario).
    - **`[Obsolete]`:** Marca un método como antiguo, lanzando una advertencia al programador que intente usarlo.

    ### **¿Cómo funcionan?**

    La mayoría de los atributos son leídos en **tiempo de ejecución** mediante **Reflection**. Por ejemplo, cuando envías un formulario, ASP.NET "mira" si tus propiedades tienen el atributo `[Required]` y decide si el modelo es válido o no.

33. **¿Cuál es la diferencia entre `Task` y `Thread`?**
    En términos simples: un **`Thread`** es una unidad de ejecución a bajo nivel (el "trabajador"), mientras que una **`Task`** es una abstracción de alto nivel que representa una unidad de trabajo (el "empleo").
    - **Nivel de abstracción:** `Thread` es un concepto directo del Sistema Operativo. `Task` es parte de la TPL (Task Parallel Library) y es mucho más fácil de manejar.
    - **Gestión de recursos:** Crear un `Thread` es costoso en memoria y tiempo. Las `Task` utilizan el **ThreadPool**, reutilizando hilos existentes para ser mucho más eficientes.
    - **Resultados y Continuación:** Una `Task` puede devolver un valor (`Task<T>`) y permite encadenar operaciones fácilmente con `await`. Un `Thread` no devuelve valores de forma nativa y es difícil de coordinar.
    - **Cancelación:** Las `Task` soportan un modelo estándar de cancelación mediante `CancellationToken`, algo que es complejo y peligroso de implementar manualmente con hilos.

    | Característica            | `Thread`                               | `Task`                             |
    | ------------------------- | -------------------------------------- | ---------------------------------- |
    | **Peso**                  | Pesado (1MB de stack por defecto)      | Ligero (Abstracción)               |
    | **Uso de CPU**            | Crea un hilo nuevo casi siempre        | Reutiliza hilos del **ThreadPool** |
    | **Soporta `async/await**` | No                                     | **Sí**                             |
    | **Recomendación**         | Solo para tareas de muy larga duración | **Estándar para casi todo**        |

34. **¿Qué son los record types introducidos en C# 9? ¿Cuándo los usarías?**
    Un **`record`** es un tipo de referencia (o valor, a partir de C# 10) diseñado específicamente para ser un contenedor de datos. Su diferencia fundamental con una `class` es que utiliza **igualdad basada en valores** en lugar de igualdad basada en la ubicación en memoria (referencia).

    ### Puntos clave:
    - **Igualdad por valor:** Si dos `records` tienen exactamente los mismos datos en sus propiedades, el operador `==` devolverá `true`, aunque sean objetos distintos en la RAM.
    - **Inmutabilidad (Opcional pero recomendada):** Están optimizados para ser inmutables (que no cambien una vez creados) mediante el uso de propiedades `init`.
    - **Sintaxis "Positional":** Puedes definir una clase completa en una sola línea: `public record Persona(string Nombre, int Edad);`. El compilador genera automáticamente el constructor y las propiedades por ti.
    - **Expresiones `with`:** Permiten crear una copia de un objeto existente pero cambiando solo algunas de sus propiedades de forma muy sencilla.

    ### ¿Cuándo usarlo?
    - **DTOs (Data Transfer Objects):** Para transferir datos entre capas o APIs.
    - **Resultados de consultas:** Para manejar información que viene de una base de datos y que no necesita lógica de negocio compleja.
    - **Configuraciones:** Para objetos que se cargan al inicio y deben permanecer constantes.
    - **Simplificación de código:** Siempre que necesites un objeto que solo guarde datos y quieras ahorrarte escribir manualmente los métodos `Equals`, `GetHashCode` y `ToString`.

35. **Explica qué es pattern matching en C# y da ejemplos.**
    **Pattern Matching** es una técnica que permite probar una expresión para determinar si tiene ciertas características y, de ser así, extraer información de ella de forma segura y concisa. Es una alternativa mucho más potente y legible a los bloques `if/else` y `switch` tradicionales.porwe

    ### Tipos de patrones más comunes:
    - **Type Pattern (`is`):** Comprueba el tipo y asigna una variable al mismo tiempo, evitando el "casting" manual.

    ```csharp
    if (objeto is string texto) {
        Console.WriteLine(texto.Length); // 'texto' ya es de tipo string
    }

    ```

    - **Switch Expressions (C# 8+):** Una versión simplificada del `switch` que devuelve un valor directamente.

    ```csharp
    string mensaje = temperatura switch {
        < 0 => "Congelado",
        0 => "Punto de congelación",
        < 20 => "Fresco",
        _ => "Caliente" // El descarte (default)
    };

    ```

    - **Property Pattern:** Permite evaluar propiedades específicas de un objeto.

    ```csharp
    if (empleado is { Departamento: "IT", EsActivo: true }) {
        // Lógica para empleados de IT activos
    }

    ```

    - **Logical Patterns (C# 9+):** Uso de `and`, `or` y `not`.

    ```csharp
    if (input is not null and not "") { ... }

    ```

    ***

    ### ¿Por qué es útil?
    1. **Seguridad:** Reduce errores de `NullReferenceException` y fallos de casting.
    2. **Legibilidad:** El código parece lenguaje natural y elimina el "ruido" visual de llaves y palabras clave repetitivas.
    3. **Mantenimiento:** Facilita la adición de nuevas condiciones sin romper la estructura lógica.

### LINQ y Entity Framework

36. **¿Cuál es la diferencia entre query syntax y method syntax en LINQ?**
    En C#, existen dos formas de escribir consultas LINQ. Ambas compilan exactamente al mismo código (lenguaje intermedio), por lo que la diferencia es puramente estética y de legibilidad.

    ### **1. Method Syntax (Sintaxis de Métodos)**

    Es la forma más común y moderna. Utiliza **métodos de extensión** y **expresiones lambda**.
    - **Ejemplo:** `lista.Where(x => x.Edad > 18).Select(x => x.Nombre);`
    - **Ventaja:** Es más potente (algunos operadores como `Distinct` o `Take` solo existen aquí) y es más fácil de encadenar.

    ### **2. Query Syntax (Sintaxis de Consulta)**

    Tiene una estructura muy parecida a **SQL**. Siempre empieza con la palabra `from` y termina con `select` o `group`.
    - **Ventaja:** Es mucho más legible cuando realizas operaciones complejas de **Join** o **Group By**.

    ### **Comparativa Rápida**

    | Característica  | Method Syntax                       | Query Syntax                             |
    | --------------- | ----------------------------------- | ---------------------------------------- |
    | **Legibilidad** | Excelente para filtros simples.     | Excelente para Joins y agrupaciones.     |
    | **Poder**       | Acceso a todos los operadores LINQ. | Limitada a operadores básicos.           |
    | **Sintaxis**    | Basada en Lambdas `=>`.             | Basada en palabras clave (`from`, `in`). |
    | **Preferencia** | Estándar en la industria.           | Preferida por desarrolladores SQL.       |

    > **Dato Clave:** Tras bambalinas, el compilador traduce siempre la **Query Syntax** a **Method Syntax** antes de ejecutarla.

37. **¿Qué es la ejecución diferida (deferred execution) en LINQ?**
    Es el comportamiento donde una consulta **no se ejecuta cuando la defines**, sino hasta que realmente **navegas o iteras** por los resultados.

    ### Puntos clave:
    - **Es una "receta", no el plato:** La variable de la consulta solo guarda las instrucciones (qué filtrar, qué ordenar), no los datos resultantes.
    - **¿Cuándo ocurre la ejecución?:** Solo cuando los datos son necesarios, por ejemplo, al iniciar un `foreach` o al llamar a métodos de conversión inmediata como `.ToList()`, `.ToArray()`, o `.Count()`.
    - **Ventaja:** Siempre obtienes la información más fresca de la fuente de datos en el preciso instante en que la usas, no cuando escribiste la línea de código.

38. **Explica qué es Entity Framework y cómo funciona.**
    Es el **ORM (Object-Relational Mapper)** oficial de Microsoft para .NET. Su función principal es actuar como un puente entre el mundo de la programación orientada a objetos (C#) y el mundo de las bases de datos relacionales (SQL), permitiéndote manipular datos usando código en lugar de escribir consultas SQL manualmente.

    ### Componentes clave:
    - **`DbContext`:** Es el corazón de EF. Representa una sesión con la base de datos y es el encargado de coordinar la conexión, las consultas y el rastreo de cambios.
    - **`DbSet<T>`:** Representa una tabla específica de la base de datos como una colección de objetos en C#.
    - **LINQ to Entities:** Es el motor que traduce tus consultas de C# (como `.Where()` o `.First()`) a lenguaje SQL optimizado para el motor que estés usando (SQL Server, PostgreSQL, MySQL, etc.).
    - **Migrations:** Un sistema para llevar el control de versiones de tu base de datos. Si agregas una propiedad a tu clase en C#, las migraciones actualizan la tabla correspondiente sin perder los datos.

    ### ¿Cómo funciona en la práctica?
    1. **Mapeo:** Defines una clase (ej. `Usuario`) y EF entiende que esa clase corresponde a una tabla.
    2. **Consulta:** Escribes `context.Usuarios.ToList()`.
    3. **Traducción:** EF genera automáticamente un `SELECT * FROM Usuarios` y lo envía a la base de datos.
    4. **Materialización:** EF recibe las filas de la base de datos y las convierte automáticamente en una lista de objetos de tipo `Usuario` para que puedas usarlos.

39. **¿Cuál es la diferencia entre Code First, Database First y Model First en EF?**
40. **¿Qué son las migraciones en Entity Framework?**
41. **Explica el problema N+1 en Entity Framework y cómo resolverlo.**
42. **¿Qué es lazy loading vs eager loading? ¿Cuándo usar cada uno?**
43. **¿Qué son las DbContext y DbSet en Entity Framework?**
44. **¿Cómo manejas transacciones en Entity Framework?**
45. **¿Qué es el tracking en EF? ¿Cuándo usarías `.AsNoTracking()`?**

### ASP.NET Core / Web API

46. **¿Cuál es la diferencia entre ASP.NET Framework y ASP.NET Core?**
47. **Explica el sistema de Dependency Injection en ASP.NET Core.**
48. **¿Cuáles son los diferentes lifetimes en DI (Transient, Scoped, Singleton)?**
49. **¿Qué es middleware en ASP.NET Core? Da ejemplos.**
50. **¿Cómo implementarías autenticación y autorización en ASP.NET Core?**
51. **¿Qué es JWT y cómo lo usarías para autenticación?**
52. **Explica los diferentes tipos de ActionResult (Ok, NotFound, BadRequest, etc.).**
53. **¿Cómo manejas la validación de modelos en ASP.NET Core?**
54. **¿Qué son los filtros (filters) en ASP.NET Core? Tipos y ejemplos.**
55. **¿Cómo implementarías versionado de API en ASP.NET Core?**

### Diseño y Arquitectura

56. **Explica el patrón Repository y Unit of Work.**
57. **¿Qué es SOLID? Explica cada principio.**
58. **¿Qué es la arquitectura en capas (layered architecture)?**
59. **Explica el patrón Factory y cuándo lo usarías.**
60. **¿Qué es el patrón Singleton y cuáles son sus desventajas?**

### Testing

61. **¿Qué es unit testing? ¿Qué frameworks de testing conoces para .NET?**
62. **¿Cuál es la diferencia entre un mock, stub y fake?**
63. **¿Qué es TDD (Test-Driven Development)?**
64. **¿Cómo mockearías una dependencia usando Moq?**
65. **¿Qué es el patrón AAA (Arrange-Act-Assert) en testing?**

---
