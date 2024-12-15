using Entity.Models.Inventory;

namespace Entity.Models.Parameter
{
    public class Empresa : BaseModel
    {
        public string RazonSocial { get; set; } = null!;
        public string Nit { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;   
        public string Email { get; set; } = null!;
        public string? Web { get; set; } = null!;
        public int CiudadId { get; set; }
        public Ciudad Ciudad { get; set; } = new Ciudad();

        public List<Empleado> Empleados { get; set; } = new List<Empleado>();
        public List<Proveedor> Proveedores { get; set; } = new List<Proveedor>();
    }
}
