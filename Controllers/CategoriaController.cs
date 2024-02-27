using Exemplo2_aula.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Exemplo2_aula.Controllers
{
    public class CategoriaController : Controller
    {
        public static IList<Categoria> Categorias = new List<Categoria>()
        {
            new Categoria()
            {
                CategoriaId = 1,
                Nome = "Eletrônicos"
            },
            new Categoria()
            {
                CategoriaId = 2,
                Nome = "Smartphones"
            },
            new Categoria()
            {
                CategoriaId = 3,
                Nome = "Acessórios"
            }
        };
        public IActionResult Index()
        {
            return View(Categorias.OrderBy(cat => cat.CategoriaId));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Categoria categoria)
        {
            Categorias.Add(categoria);
            categoria.CategoriaId = Categorias.Select(cat => cat.CategoriaId).Max() + 1;
            return RedirectToAction("Index");
        }

        
    }
}
