namespace Entity.Dtos.Parameter
{
    public class ArchivoDto : BaseDto
    {
        public string Nombre { get; set; } = null!;
        public int TablaId { get; set; }
        public string Tabla { get; set; } = null!;
        public string Extension { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
