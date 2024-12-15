namespace Entity.Dtos.Security
{
    public class FormularioRolDto : BaseDto
    {
        public int FormularioId { get; set; }
        public string? Formulario { get; set; }
        public int RolId { get; set; }
        public string? Rol { get; set; }
    }
}
