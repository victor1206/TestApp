namespace TestApp.DTO.ProyectoDTO
{
    public class ProyectoModificarDTO
    {
        public int id { get; set; }
        public string titulo { get; set; } = null!;
        public string descripcion { get; set; } = null!;
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public int categoriaId { get; set; }
    }
}
