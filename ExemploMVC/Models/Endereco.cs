using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExemploMVC.Models
{
    [Table("Enderecos")]
    public class Endereco
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100, ErrorMessage = "Limite é 100.")]
        public string Rua { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required, MaxLength(100, ErrorMessage = "Limite é 100.")]
        public string Bairro { get; set; }

        public int MoradorId { get; set; }

        [ForeignKey(nameof(MoradorId))]
        public virtual Usuario Morador { get; set; }
    }
}