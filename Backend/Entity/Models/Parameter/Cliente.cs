using Entity.Models.Security;

namespace Entity.Models.Parameter
{
    public class Cliente : GenericModel
    {
        public int PersonaId { get; set; }
        public Persona Persona { get; set; } = new Persona();
    }
}
