using System.ComponentModel.DataAnnotations;

namespace Razor.LanHouse.Dominios
{
    public partial class Usuarios
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password, ErrorMessage = "Senha inválida")]
        public string Senha { get; set; }
    }
}
