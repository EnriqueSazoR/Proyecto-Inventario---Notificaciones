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

## Documentación de la API

Endpoint
Método
Descripción
Ejemplo de Request


/MovimientoInventario/Entrada
POST
Ingresa unidades de un producto al inventario (envía email de notificación)
{"producto": "Laptop", "unidades": 10, "movimiento": "EntradaStock", "venta": "Online", "fechaMovimiento": "2025-10-01T10:00:00Z"}


/MovimientoInventario/Salidas
POST
Registra salida de unidades de un producto con validación (envía email)
{"producto": "Laptop", "unidades": 5, "movimiento": "Venta", "venta": "Sucursal", "fechaMovimiento": "2025-10-01T10:00:00Z"}


/Stocks
GET
Obtiene el estado actual del inventario
Ninguno


/MovimientosPorProducto
POST
Filtra movimientos de inventario por producto, mes y/o año
{"nombreProducto": "Laptop", "mes": 10, "anio": 2025}


/ProductosMasVendidos
GET
Devuelve los productos más vendidos
Ninguno


/VentasPorCanal
GET
Devuelve un reporte de ventas por canal (Online o Sucursal)
Ninguno




