namespace ProyectoInventarioReportes.Services.IServices
{
    public interface IEmailService
    {
        Task EnviarCorreoIngresoStock(string producto, int unidades);
        Task EnviarCorreoSalidaStock(string producto, int unidades);
    }
}
