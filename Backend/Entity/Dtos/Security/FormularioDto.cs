namespace Entity.Dtos.Security
{
    public class FormularioDto: GenericDto
    {
        public string Url { get; set; } = null!;
        public string Icono { get; set; } = null!;
        public int ModuloId { get; set; }
        public bool SuperAdmin { get; set; }
        public string? Modulo { get; set; }
    }
}
