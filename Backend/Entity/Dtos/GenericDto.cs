using System.ComponentModel.DataAnnotations;

namespace Entity.Dtos
{
    public class GenericDto : BaseDto
    {
        [StringLength(30)]
        public string Codigo { get; set; } = null!;

        [StringLength(maximumLength: 100)]
        public string Nombre { get; set; } = null!;
    }
}
