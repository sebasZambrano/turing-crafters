namespace Entity.Dtos.Security
{
    public class UsuarioChangePasswordDto
    {
        public int Id { get; set; }
        public string Usuario { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PasswordRepeat { get; set; } = null!;
    }
}
