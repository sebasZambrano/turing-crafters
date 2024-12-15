namespace Entity.Dtos.Parameter
{
    public class EmpresaDto : BaseDto
    {
        public string? RazonSocial { get; set; }
        public string? Nit { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Web { get; set; }
        public int? ArchivoId { get; set; }
        public string? Logo { get; set; }
        public int CiudadId { get; set; }
        public string? Ciudad { get; set; }
    }
}
