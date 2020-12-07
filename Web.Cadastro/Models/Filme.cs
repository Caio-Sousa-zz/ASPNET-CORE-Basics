using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Cadastro.Models
{
    public class Filme
    {
        [Key] // Chave Primaria
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Título é obrigatório")]
        [StringLength(60, MinimumLength = 30, ErrorMessage = "O titulo precisa ter entre 3 ou 60 caracteres")]
        public string Titulo { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "O campo lançamento é do tipo data")]
        [Required(ErrorMessage = "O campo lançamento é obrigatório")]
        [Display(Name = "Data de Lançamento")]
        public DateTime DataLancamento { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\u00C0-\u00FF""'\w-]*$", ErrorMessage = "Genero Invalido")]
        [StringLength(30, ErrorMessage = "Máximo de 30 caracteres"), Required(ErrorMessage = "O campo Genero é obrigatório")]
        public string Genero { get; set; }

        [Range(1, 1000, ErrorMessage = "Valor de 1 a 10000")]
        [Required(ErrorMessage = "O campo valor é obrigatório")]
        [Column(TypeName = "decimal(18,2)")] // Propriedade da coluna no banco de dados
        public decimal Valor { get; set; }

        [RegularExpression(@"^[0-5]*$", ErrorMessage = "Somente números")]
        [Required(ErrorMessage = "O campo Avaliação é obrigatório")]
        [Display(Name = "Avaliação")]
        public string Avaliacao { get; set; }
    }
}