# EventLogs Web Application

Este proyecto es una aplicación web de gestión de eventos "Logs" desarrollada con Angular y .NET Core. Permite a los usuarios registrar eventos en la base de datos y consultar la información de eventos registrados.

## Requisitos Previos

Antes de comenzar, asegúrate de tener instalados los siguientes requisitos:

- [Node.js](https://nodejs.org/) (versión 14 o superior)
- [Angular CLI](https://cli.angular.io/) (versión 12 o superior)
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

## Instalación

Sigue estos pasos para instalar y configurar el proyecto:

1. Clona este repositorio:

   ```bash
   git clone https://github.com/guillermo2018/FinaktivaLogs.git

1. Navega al directorio del proyecto: cd eventlogs-web-app

2. Configura la API en el lado del servidor:

2.1 Configuración de base de datos y tablas necesarias 
Creación de base de datos(opcional) :  CREATE DATABASE FinaktivaLogs;
Creación de tablas necesarias:
  
CREATE TABLE EventLogs (
    EventID INT PRIMARY KEY IDENTITY,
    EventType VARCHAR(50) NOT NULL,
    EventDescription TEXT,
    CreatedAt DATETIME NOT NULL
);

2.2 Modificar el archivo "appsettings.json" que se encuentra el la ruta "Finaktiva\endpoint\EventLogsApi" con su cadena de conexión.

Abre la solución en Visual Studio o Visual Studio Code.
Asegúrate de que el proyecto de API esté configurado como el proyecto de inicio.
Ejecuta la aplicación para iniciar la API en https://localhost:7251.

3. Configura la aplicación Angular:

Abre una terminal en la carpeta ClientApp dentro del proyecto.

Instala las dependencias del cliente: npm install

4. Inicia la aplicación Angular: ng serve
   Para esto debe estar ubicado en la ruta Frontend (Angular)\EventLogsApp
La aplicación estará disponible en http://localhost:4200.


Uso
Accede a la aplicación en http://localhost:4200/registro-evento.

Registra un evento:

Utiliza el formulario de registro de eventos manuales en la página principal.
Proporciona la fecha, descripción y tipo de evento.
Haz clic en "Registrar Evento".
Consulta eventos:

Ve a la página de consulta de eventos en la barra de navegación.
Utiliza los filtros por tipo de evento y rango de fechas para buscar eventos registrados.
Estructura del Proyecto
La estructura del proyecto es la siguiente:

├── ClientApp/            # Código fuente de la aplicación Angular
├── Controllers/          # Controladores de la API
├── Models/               # Modelos de datos de la API
├── ...

