using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BibliotecaMVC.Models
{
    public class Livro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo é obrigatório, favor verificar.")]
        [StringLength(100, ErrorMessage = "Máximo de 100 caractéres, favor verificar.")]
        public string Nome { get; set; }

        [StringLength(500, ErrorMessage = "Máximo de 500 caractéres, favor verificar.")]
        public string Sinopse { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo é obrigatório, favor verificar.")]
        [StringLength(100, ErrorMessage = "Máximo de 100 caractéres, favor verificar.")]
        public string Autor { get; set; }

        [Required]
        public bool Disponivel { get; set; }

        #region [Relacionamento]

        public int IdCategoria { get; set; }

        public virtual Categoria Categorias { get; set; }

        #endregion
    }
}