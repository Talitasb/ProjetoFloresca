using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal2.Models
{
    public class CadastroPessoaGeral
    {
        [Key]
        public int Id_Geral { get; set; }

        public String Email { get; set; }

        public String Assunto { get; set; }

        [StringLength(50)]
        public String Mensagem { get; set; }
    }
}

