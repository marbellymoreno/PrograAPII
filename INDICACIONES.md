Pasos para Configurar la API

Crear la Base de Datos:
  Inicie sesión en SqlServer y genere una base de datos con el nombre que usted elija.

Abrir el Proyecto en Visual Studio:
  Localice el archivo "appsettings.json" dentro del proyecto y ábralo haciendo doble clic.

Modificar la Cadena de Conexión:
  En el archivo encontrará una cadena de conexión similar a esta:
    "Server=MARBELLYMORA987\\SQLEXPRESS;Database=APIDB;Trusted_Connection=True;TrustServerCertificate=True"
  Edite los parámetros correspondientes, cambiando el nombre de la instancia y el de la base de datos, quedando de la siguiente manera:
    "Data Source=Nombre_de_su_Instancia;Initial Catalog=Nombre_de_su_Base;Integrated Security=True;Trust Server Certificate=True"

Aplicar las Migraciones:
  Por último, abra la Consola del Administrador de Paquetes en Visual Studio y ejecute las migraciones necesarias para completar la configuración.
