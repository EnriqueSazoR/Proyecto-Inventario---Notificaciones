using ProyectoInventarioReportes.DTO;
using ProyectoInventarioReportes.Services.IServices;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace ProyectoInventarioReportes.Services
{
    public class PdfService : IPdfService
    {
        public byte[] GenerarMovimientosProductosPDF(List<MovimientoDTO> movimientos)
        {
            var pdfBytes = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);
                    page.Size(PageSizes.A4);

                    page.Header()
                        .Text("Reporte: Movimientos De Productos")
                        .SemiBold().FontSize(20).AlignCenter();


                    page.Content()
                        .Table(tabla =>
                        {
                            tabla.ColumnsDefinition(columnas =>
                            {
                                columnas.RelativeColumn(4); // Tipo Movimiento
                                columnas.RelativeColumn(4); // Tipo Venta
                                columnas.RelativeColumn(4); // Unidades
                            });

                            tabla.Header(encabezados =>
                            {
                                encabezados.Cell().Text("Tipo De Movimiento").SemiBold();
                                encabezados.Cell().Text("Tipo De Venta");
                                encabezados.Cell().Text("Unidades");
                            });

                            // Filas
                            foreach (var item in movimientos)
                            {
                                tabla.Cell().Text(item.TipoMovimiento);
                                tabla.Cell().Text(item.TipoVenta);
                                tabla.Cell().Text(item.Unidades.ToString());
                            }
                        });
                });
            }).GeneratePdf();

            return pdfBytes;
        }

        public byte[] GenerarProductosMasVendidosPDF(List<ProductoMasVendidoDTO> ranking)
        {
            var pdfBytes = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);
                    page.Size(PageSizes.A4);

                    page.Header()
                        .Text("Reporte: Productos Más Vendidos")
                        .SemiBold().FontSize(20).AlignCenter();


                    page.Content()
                        .Table(tabla =>
                        {
                            tabla.ColumnsDefinition(columnas =>
                            {
                                columnas.RelativeColumn(4); // Producto
                                columnas.RelativeColumn(4); // Total Unidades Vendidas
                                columnas.RelativeColumn(4); // Ventas Online
                                columnas.RelativeColumn(4); // Ventas Sucursal
                            });

                            tabla.Header(encabezados =>
                            {
                                encabezados.Cell().Text("Producto").SemiBold();
                                encabezados.Cell().Text("Unidades Vendidas").SemiBold();
                                encabezados.Cell().Text("Ventas Sucursal");
                                encabezados.Cell().Text("Ventas Online");
                            });

                            // Filas
                            foreach (var item in ranking)
                            {
                                tabla.Cell().Text(item.NombreProducto);
                                tabla.Cell().Text(item.TotalUnidadesVendidas.ToString());
                                tabla.Cell().Text(item.VentasOnline.ToString());
                                tabla.Cell().Text(item.VentasSucursal.ToString());
                            }
                        });  
                });
            }).GeneratePdf();

            return pdfBytes;
        }

        public byte[] GenerarStocksPDF(List<ProductoStockDTO> productos)
        {
            var pdfBytes = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);
                    page.Size(PageSizes.A4);


                    page.Header()
                        .Text("Reporte: Stock De Productos")
                        .SemiBold().FontSize(20).AlignCenter();

                    page.Content()
                        .Table(tabla =>
                        {
                            tabla.ColumnsDefinition(columnas =>
                            {
                                columnas.RelativeColumn(4); // Producto
                                columnas.RelativeColumn(2); // Stock
                            });

                            tabla.Header(encabezados =>
                            {
                                encabezados.Cell().Text("Producto").SemiBold();
                                encabezados.Cell().Text("Stock").SemiBold();
                            });

                            // Filas
                            foreach (var item in productos)
                            {
                                tabla.Cell().Text(item.NombreProducto);
                                tabla.Cell().Text(item.Stock.ToString());
                            }
                        });
                });
            }).GeneratePdf();

            return pdfBytes;
        }

        public byte[] GenerarVentasPorCanalPDF(List<TipoVentaDTO> tipos)
        {
            var pdfBytes = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);
                    page.Size(PageSizes.A4);

                    page.Header()
                        .Text("Reporte: Ventas Por Canal")
                        .SemiBold().FontSize(20).AlignCenter();

                    page.Content()
                        .Table(tabla =>
                        {
                            tabla.ColumnsDefinition(columnas =>
                            {
                                columnas.RelativeColumn(4); // Producto
                                columnas.RelativeColumn(2); // Ventas Online
                                columnas.RelativeColumn(2); // Ventas Sucursal
                                columnas.RelativeColumn(2); // Total
                            });

                            tabla.Header(encabezados =>
                            {
                                encabezados.Cell().Text("Producto").SemiBold();
                                encabezados.Cell().Text("Ventas Online").SemiBold();
                                encabezados.Cell().Text("Ventas Sucursal").SemiBold();
                                encabezados.Cell().Text("Total Unidades Vendidas").SemiBold();
                            });

                            // Filas
                            foreach (var item in tipos)
                            {
                                tabla.Cell().Text(item.NombreProducto);
                                tabla.Cell().Text(item.VentasOnline.ToString());
                                tabla.Cell().Text(item.VentasEnSucursal.ToString());
                                tabla.Cell().Text(item.UnidadesVendidas.ToString());
                            }
                        });
                });
            }).GeneratePdf();

            return pdfBytes;

        }
    }
}
