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

Endpoint	Método	Descripción	Cuerpo de la Solicitud	Respuestas	Ejemplo de Uso (cURL)
/MovimientoInventario/Entrada	POST	Ingresa unidades de un producto al inventario y envía una notificación por correo.	```json {"producto":"string","unidades":integer,"movimiento":"EntradaStock","venta":"Online	Sucursal","fechaMovimiento":"date-time"}``` - producto: Nombre del producto (requerido, no vacío) - unidades: Cantidad a ingresar (requerido, >0) - movimiento: "EntradaStock" (requerido) - venta: "Online" o "Sucursal" (opcional) - fechaMovimiento: Fecha en ISO 8601, ej. "2025-10-01T10:00:00Z" (opcional)	- 200 OK: { "mensaje": "Ingreso correctamente. Email enviado." } - 400 Bad Request: { "error": "Mensaje de error" } (ej. datos inválidos)
/MovimientoInventario/Salidas	POST	Registra la salida de unidades de un producto, valida existencias y envía una notificación por correo.	```json {"producto":"string","unidades":integer,"movimiento":"Venta","venta":"Online	Sucursal","fechaMovimiento":"date-time"}``` - producto: Nombre del producto (requerido, no vacío) - unidades: Cantidad a retirar (requerido, >0) - movimiento: "Venta" (requerido) - venta: "Online" o "Sucursal" (opcional) - fechaMovimiento: Fecha en ISO 8601 (opcional)	- 200 OK: { "mensaje": "Salida exitosa. Email enviado." } - 400 Bad Request: { "error": "Mensaje de error" } (ej. stock insuficiente)
/Stocks	GET	Obtiene el estado actual del inventario (todos los productos y sus cantidades).	Ninguno	- 200 OK: [{"producto":"Laptop","unidades":100}, ...]	bash curl -X GET "http://localhost:5000/Stocks"
/MovimientosPorProducto	POST	Filtra movimientos de inventario por producto, mes y/o año.	json {"nombreProducto":"string","mes":integer,"anio":integer} - nombreProducto: Nombre del producto (opcional) - mes: Mes (1-12, opcional) - anio: Año, ej. 2025 (opcional)	- 200 OK: [{"producto":"Laptop","unidades":10,"movimiento":"EntradaStock", ...}, ...]	bash curl -X POST "http://localhost:5000/MovimientosPorProducto" -H "Content-Type: application/json" -d '{"nombreProducto":"Laptop","mes":10,"anio":2025}'
/ProductosMasVendidos	GET	Devuelve una lista de los productos más vendidos.	Ninguno	- 200 OK: [{"producto":"Laptop","ventas":50}, ...]	bash curl -X GET "http://localhost:5000/ProductosMasVendidos"
/VentasPorCanal	GET	Devuelve un reporte de ventas por canal (Online o Sucursal).	Ninguno
