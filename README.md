# README

## Descripción del Proyecto

Este proyecto es una API para la gestión de usuarios, desarrollada utilizando ASP.NET Core. La API proporciona un endpoint para obtener una lista de usuarios predefinidos. Cada usuario tiene un ID, nombre y correo electrónico.

## Estructura del Proyecto

1. **Controllers**: Contiene la lógica de la API, específicamente el controlador de usuarios e incluye pruebas unitarias para asegurar el correcto funcionamiento de la API(`UsersController`)(`UsersControllerTest`).
2. **Models**: Define el modelo de usuario (`User`).
3. **Program.cs**: Configura los servicios y middleware de la aplicación.

## Configuración del Proyecto

### Requisitos Previos

- .NET SDK (versión 6.0 o superior)
- Un editor de código (recomendado: Visual Studio, Visual Studio Code)

### Pasos para la Configuración

1. **Clona el Repositorio**:
   ```bash
   git clone https://github.com/holas1356/Test1-xUnit.git
   cd test1-xUnit
   ```
2. **Restaurar Dependencias**:
     ```bash
   dotnet restore
   ```
3. **Ejecutar la Aplicación**:
     ```bash
   dotnet run
   ```
4. **Probar la API**: Accede a https://localhost:5153/api/users para obtener la lista de usuarios.

## Pruebas Unitarias

Las pruebas unitarias son una parte crucial del desarrollo de software, ya que garantizan que cada componente funcione como se espera. En este proyecto, se utilizan pruebas unitarias para verificar el correcto funcionamiento del UsersController.
    
## Configuración de las Pruebas

1. **Ejecutar las Pruebas**:Asegúrate de que las pruebas están configuradas en un proyecto separado. Desde el directorio del proyecto de pruebas, ejecuta:
   ```bash
   dotnet test
   ``` 

## Detalle de las Pruebas Unitarias

El archivo UsersControllerTests.cs contiene varias pruebas para el controlador de usuarios:

1. GetUsers_ReturnsOkResult:

    Verifica que el método GetUsers() devuelva un resultado exitoso (200 OK).

2. GetUsers_ReturnsOkResult_WithListOfUsers:

    Asegura que el resultado no solo sea exitoso, sino que también contenga una lista de usuarios. Se espera que el tamaño de la lista sea 10.

3. GetUsers_ReturnsAllUsers:

    Confirma que cada usuario en la lista devuelta tenga un nombre y un correo electrónico no nulos.

4. GetUsers_ContainsExpectedUsers:

    Verifica que la lista devuelta contenga los usuarios esperados, comparando los nombres de los usuarios con una lista predefinida.

## Ejemplo de Ejecución de Pruebas

Para ejecutar las pruebas unitarias y verificar su correcta implementación, puedes utilizar el siguiente comando en la terminal:
   ```bash
   dotnet test
   ``` 