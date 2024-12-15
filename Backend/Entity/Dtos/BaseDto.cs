namespace Entity.Dtos
{
    public class BaseDto
    {
        public int Id { get; set; }
        public bool Activo { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
