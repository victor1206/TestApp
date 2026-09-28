using TestApp.DTO.CategoriaDTO;

namespace TestApp.DTO.ProyectoDTO
{
    public class ProyectoSalidaDTO
    {
        public int id { get; set; }
        public string titulo { get; set; } = null!;
        public string descripcion { get; set; } = null!;
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public CategoriaSalidaDTO categoria { get; set; } = null!;
    }
}
