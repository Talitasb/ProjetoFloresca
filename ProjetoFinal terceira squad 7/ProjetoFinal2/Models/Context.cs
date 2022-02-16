using Microsoft.EntityFrameworkCore;
using ProjetoFinal2.Models;


namespace ProjetoFinal2.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<CadastroVoluntario> CadastroVoluntario { get; set; }

        public DbSet<CadastroVagas> CadastroVagas { get; set; }

        public DbSet<CadastroPsicologoUrgente> CadastroPsicologoU { get; set; }

        public DbSet<CadastroPsicologoGeral> CadastroPsicologoG { get; set; }

        public DbSet<CadastroPessoaGeral> CadastroPessoaG { get; set; }

        public DbSet<CadastroJuridico> CadastroJuridico { get; set; }

    }

}
