using System.ComponentModel.DataAnnotations;

namespace Entity.Models
{
    public abstract class GenericModel: BaseModel
    {
        [StringLength(maximumLength: 30)]
        public string Codigo { get; set; } = null!;

        [StringLength(maximumLength: 255)]
        public string Nombre { get; set; } = null!;

    }
}
