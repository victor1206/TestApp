namespace TestApp.DTO.ProyectoDTO
{
    public class ProyectoGuardarDTO
    {
        public string titulo { get; set; } = null!;
        public string descripcion { get; set; } = null!;
        public DateTime fechaInicio { get; set; } = DateTime.Today;
        public DateTime fechaFin { get; set; } = DateTime.Today;
        public int categoriaId { get; set; }
    }
}
