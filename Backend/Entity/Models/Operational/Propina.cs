using Entity.Models.Parameter;

namespace Entity.Models.Operational
{
    public class Propina : BaseModel
    {
        public decimal Valor { get; set; }
        public decimal Procentaje { get; set; }
        public bool Liquidado { get; set; }
        public int EmpleadoId { get; set; }
        public int FacturaId { get; set; }
        public int MedioPagoId { get; set; }
        public Empleado Empleado { get; set; } = new Empleado();
        public Factura Factura { get; set; } = new Factura();
        public MedioPago MedioPago { get; set; } = new MedioPago();
    }
}
