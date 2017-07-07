using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BibliotecaMVC.Models
{
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo é obrigatório, favor verificar.")]
        [StringLength(100, ErrorMessage = "Máximo de 100 caractéres, favor verificar.")]
        public string Nome { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}