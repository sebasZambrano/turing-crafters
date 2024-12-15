namespace Entity.Models.Parameter
{
    public class Archivo : BaseModel
    {
        public string Nombre { get; set; } = null!;
        public int TablaId { get; set; }
        public string Tabla { get; set; } = null!;
        public string Extension { get; set; } = null!;
        public string Content { get; set; } = null!;

    }
}
