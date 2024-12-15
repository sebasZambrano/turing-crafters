namespace Entity.Models.Parameter
{
    public class Categoria : GenericModel
    {
        public int MacroCategoriaId { get; set; }
        public MacroCategoria MacroCategoria { get; set; } = new MacroCategoria();
        public List<ImpresoraCategoria> ImpresorasCategorias { get; set; } = new List<ImpresoraCategoria>();
    }
}
