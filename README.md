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
  - Lista de productos dependiendo su stock
  - Movimientos de productos (entrada o salida) en un mes y año en concreto.  
  - Productos más vendidos, sumando el total de ventas y contando cuantas veces fue vendido en sucursal u online.  
  - Cuantas ventas se han registrado en total en sucursales y online según un mes y año.  

- **Notificaciones**  
  - Envío de alertas por correo cuando se produzca una entrada o salida.
 
- **PDF**  
  - Cada reporte contará con su respectivo PDF.  

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
- Finalizado

---

## Documentación API
Para explorar y probar los endpoints de la API, usa el Swagger UI interactivo a continuación. Puedes expandir cada endpoint para ver detalles como parámetros, cuerpos de request (ej. IngresoStockDTO), respuestas esperadas y ejemplos de uso.

# Documentación de la API

Para explorar y probar los endpoints de la API, usa el Swagger UI interactivo a continuación. Puedes expandir cada endpoint para ver detalles como parámetros, cuerpos de request (ej. IngresoStockDTO), respuestas esperadas y ejemplos de uso.

<iframe src="https://petstore.swagger.io/?url=https://raw.githubusercontent.com/EnriqueSazoR/Proyecto-Inventario---Notificaciones/main/ProyectoInventarioReportes/Docs/Swagger/swagger.json" width="100%" height="800px" frameborder="0"></iframe>
