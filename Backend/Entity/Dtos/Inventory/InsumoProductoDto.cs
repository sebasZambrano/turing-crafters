namespace Entity.Dtos.Inventory
{
    public class InsumoProductoDto : BaseDto
    {
        public bool Adicional { get; set; }
        public decimal Cantidad { get; set; }
        public int InsumoId { get; set; }
        public string? Insumo { get; set; }
        public int ProductoId { get; set; }
        public string? Producto { get; set; }
        public int UnidadMedidaId { get; set; }
        public string? UnidadMedida { get; set; }
    }
}
