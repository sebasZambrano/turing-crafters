namespace Entity.Dtos.Inventory
{
    public class ProductoDto : GenericDto
    {
        public string DescripcionCorta { get; set; } = null!;
        public string DescripcionLarga { get; set; } = null!;
        public decimal PrecioCosto { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }
        public decimal Iva { get; set; }
        public int CategoriaId { get; set; }
        public string? Categoria { get; set; }
        public int EmpleadoId { get; set; }
        public bool Insumo { get; set; }
    }
}
