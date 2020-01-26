# shopping.app.api
Una API para una app de  compras, especificamente la numero 10 de las app que mostraba el link que se  me envio en el PDF para las preguntas y demas.

# Requerimientos de software y framework DLL para mantener y/o compilar la app

Para el proyecto web como tal se necesitan algunos nugets para la pre-configuracion tanto del startup.cs como de los controladores y los servicios que se inyectan. Son los siguientes:

# Frameworks
Con el SDK de net core sera mas que suficiente respecto a lo que framework se refiere.

AipCore => ApiCore.csproj(Archivo con todas las dependencias y especificaciones de framework)

Nugets:
# Automapper 8.1.1
# AutoMapper.Extensions.Microsoft.DependencyInjection3
Estas dos son necesarias para el mapeo de entidad a DTO. Se usan en el proyecto web para la inclusion de servicios de AutoMapper.

# Microsoft.AspNetCore.Authentication.JwtBearer 3.1.1
Aunque su mayor uso es en la DLL, es necesaria su instalacion en el proyecto web para la inclusion de servicios en el startup.cs

# Microsoft.EntityFrameworkCore.InMemory 3.1.1
Este nuget es usado para maneh=jo de datos en memoria, de esa manera las pruebas unitarias, las cargas de uso, etc... se pueden testear sin la necesidad de un motor de base de datos.

# Microsoft.Extensions.Logging.Debug 3.1.0
Es para llevar contancia de los errores y/o mostrarlos por consola en tiempo de ejecucion.

# Microsoft.VisualStudio.Web.CodeGeneration.Design 3.1.0
Es de mucha ayuda ala hora de crear plantillas, obviamente son plantillas basicas incluso de tipo Sync.

# Swashbuckle.AspNetCore 5.0.0-rc4
# Swashbuckle.AspNetCore.Swagger 5.0.0
Como parte del paquete de swagger, este nos ayuda a la inclusion de los servicios y de su configuracion por parte del configure.
En ese mismo orden en el ApiCore.csproj casi al final hay unas lineas de codigo que sirven para configurar mas profesionalmente swagger, las lienas de codigo son estas:

  <PropertyGroup>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
    <NoWarn>$(NoWarn);1591</NoWarn>
  </PropertyGroup>

# DomainCore DLL Encargada de los procesos y manejo de mapeadores, entidades, dto, repositorios, interfaces y demas.

Algunos de los nugets que son requeridos por esta DLL son:

# AutoMapper 8.1.1
Ene ste caso solo usaremos AutoMapper com otal, ya que solo lo necesitamos para crear los mappers y mapear las respectivas entidades con los DTO.

# Microsoft.AspNetCore.Identity 2.2.0
El nuget creado por Microsoft para el manejo de usuarios, roles y demas.
Se usa la version 2.2.0 porque hasta el momento no han hecho actualizaciones. Pero aun funciona de maravilla.

# Microsoft.AspNetCore.Identity.EntityFrameworkCore 2.2.0
Para vincularIdentity con Base de Datos no es solo hacer un DbSet y ya, sino que debemos heredar algunos metodos, este nuget nos ayuda con eso.

# Microsoft.EntityFrameworkCore 2.2.4
# Microsoft.EntityFrameworkCore.SqlServer 2.2.4
ORM para el manejo de datos desde codigo, se usa tanto apra CodeFirst como para DataBaseFirst, de la mano de LinQ, es un ORM maduro y con mucho poder.

# Microsoft.IdentityModel.Tokens 5.5.0
# System.IdentityModel.Tokens.Jwt 5.5.0
Ambos son para el manejo de JWT en la aplicacion, validadciones, accesos y demas.

# Correr en modo Debug
Al ejecutar el comando dotnet run el modo debug esta activado por defecto, asi que con solo ese comando se ejecutara de esa manera.

# Correr en modo Release
Se utiliza el mismo comando solo que se le agrega una secuencia extra => dotnet run -c Release

# Lista de librerias y dependencias

1. AutoMapper, AutoMapper.Extensions.Microsoft.DependecyInjection
Pagina oficial: https://automapper.org/
Documentacion: https://automapper.readthedocs.io/en/latest/

2. Microsoft.AspNetCore.Authentication.JwtBearer, Microsoft.EntityFrameworkCore.InMemory, Microsoft.Extensions.Logging.Debug
Pagina oficial: https://dotnet.microsoft.com/apps/aspnet
Documentacion: https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.authentication.jwtbearer?view=aspnetcore-2.2&viewFallbackFrom=aspnetcore-3.1

3. Swashbuckle.AspNetCore.Swagger
URL del proyecto: https://github.com/domaindrivendev/Swashbuckle.AspNetCore
Documentacion: https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio

4. Microsoft.AspNetCore.Identity, Microsoft.AspNetCore.Identity.EntityFrameworkCore, Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.SqlServer
Pagina principal: https://dotnet.microsoft.com/apps/aspnet
Documentacion: https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity?view=aspnetcore-3.1

5. Microsoft.IdentityModel.Tokens, System.IdentityModel.Tokens.Jwt
URL del proyecto: https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet
Documentacion: https://docs.microsoft.com/en-us/dotnet/api/microsoft.identitymodel.tokens?view=azure-dotnet
