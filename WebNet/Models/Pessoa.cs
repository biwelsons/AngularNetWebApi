using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebNet.Models
{
    public class Pessoa
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PessoaId { get; set; }

        public String? Nome { get; set; }

        public String? Sobrenome { get; set; }

        public int Idade { get; set; }

        public String? Profissao { get; set; }
    }
}