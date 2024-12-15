namespace Entity.Models.Parameter
{
    public class Salon : GenericModel
    {
        public int ZonaId { get; set; }
        public string Descripcion { get; set; } = null!;
        public Zona Zona { get; set; } = new Zona();
        public List<ImpresoraCategoria> ImpresorasCategorias { get; set; } = new List<ImpresoraCategoria>();
        public List<Mesa> Mesas { get; set; } = new List<Mesa>();
    }
}
