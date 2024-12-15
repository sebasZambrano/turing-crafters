using Entity.Models;

namespace Entity.Dtos.Inventory
{
    public class ProveedorDto : BaseDto
    {
        public string? NumeroCuenta { get; set; }
        public int EmpresaId { get; set; }
        public string? Empresa { get; set; }
        public int BancoId { get; set; }
        public string? Banco { get; set; }
    }
}
