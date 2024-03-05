using Exemplo2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Exemplo2.Controllers
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

        public IActionResult Details(int? id)
        {
            return View(Categorias.Where(cat => cat.CategoriaId == id).First());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(Categorias.Where(cat => cat.CategoriaId == id).First());
        }

        [HttpPost]
        public IActionResult Edit(Categoria categoria)
        {
            Categorias.Remove(Categorias.Where(cat => cat.CategoriaId == categoria.CategoriaId).First());
            Categorias.Add(categoria);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) {
            return View(Categorias.Where(cat => cat.CategoriaId == id).First());
        }

        [HttpPost]
        public IActionResult Delete(Categoria categoria)
        {
            Categorias.Remove(Categorias.Where( cat => cat.CategoriaId == categoria.CategoriaId).First());
           
            return RedirectToAction("Index");

        }

        public IActionResult ConsultaPorNome(string nome)
        {
            return View();          
           
        }

        public IActionResult RetornaDadosNome(string nome) {
            return View(Categorias.Where(cat => cat.Nome == nome).First());
        }

        
    }
}
