using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal2.Models
{
    public class CadastroPsicologoUrgente
    {
        [Key]
        public int Id_PsicoU { get; set; }

        public String Nome { get; set; }

        public String Email { get; set; }

        public int Telefone { get; set; }

        public Boolean Whatsapp { get; set; }
    }
}

