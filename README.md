
## Bienvenido al Repositorio Oficial del “Gestión de Estudiantes”😀📚

<center><img src="https://www.becasinternacionales.net/webapp/img/upload/49986d_consejos-para-mejorar-el-aprendizaje-de-los-estudiantes.jpg" /></center>

------------

### 📋 Introduction
Es este un proyecto de gestión en cual fue creado con una arquitectura hexagonal o clean architecture en el cual emplea múltiples arquitecturas, el mismo cuenta con una capa “common” que conlleva todas las clases que requerirán las otras capas, una capa “DataAccess” es la paca que gestiona los datos con la base de datos, la misma fue creada con ADO.Net con el modelo “DataBase first” una vez creada la cadena de conexión “connectionString” de se tiene que copiar en el archivo “Web.Config” al servicio se le debe instalar “Entity Framework”al igual que al proyecto Web.

El proyecto Web cuenta con una arquitectura MVC (Modelo Vista Controlador) ViewModel Donde se encuentran los “Dto”.

“Gestión de Estudiantes” es un sistema para realizado por estudiantes del Instituto Tecnologio Del Las Americas **(ITLA)** para la materia de Introducción a la ingeniería de software-2021.

### 🔧 Installation
Para poder correr este sistema en su maquina debera realizar los siguente:
- Debe descargar nuestra bases de datos y crearla
- En el proyecto, ir a la libreria llamada DataAcess.
- En esta libreria de ir a un archivo llamado "**Web.Config**".
- En App.Config le aparecera la cadena de conexion "**connectionStrings**" vista de esta forma:

`<connectionStrings>
    <add name="GestionDB" connectionString="metadata=res://*/DBContext.csdl|res://*/DBContext.ssdl|res://*/DBContext.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.;initial catalog=proyecting007;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  </connectionStrings>`
- En "**data source**" debera quitar el punto y poner el nombre de su conexión local.
- Una vez hecho esto solo corra el programa y le funcionará.

------------

### Collaborators
- [Karina Montero Leonardo (2018-6814) ROL -> Product Owner](https://github.com/karina0724 "Karina Montero")
- [Gilbert Samill Rivas (2019-7546) ROL -> Scrum Master](https://github.com/samill1798rd)
- [Erick Daniel Tejada Montero (2018-7199) ROL -> Developer Team](https://github.com/Daniel884936 "Daniel")
- [Christoper Severino (2018-6100) ROL -> Developer Team](https://github.com/severino1 "Christoper Severino")
- [Joel francisco frias castillo (2018-6818) ROL -> Developer Team](https://github.com/Joel1844 "Joel")
- [Juan David Matos (2018-7221) ROL -> Developer Team]( https://github.com/Juand0014 "Juan")
- [Ángel Mongrut (2018-7151) ROL -> Developer Team](https://github.com/k0o "Angel")
- [Eliot villar (2019-7619) ROL -> Developer Team](https://github.com/eliotvillarc "Eliot villar")
- [Esmerlin Borges Corporan (2018-6581) ROL -> Developer Team]( https://github.com/ViicKeTt "Esmerlin Borges Corporan")

------------


