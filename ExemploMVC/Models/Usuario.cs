using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExemploMVC.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Limite de caracteres é 100.")]
        public string Nome { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}