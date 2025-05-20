using System.ComponentModel.DataAnnotations;

namespace webapi.DTO
{
    public class FilialDTO
    {
        [Required(ErrorMessage = "O nome da filial é obrigatório")]
        [StringLength(30, ErrorMessage = "O nome deve ter no máximo 30 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O endereço da filial é obrigatório")]
        public string Endereco { get; set; }
    }
}
