using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.Model
{
    public class Filial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da filial é obrigatório")]
        [StringLength(30, ErrorMessage = "O nome deve ter no máximo 30 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O endereço da filial é obrigatório")]
        public string Endereco { get; set; }

        public ICollection<Area> Areas { get; set; }
    }
}
