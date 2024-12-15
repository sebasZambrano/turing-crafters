using Entity.Models.Parameter;

namespace Entity.Models.Security
{
    public class Persona : BaseModel
    {
        public string TipoDocumento { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public string PrimerNombre { get; set; } = null!;
        public string SegundoNombre { get; set; } = null!;
        public string PrimerApellido { get; set; } = null!;
        public string SegundoApellido { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int? Genero { get; set; }
        public int? CiudadId { get; set; }
        public Ciudad Ciudad { get; set; } = new Ciudad();
    }
}
