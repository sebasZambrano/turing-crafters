namespace Entity.Dtos.Security
{
    public class MenuDto: BaseDto
    {
        public int ModuloId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Icono { get; set; } = null!;
        public IEnumerable<FormularioDto> Formularios { get; set; } = Enumerable.Empty<FormularioDto>();
        public IEnumerable<MenuDto> Modulos { get; set; } = Enumerable.Empty<MenuDto>();
    }
}
