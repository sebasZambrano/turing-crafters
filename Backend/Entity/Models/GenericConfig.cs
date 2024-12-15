using Entity.Models.Security;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.Models
{
    internal class GenericConfig
    {
        public void ConfigureUsuario(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasIndex(i => i.UserName).IsUnique();
        }
        public void ConfigurePersona(EntityTypeBuilder<Persona> builder)
        {
            builder.HasIndex(i => i.Documento).IsUnique();
            builder.HasIndex(i => i.Email).IsUnique();
            builder.HasIndex(i => i.Telefono).IsUnique();
        }
    }
}
