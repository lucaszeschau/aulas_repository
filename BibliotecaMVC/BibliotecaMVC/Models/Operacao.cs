using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BibliotecaMVC.Models
{
    public class Operacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataEmprestimo { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataPrevisao { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataDevolucao { get; set; }

        [Required]
        public bool Status { get; set; }

        #region [Relacionamentos]

        #region [Cliente]

        public int IdCliente { get; set; }

        public virtual Cliente Clientes { get; set; }

        #endregion

        #region [Livro]

        public int IdLivro { get; set; }

        public virtual Livro Livros { get; set; }

        #endregion

        #endregion
    }
}