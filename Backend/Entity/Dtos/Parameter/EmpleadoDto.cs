namespace Entity.Dtos.Parameter
{
    public class EmpleadoDto : BaseDto
    {
        public string Codigo { get; set; } = null!;
        public int PersonaId { get; set; }
        public string? Persona { get; set; }
        public int CargoId { get; set; }
        public string? Cargo { get; set; }
        public int EmpresaId { get; set; }
        public string? Empresa { get; set; }
        public int CajaId { get; set; }
        public string? Caja { get; set; }
    }
}
