namespace Entity.Models.Parameter
{
    public class Impresora : GenericModel
    {
        public int Tamaño { get; set; }
        public List<ImpresoraCategoria> ImpresorasCategorias { get; set; } = new List<ImpresoraCategoria>();
    }
}
