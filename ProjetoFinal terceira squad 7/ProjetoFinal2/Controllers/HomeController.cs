using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using ProjetoFinal2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal2.Controllers
{
    public class HomeController : Controller
    {

        private readonly Context _context;

        public HomeController(Context contexto)
        {
            _context = contexto;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ajuda()
        {
            return View();
        }
       
        public IActionResult Sobre()
        {
            return View();
        }

        public IActionResult Parcerias()
        {
            return View();
        }

        public IActionResult Voluntariado()
         
        {
            return View();
        }

        public IActionResult Login()

        {
            return View();
        }

        public IActionResult Acesso()

        {
            return View();
        }

        [HttpPost]
        public IActionResult Voluntariado(CadastroVoluntario voluntario)
        {
            _context.CadastroVoluntario.Add(voluntario);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Contato()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contato(CadastroPessoaGeral pessoaGeral)
        {
            _context.CadastroPessoaG.Add(pessoaGeral);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
   
    

