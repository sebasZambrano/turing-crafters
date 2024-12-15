namespace Entity.Models.Parameter
{
    public class ImpresoraCategoria : BaseModel
    {
        public int CategoriaId { get; set; }
        public int ImpresoraId { get; set; }
        public int SalonId { get; set; }
        public Categoria Categoria { get; set; } = new Categoria();
        public Impresora Impresora { get; set; } = new Impresora();
        public Salon Salon { get; set; } = new Salon();
    }
}
