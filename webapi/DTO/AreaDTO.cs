using System.ComponentModel.DataAnnotations;

namespace webapi.DTO
{
    public class AreaDTO
    {
        [Required(ErrorMessage = "O status da área é obrigatório")]
        public string Status { get; set; }

        [Required(ErrorMessage = "O ID da filial é obrigatório")]
        public int FilialId { get; set; }
    }
}
