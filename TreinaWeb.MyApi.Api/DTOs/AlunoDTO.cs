using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreinaWeb.MyApi.Api.DTOs
{
    public class AlunoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do aluno é obrigatório.")]
        [StringLength(maximumLength: 2, MinimumLength = 50, ErrorMessage = "O nome deve ter no mínimo 2 caracteres e no máximo 50 caracteres.")]
        public string Nome { get; set; }
        [StringLength(100, ErrorMessage = "O endereço deve ter no máximo 200 caracteres.")]
        public string Endereco { get; set; }
        [Range(9.99, 999.99, ErrorMessage = "A mensalidade deve ser no mínimo R$ 9,99 e no máximo R$ 999,99")]
        public decimal Mensalidade { get; set; }
    }
}