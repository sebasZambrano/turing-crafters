namespace Entity.Dtos.Operational
{
    public class CostoDto: BaseDto
    {
        public string? Descripcion { get; set; }
        public DateTime FechaCosto { get; set; }
        public decimal Valor { get; set; }
        public bool PagoCaja { get; set; }
        public string? NumeroFactura { get; set; }
        public int TipoCostoId { get; set; }
        public string? TipoCosto { get; set; }
        public int ProveedorId { get; set; }
        public string? Proveedor { get; set; }
        public int EmpleadoId { get; set; }
        public string? Empleado { get; set; }
        public int CajaId { get; set; }
        public string? Caja { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
    }
}
