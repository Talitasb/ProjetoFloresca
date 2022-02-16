using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal2.Models
{
    public class CadastroVoluntario
    {
        [Key]
        public int Id_Voluntario { get; set; }

        public String Nome { get; set; }

        public String Sobrenome { get; set; }

        public String Endereco { get; set; }

        public String Cidade { get; set; }

        public String Estado { get; set; }

        public int CEP { get; set; }
       
        public Boolean Psicologia { get; set; }
       
        public Boolean Juridico { get; set; }

        public Boolean Geral { get; set; }

    }
    }

