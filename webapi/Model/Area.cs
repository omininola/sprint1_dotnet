using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.Model
{
    public class Area
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O status da área é obrigatório")]
        [StringLength(20, ErrorMessage = "O status deve ter no máximo 20 caracteres")]
        public string Status { get; set; }

        [Required(ErrorMessage = "A filial é obrigatória")]
        public int FilialId { get; set; }

        public Filial Filial { get; set; }
    }
}
