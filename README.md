ProductExportApi - ASP.NET Core Web API (.NET 9)

Bienvenido al proyecto ProductExportApi, una API REST profesional creada en ASP.NET Core Web API (.NET 9.0), diseñada para gestionar productos de manera eficiente y 
exportar su información a documentos Word personalizados.

Este sistema está pensado para facilitar el registro, edición, consulta, eliminación y exportación de información de productos, simulando un escenario real de gestión de 
inventarios o catálogos empresariales.


Tecnologías Utilizadas

- C# : https://learn.microsoft.com/en-us/dotnet/csharp/
- .NET 9.0 : https://dotnet.microsoft.com/es-es/download/dotnet/9.0
- ASP.NET Core Web API : https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-9.0
- Swagger / OpenAPI : https://swagger.io/specification/
- OpenXML SDK : https://learn.microsoft.com/en-us/office/open-xml/open-xml-sdk
- JSON : https://www.json.org/json-en.html


Estructura del Proyecto

El proyecto está organizado siguiendo principios de arquitectura limpia:

| Carpeta         | Propósito                                                    |
|-----------------|--------------------------------------------------------------|
| Controllers/    | Reciben solicitudes HTTP y gestionan las rutas de la API     |
| Models/         | Definen las estructuras de datos (clases) usadas en la API   |
| Repositories/   | Gestionan la persistencia de datos en archivos JSON          |
| Services/       | Contienen la lógica de negocio que coordina acciones         |
| Helpers/        | Utilidades para leer JSON y generar documentos Word          |
| Data/           | Contiene archivos estáticos: productos y plantillas de Word  |


Descripción de cada Carpeta

1. Controllers
- ProductsController.cs: Gestiona las operaciones CRUD de productos.
- ExportController.cs: Permite exportar la información de un producto a un documento Word.

2. Models
- Product.cs: Define un producto con sus propiedades principales: ID, Nombre, Descripción, Precio y Stock.

3. Repositories
- ProductRepository.cs: Maneja las operaciones de lectura y escritura en el archivo productos.json.

4. Services
- ProductService.cs: Procesa la lógica de negocio al agregar, editar o eliminar productos.
- ExportService.cs: Genera el documento Word dinámico basado en los datos del producto.

5. Helpers
- JsonHelper.cs: Lee y guarda datos en archivos JSON.
- WordHelper.cs: Modifica documentos Word reemplazando placeholders por datos reales.

6. Data
- productos.json: Almacena los productos de forma persistente.
- plantilla.docx: Plantilla Word con marcadores {{Nombre}}, {{Descripcion}}, {{Precio}} y {{Stock}}.


Funcionalidades Principales (Operaciones REST)

1. Crear un nuevo producto (POST)
- Ruta: /api/products
- Envía un JSON con los datos del nuevo producto.

2. Obtener productos (GET)
- Ruta: /api/products
- Obtiene todos los productos registrados.

- Ruta por ID: /api/products/{id}
- Obtiene un producto específico mediante su identificador.

3. Editar un producto (PUT)
- Ruta: /api/products/{id}
- Actualiza la información de un producto existente.

4. Eliminar un producto (DELETE)
- Ruta: /api/products/{id}
- Elimina un producto específico del sistema.

5. Exportar un producto a Word (POST)
- Ruta: /api/export/{id}
- Genera un archivo Word con los datos del producto seleccionado.


![image](https://github.com/user-attachments/assets/4c3ec286-308c-48c8-abab-e52d4cbcc812)



Flujo de Datos Interno

1. Cliente envía solicitud HTTP a través de Swagger o Postman.
2. Controller procesa la solicitud y llama al Service.
3. Service aplica validaciones y llama al Repository.
4. Repository accede al archivo JSON para guardar o leer datos.
5. En exportaciones, el ExportService usa el WordHelper para crear el documento.


Guía de Ejecución Local

1. Clonar o descargar este repositorio.
2. Abrir en Visual Studio 2022.
3. Asegurarse de tener instalado el SDK de .NET 9 (https://dotnet.microsoft.com/es-es/download/dotnet/9.0).
4. Presionar F5 o Ctrl + F5 para ejecutar.
5. Swagger se abrirá automáticamente en:


https://localhost:7057/swagger


6. Desde Swagger puedes probar todos los endpoints de la API.


Recursos de Documentación

- Documentación oficial de ASP.NET Core Web API: https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-9.0
- Guía de OpenAPI/Swagger : https://swagger.io/docs/specification/about/
- Uso de OpenXML SDK para trabajar con documentos Word : https://learn.microsoft.com/en-us/office/open-xml/open-xml-sdk
- JSON (JavaScript Object Notation) : https://www.json.org/json-en.html
- Buenas prácticas de desarrollo de APIs REST : https://restfulapi.net/


Autor

Hector Gianmarco Arrasco Juarez  
Estudiante de Ingeniería de Sistemas, Universidad de Lima.
hector28122003@gmail.com


Actualizado

- Abril 2025
- Basado en .NET 9.0 
