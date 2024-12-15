using Entity.Models.Security;

namespace Entity.Models.Parameter
{
    public class Ciudad : GenericModel
    {
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; } = new Departamento();
        public List<Persona> Personas { get; set; } = new List<Persona>();
        public List<Empresa> Empresas { get; set; } = new List<Empresa>();

    }
}
