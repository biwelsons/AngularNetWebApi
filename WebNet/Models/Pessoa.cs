using System.ComponentModel.DataAnnotations.Schema;

namespace WebNet.Models
{
    public class Pessoa
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PessoaId { get; set; }

        public String? Nome { get; set; }

        public String? Sobrenome { get; set; }

        public int Idade { get; set; }

        public String? NotaObservacao { get; set; }

        public String? TipoConsulta { get; set; }

        public double ValorConsulta { get; set; }

        public bool Ativo { get; set; }

    }
}