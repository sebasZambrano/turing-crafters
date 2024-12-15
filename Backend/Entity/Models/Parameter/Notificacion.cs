using Entity.Models.Security;

namespace Entity.Models.Parameter
{
    public class Notificacion : BaseModel
    {
        public string Titulo { get; set; } = null!;
        public string Mensaje { get; set; } = null!;
        public string Url { get; set; } = null!;
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = new Usuario();
    }
}
