# API de Inventario

API de Inventario desarrollada con **ASP.NET Core Web API** y **SQL Server**, enfocada en la **gestión de inventario**, generación de **reportes** y envío de **notificaciones automáticas** cuando el stock es bajo.

---

## Tecnologías utilizadas
- **Lenguaje:** C#  
- **Framework:** ASP.NET Core 8 Web API  
- **Base de datos:** SQL Server  
- **ORM:** Entity Framework Core  
- **Documentación:** Swagger / OpenAPI  
- **Notificaciones:** Envío de correos mediante SMTP  

---

## Funcionalidades principales
- **Gestión de inventario**  
  - Registrar movimientos de productos (entradas y ventas).  
  - Actualizar stock de productos existentes.  

- **Reportes**  
  - Productos más vendidos.  
  - Productos menos vendidos.  
  - Productos con stock bajo.  
  - Movimientos recientes de inventario.  

- **Notificaciones**  
  - Envío de alertas por correo cuando el stock de un producto es inferior al mínimo configurado.  

---

##  Estructura del proyecto
- `DTO`→ Modelos expuestos
- `Controllers` → Endpoints de la API.  
- `Models` → Modelos de datos (Producto, Marca, MovimientoInventario).  
- `Data` → DbContext y configuración de acceso a datos.  
- `Services` → Lógica de negocio (reportes y notificaciones).
- `Rpository` → Patrón utilizado

---

##  Estado
- En Desarrollo
