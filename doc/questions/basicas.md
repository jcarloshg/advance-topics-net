# Preguntas de Entrevista Técnica - .NET

## 🟢 NIVEL BÁSICO (Junior / 0-2 años)

### Fundamentos de C# y .NET

1. **¿Qué es .NET y cuál es la diferencia entre .NET Framework, .NET Core y .NET 5+?**
   - .NET Framework: El ecosistema original. Solo funciona en Windows. Es tecnología heredada (legacy); actualmente solo recibe actualizaciones de seguridad, pero no nuevas características.
   - .NET Core: La reescritura moderna. Multiplataforma (Windows, Linux, macOS), de código abierto y optimizado para alto rendimiento y microservicios
   - .NET 5+ (6, 7, 8...): La unificación. Es la evolución directa de .NET Core. Microsoft quitó el apellido "Core" y unificó todas las herramientas (incluyendo las de móviles como Xamarin/MAUI) en un solo SDK (kit de desarrollo) universal.

2. **Explica la diferencia entre `string` y `StringBuilder`. ¿Cuándo usarías cada uno?**
   - string (Inmutable)
   - Una vez creado en memoria, su valor no puede cambiar. Si lo modificas o concatenas (ej. texto += "nuevo"), .NET crea un nuevo objeto en la memoria y deja el anterior para que lo limpie el Garbage Collector.
   - Cuándo usarlo: Para textos fijos, variables simples o cuando haces muy pocas concatenaciones (ej. unir nombre y apellido).

   - StringBuilder (Mutable)
   - Maneja un búfer interno que permite modificar el texto directamente en el mismo espacio de memoria, sin crear objetos nuevos constantemente.
   - Cuándo usarlo: Cuando necesites concatenar o modificar texto muchas veces, especialmente dentro de bucles (for, while) o al generar documentos largos (ej. crear un CSV o un JSON a mano).

3. **¿Qué son los tipos por valor (value types) y tipos por referencia (reference types)? Da ejemplos.**
   Tipos por valor (Value Types)
   Almacenan el dato directamente en su propia ubicación de memoria (usualmente en el Stack o pila). Si asignas la variable a otra, se crea una copia exacta e independiente. Si modificas la nueva, la original no cambia.
   Ejemplos: Tipos numéricos (int, double, decimal), booleanos (bool), estructuras (struct), y enumeraciones (enum).

   Tipos por referencia (Reference Types)
   Almacenan una dirección de memoria que apunta al dato real (ubicado en el Heap o montón). Si asignas la variable a otra, ambas apuntan al mismo objeto en memoria; si modificas el objeto desde una variable, el cambio se refleja en la otra.
   Ejemplos: Clases (class), cadenas de texto (string), arreglos (array), interfaces (interface), y object.

4. **¿Qué es el garbage collector y cómo funciona en .NET?**
   ¿Qué es?
   Es el administrador automático de memoria de .NET. Libera a los desarrolladores de la responsabilidad de asignar y destruir objetos manualmente (como se haría en C o C++), previniendo fugas de memoria (memory leaks).

   ¿Cómo funciona?
   El GC monitorea el Managed Heap (montón administrado). Rastrea las referencias activas en tu código; si detecta objetos que ya no están siendo utilizados por la aplicación, reclama ese espacio de memoria.

5. **Explica la diferencia entre `const` y `readonly`.**
   const (Constante en tiempo de compilación)
   Su valor se evalúa y se incrusta directamente en el código cuando compilas la aplicación.
   Reglas: Debes asignarle un valor exacto en la misma línea donde la declaras. Solo acepta tipos primitivos (números, booleanos) y cadenas de texto (string). Además, se comporta como estática (static) automáticamente.
   Cuándo usarlo: Para valores universales que nunca van a cambiar en la vida de la aplicación, como Math.PI, un límite de tamaño fijo o tasas de impuestos inamovibles.

   readonly (Constante en tiempo de ejecución)
   Su valor se asigna en la memoria cuando la aplicación ya está corriendo y se crea el objeto.
   Reglas: Puedes asignarle su valor en la misma línea de declaración o dentro del constructor de la clase. Una vez que el constructor termina de ejecutarse, el valor queda bloqueado y no puede cambiar. Acepta objetos complejos.
   Cuándo usarlo: Para proteger variables que dependen del entorno de ejecución, como leer una ruta de archivo de configuración al iniciar, o —muy comúnmente en .NET— para guardar la referencia de servicios inyectados por dependencia (como tu contexto de base de datos o loggers).

6. **¿Qué es boxing y unboxing? ¿Tiene algún impacto en el rendimiento?**

- Boxing: Es el proceso de convertir un tipo de valor (como un int, double o struct) en un tipo de referencia (object). El valor se "empaqueta" y se mueve de la memoria Stack (pila) a la memoria Heap (montículo).
- Unboxing: Es el proceso inverso; extrae el valor que estaba dentro del objeto y lo devuelve a su tipo original en el Stack.

7. **¿Cuál es la diferencia entre `==` y `.Equals()` en C#?**
   Característica,Operador ==,Método .Equals()
   Tipo de comparación,"Por defecto, compara referencia (identidad).","Por defecto, compara valor (contenido)."
   Naturaleza,Es un operador estático.,Es un método virtual (polimórfico).
   Caso de Nulls,Seguro: null == null es true.,Lanza NullReferenceException si el objeto a la izquierda es nulo.
   Sobrecarga,Se puede sobrecargar como operador.,Se puede sobrescribir (override) para definir lógica personalizada.

8. **¿Qué son los modificadores de acceso (public, private, protected, internal)? Explica cada uno.**
9. **¿Qué es una interface y en qué se diferencia de una clase abstracta?**
10. **Explica qué son las propiedades (properties) y cómo se diferencian de los campos (fields).**

### POO (Programación Orientada a Objetos)

11. **Explica los 4 pilares de la POO: Encapsulación, Herencia, Polimorfismo y Abstracción.**
    - Encapsulación: Consiste en proteger y ocultar el estado interno de un objeto. En C#, lo logras usando modificadores de acceso (private, protected) y exponiendo la información de forma segura a través de propiedades (get, set) para evitar que otras clases modifiquen los datos de forma indebida.
    - Herencia: Permite crear una clase nueva (hija) a partir de una existente (padre), adoptando sus atributos y métodos para fomentar la reutilización de código. En .NET, una clase solo puede heredar de una única clase base, pero puede implementar múltiples interfaces.
    - Polimorfismo: Es la capacidad de que diferentes objetos respondan al mismo método de maneras distintas. Se logra definiendo métodos base como virtual o abstract, y redefiniendo su comportamiento en las clases hijas usando la palabra clave override.
    - Abstracción: Trata de simplificar sistemas complejos enfocándose en qué hace un objeto, ocultando el cómo lo hace (la lógica interna). En .NET, se diseña creando contratos claros mediante clases abstractas (abstract) o interfaces (interface).

12. **¿Qué es la sobrecarga de métodos (method overloading)?**
    - ¿Qué es?
    - Es la capacidad de definir múltiples métodos con el mismo nombre dentro de la misma clase, siempre y cuando sus "firmas" (signatures) sean diferentes. Es una forma de lograr polimorfismo en tiempo de compilación.

    - ¿Cómo funciona en C#?
    - El compilador sabe exactamente cuál versión del método ejecutar basándose en los argumentos que le envías al llamarlo. Para que la sobrecarga sea válida, los parámetros de los métodos deben variar en al menos uno de estos aspectos:

13. **¿Cuál es la diferencia entre `override` y `overload`?**
    **`Overload` (Sobrecarga)**
    - **Qué es:** Mismo nombre de método, pero con **diferentes parámetros** (diferente firma).
    - **Dónde ocurre:** Generalmente dentro de la misma clase.
    - **Comportamiento:** Es polimorfismo en tiempo de compilación. El compilador decide qué versión del método ejecutar basándose en la cantidad o tipo de argumentos que le pasas al llamarlo.
    - **Palabras clave:** No requiere ninguna palabra clave especial.

    **`Override` (Sobrescritura)**
    - **Qué es:** Mismo nombre de método y **exactamente los mismos parámetros** (misma firma), pero con una implementación (lógica) diferente.
    - **Dónde ocurre:** Entre una clase base (padre) y una clase derivada (hija).
    - **Comportamiento:** Es polimorfismo en tiempo de ejecución. Cambia o reemplaza el comportamiento original que dictaba la clase padre.
    - **Palabras clave:** El método en la clase padre debe estar marcado como `virtual` o `abstract`, y el método en la clase hija debe usar explícitamente la palabra clave `override`.

14. **¿Qué son los constructores? ¿Puede una clase tener múltiples constructores?**
    - Son métodos especiales que se ejecutan automáticamente en el exacto momento en que creas un objeto en memoria (al usar la palabra clave `new`). Su propósito principal es inicializar los datos o el estado del objeto para que "nazca" listo para usarse.
      - **Reglas clave:** Tienen exactamente el mismo nombre que la clase a la que pertenecen y **no tienen tipo de retorno** (ni siquiera `void`).

    - Sí, totalmente. Esto es un ejemplo directo de la **sobrecarga** (_overloading_) que acabamos de ver. Puedes tener un constructor sin parámetros (constructor por defecto) para crear un objeto vacío, y otros con diferentes tipos o cantidades de parámetros para inicializarlo con datos específicos desde el principio.

15. **¿Qué es `this` y `base` en C#?**
    - **`this` (La instancia actual)**
      - Hace referencia al objeto actual en el que se está ejecutando el código.
      - **Cuándo usarlo:** Principalmente para diferenciar los campos a nivel de clase de los parámetros de un método cuando comparten el mismo nombre (ej. `this.id = id;`). También se usa para pasar el objeto actual como parámetro a otro método, o para llamar a otros constructores dentro de la misma clase.

    - **`base` (La clase padre)**
      - Hace referencia a la clase base (el padre) de la cual hereda tu clase actual.
      - **Cuándo usarlo:** Para acceder a métodos o propiedades de la clase padre que tu clase hija haya sobrescrito (ej. `base.Guardar()`), o para invocar explícitamente a un constructor específico de la clase padre al momento de instanciar la clase hija.

### Colecciones y LINQ Básico

16. **¿Cuál es la diferencia entre `Array`, `List<T>` y `ArrayList`?**
    - **`Array` (Arreglo)**
      - **Qué es:** Una colección de tamaño **fijo**. Una vez que lo creas, no puedes agregar ni quitar espacios.
      - **Características:** Es fuertemente tipado (solo acepta el tipo de dato con el que se declaró). Al tener un tamaño inamovible, es la opción más rápida y eficiente en memoria.

    - **`List<T>` (Lista Genérica)**
      - **Qué es:** Una colección de tamaño **dinámico**. Crece automáticamente conforme le agregas elementos.
      - **Características:** Es fuertemente tipada gracias a los genéricos (`<T>`). Internamente está respaldada por un `Array` que se redimensiona solo cuando se llena. Es el estándar moderno en .NET y la opción que usarás el 99% del tiempo.

    - **`ArrayList` (Tecnología Legacy)**
      - **Qué es:** El antecesor de `List<T>`, utilizado en la versión 1.0 de .NET antes de que existieran los genéricos.
      - **Características:** Tiene tamaño dinámico, pero **no es tipado**. Guarda cualquier cosa como tipo `object`. Esto obliga al sistema a hacer conversiones constantes de tipos (_Boxing_ y _Unboxing_), lo que destruye el rendimiento y es propenso a errores. **No debe usarse en código nuevo.**

17. **¿Qué es un `Dictionary<TKey, TValue>` y cuándo lo usarías?**
    - **¿Qué es?**
      - Es una colección que almacena datos en pares de **Clave-Valor**. En lugar de acceder a un elemento por su posición (índice 0, 1, 2...), accedes a él mediante una clave única que tú defines.

    - **Características clave:**
      - **Búsqueda instantánea:** Utiliza una estructura de tabla hash, lo que permite encontrar valores de forma extremadamente rápida ($O(1)$ en promedio), sin importar si el diccionario tiene 10 o 1,000,000 de elementos.
      - **Claves únicas:** No permite claves duplicadas ni claves nulas (`null`). Si intentas agregar una clave que ya existe, lanzará una excepción (o sobrescribirá el valor si usas la sintaxis de corchetes).
      - **Fuertemente tipado:** Gracias a los genéricos (`<TKey, TValue>`), defines el tipo de dato tanto para la clave como para el valor desde el inicio.

    - **¿Cuándo usarlo?**
      - Cuando necesites **buscar datos frecuentemente** mediante un identificador único (ej. buscar un `Usuario` por su `ID`).
      - Para crear mapas o traducciones (ej. un diccionario de códigos de error y sus mensajes descriptivos).
      - Cuando el rendimiento de búsqueda es crítico y quieres evitar recorrer listas enteras con un bucle.

18. **Explica qué es LINQ y da un ejemplo básico de uso.**
    - **¿Qué es LINQ (Language Integrated Query)?**
      - Es una funcionalidad de C# que permite realizar consultas a diferentes fuentes de datos (listas en memoria, bases de datos SQL, archivos XML) utilizando una sintaxis estandarizada y legible directamente en el lenguaje de programación. Básicamente, te permite filtrar, ordenar y transformar datos como si estuvieras escribiendo SQL, pero con validación de tipos en tiempo de compilación.

    **Ejemplo básico (Filtrar números mayores a 5):**

        ```csharp
        List<int> numeros = new List<int> { 1, 2, 8, 4, 10, 6 };

        // Usando sintaxis de métodos (la más común)
        var mayoresQueCinco = numeros.Where(n => n > 5).OrderBy(n => n).ToList();

        // Resultado: [6, 8, 10]

        ```

19. **¿Cuál es la diferencia entre `IEnumerable` e `IQueryable`?**
    - **IEnumerable**
      - **Dónde ocurre:** Se utiliza para colecciones **en memoria** (listas, arreglos).
      - **Ejecución:** El filtrado se realiza en el **lado del cliente** (tu aplicación). Si lo usas para consultar una base de datos, `IEnumerable` traerá todos los registros a la memoria y luego los filtrará, lo cual es ineficiente con muchos datos.
      - **Uso:** Ideal para manipular datos que ya tienes cargados en la RAM.

    - **IQueryable**
      - **Dónde ocurre:** Se utiliza para proveedores de datos **fuera de la memoria** (como bases de datos con Entity Framework).
      - **Ejecución:** El filtrado se realiza en el **lado del servidor**. Traduce tu consulta LINQ a lenguaje SQL y solo descarga los resultados que cumplen con la condición.
      - **Uso:** Fundamental para realizar consultas eficientes a bases de datos, ya que minimiza el tráfico de red y el uso de memoria.

20. **¿Qué hace el método `.ToList()` en LINQ?**

    **¿Qué hace el método `.ToList()`?**
    Es el comando que fuerza la **ejecución inmediata** de una consulta LINQ.

    Por defecto, LINQ utiliza algo llamado _Deferred Execution_ (ejecución diferida); esto significa que la consulta es solo una "receta" o una definición que no se ejecuta hasta que realmente necesitas los datos. Al llamar a `.ToList()`, le ordenas a .NET que:
    1. **Ejecute la consulta** en ese preciso momento (ya sea en la memoria o enviando el SQL a la base de datos).
    2. **Itere** por todos los resultados obtenidos.
    3. **Almacene** esos resultados en un nuevo objeto de tipo `List<T>` dentro de la memoria RAM.

    **¿Cuándo es importante usarlo?**
    - **Para "congelar" resultados:** Si la fuente de datos original puede cambiar, `.ToList()` crea una copia estática en ese instante.
    - **Para evitar múltiples consultas:** Si vas a recorrer los mismos datos varias veces, es mejor guardarlos en una lista en lugar de volver a ejecutar la lógica de filtrado de LINQ cada vez.
    - **Para desconectarte de la BD:** En Entity Framework, se usa para traer los datos a la memoria y cerrar la conexión con el servidor.

    **Advertencia:** Ten cuidado al usarlo con millones de registros, ya que cargarás toda esa información en la memoria RAM de golpe.

### ASP.NET Básico

21. **¿Qué es ASP.NET MVC? Explica el patrón MVC.**
    **¿Qué es ASP.NET MVC?**
    Es un marco de trabajo (_framework_) de Microsoft para construir aplicaciones web robustas y escalables. Se basa en el patrón de diseño arquitectónico **Model-View-Controller**, el cual separa la aplicación en tres componentes principales para facilitar el mantenimiento y las pruebas.

    **El Patrón MVC:**
    - **Modelo (Model):** Representa los **datos** y la lógica de negocio. Es el encargado de interactuar con la base de datos y validar las reglas de la aplicación (ej. una clase `Producto`).
    - **Vista (View):** Es la **interfaz de usuario**. Se encarga de mostrar los datos al usuario final (usualmente usando archivos `.cshtml` con el motor Razor). No contiene lógica compleja.
    - **Controlador (Controller):** Es el **cerebro o intermediario**. Recibe las peticiones del navegador, procesa la lógica necesaria (usando el Modelo) y decide qué Vista debe mostrarse como respuesta.

    **Flujo básico:**
    El usuario hace una petición → El **Controlador** la recibe → El **Controlador** pide datos al **Modelo** → El **Modelo** responde → El **Controlador** le pasa esos datos a la **Vista** → La **Vista** se renderiza en el navegador.

22. **¿Cuál es la diferencia entre `ViewBag`, `ViewData` y `TempData`?**
    - **`ViewData`:** Es un diccionario de objetos (`ViewDataDictionary`) que utiliza claves de texto. **Requiere conversión de tipos (casting)** para recuperar los datos y solo vive durante la petición HTTP actual.
    - **`ViewBag`:** Es un objeto **dinámico** (`dynamic`) que funciona como un envoltorio sobre `ViewData`. Permite asignar propiedades sobre la marcha sin necesidad de casting, pero no ofrece validación en tiempo de compilación. Al igual que `ViewData`, solo vive en la petición actual.
    - **`TempData`:** Es un diccionario que almacena datos internamente en la **sesión**. Su característica única es que **persiste durante una redirección** (de una acción a otra). Una vez que los datos son leídos, se marcan para ser eliminados.

    ### Comparativa Rápida

    | Característica   | `ViewData`                | `ViewBag`              | `TempData`              |
    | ---------------- | ------------------------- | ---------------------- | ----------------------- |
    | **Tipo**         | Diccionario (`Key/Value`) | Objeto Dinámico        | Diccionario             |
    | **Casting**      | Requerido                 | No requerido           | Requerido               |
    | **Persistencia** | Petición actual           | Petición actual        | **Entre redirecciones** |
    | **Uso común**    | De Controlador a Vista    | De Controlador a Vista | Mensajes de éxito/error |

23. **¿Qué es un Action Result en ASP.NET MVC?**
    Es el objeto que devuelve un método de acción en un controlador. Representa la **orden final** que el controlador le da al framework sobre qué respuesta enviar al navegador.

    ### Puntos clave:
    - **Es una clase abstracta:** `ActionResult` es la base. De ella heredan muchos tipos específicos dependiendo de lo que necesites devolver (HTML, texto, un archivo, etc.).
    - **Flexibilidad:** Permite que una misma función decida, según la lógica, si mostrar una página de éxito o redirigir a un error.

    ### Los tipos más comunes:

    | Método en Controlador        | Tipo de Retorno        | Qué hace                                           |
    | ---------------------------- | ---------------------- | -------------------------------------------------- |
    | `return View();`             | **ViewResult**         | Renderiza una página HTML (la opción por defecto). |
    | `return Json(data);`         | **JsonResult**         | Devuelve datos en formato JSON para APIs o AJAX.   |
    | `return RedirectToAction();` | **RedirectResult**     | Envía al usuario a otra URL o método.              |
    | `return File(bytes, ...);`   | **FileResult**         | Inicia la descarga de un archivo.                  |
    | `return NotFound();`         | **HttpNotFoundResult** | Devuelve un error 404 estándar.                    |

    > **Dato Pro:** En versiones modernas (.NET Core/5+), se prefiere usar la interfaz **`IActionResult`**, ya que ofrece más flexibilidad para pruebas unitarias y permite devolver códigos de estado HTTP de forma más limpia.

24. **¿Qué son las Razor Pages?**

    Es un modelo de programación **basado en páginas** para construir interfaces web en ASP.NET Core. A diferencia del MVC tradicional, donde la lógica se divide en carpetas de Controladores, Modelos y Vistas, Razor Pages agrupa todo lo relacionado con una página específica en un solo lugar.

    ### Características principales:
    - **Estructura de archivos:** Cada página consta de dos archivos:
    1. `Archivo.cshtml`: El marcado HTML con sintaxis Razor (la vista).
    2. `Archivo.cshtml.cs`: El **PageModel**, que contiene la lógica de C# y los manejadores de eventos (el "code-behind").
    - **Enrutamiento automático:** No necesitas configurar rutas manualmente; la URL de la página se basa automáticamente en su ubicación en la carpeta `/Pages`.
    - **Manejadores (Handlers):** En lugar de métodos de acción en un controlador, utiliza métodos como `OnGet()`, `OnPost()`, `OnPostDelete()`, etc., vinculados directamente a los verbos HTTP.

    ### ¿Cuándo usar Razor Pages vs. MVC?

    | Característica   | Razor Pages                                            | ASP.NET MVC                                          |
    | ---------------- | ------------------------------------------------------ | ---------------------------------------------------- |
    | **Enfoque**      | Centrado en la **Página**.                             | Centrado en la **Acción**.                           |
    | **Complejidad**  | Ideal para aplicaciones web simples o medianas (CRUD). | Ideal para sistemas grandes con lógica muy compleja. |
    | **Organización** | Todo lo de una vista está "junto".                     | La lógica está separada de la vista por carpetas.    |

    > **Dato Pro:** Razor Pages es el modelo recomendado por Microsoft para la mayoría de las aplicaciones web modernas que renderizan HTML en el servidor, ya que reduce mucho el código repetitivo (_boilerplate_).

25. **Explica el ciclo de vida de una petición HTTP en ASP.NET.**
    El ciclo de vida de una petición en ASP.NET Core (versiones modernas) se basa en un concepto de **"Pipeline de Middleware"**. Es como una línea de ensamblaje donde la petición entra, pasa por varias estaciones, llega al controlador y regresa por el mismo camino.

    ### Los pasos principales:
    1. **Middleware (Paso de entrada):** La petición pasa por una serie de componentes (como Autenticación, CORS, Enrutamiento). Cada uno puede procesar la petición o detenerla si algo está mal (ej. falta de permisos).
    2. **Routing (Enrutamiento):** El sistema analiza la URL y decide a qué **Controlador** y **Acción** debe enviar la petición.
    3. **Filtros (Filters):** Antes de ejecutar el código del controlador, la petición pasa por filtros (de Autorización, de Recursos, de Acción). Es la última capa de seguridad y validación.
    4. **Ejecución de la Acción:** Se ejecuta el código C# que escribiste en tu controlador o página. Aquí es donde hablas con la base de datos o procesas lógica.
    5. **Result Execution:** El resultado (HTML, JSON, etc.) se prepara para ser enviado.
    6. **Middleware (Paso de salida):** La respuesta vuelve a pasar por los mismos middlewares en orden inverso (útil para añadir cabeceras de respuesta o hacer logging) antes de salir al navegador del usuario.

    > **Dato Clave:** A diferencia del antiguo ASP.NET Framework, en el moderno .NET el pipeline es **totalmente modular**; solo incluyes y ejecutas lo que realmente necesitas, lo que lo hace extremadamente rápido.
