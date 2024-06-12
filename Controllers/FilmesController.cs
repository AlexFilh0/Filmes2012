using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Filmes2012.Data;
using Filmes2012.Models;

namespace Filmes2012.Controllers
{
    
    public class FilmesController : Controller
    {

        Uri baseAddress = new Uri("http://localhost:5146/api");
        private readonly HttpClient _httpclient;

        private readonly Filmes2012Context _context;

        public FilmesController(Filmes2012Context context)
        {
            _context = context;

            _httpclient = new HttpClient();
        }

        // GET: Filmes
        public async Task<IActionResult> Index()
        {
            var filmes = await _httpclient.GetFromJsonAsync<List<Filmes>>("http://localhost:5146/api/Filme/GetFilmes");
            return View(filmes);

        }
 

        // GET: Filmes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var filmes = await _httpclient.GetFromJsonAsync<Filmes>($"http://localhost:5146/api/Filme/GetFilme/{id}");
            return View(filmes);
        }

        // GET: Filmes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filmes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Filmes filme)
        {
            if (ModelState.IsValid)
        {
            // Enviar solicitação POST para a API para adicionar o novo filme
            var response = await _httpclient.PostAsJsonAsync("http://localhost:5146/api/Filme/PostFilme", filme);

            // Verificar se a solicitação foi bem-sucedida
            if (response.IsSuccessStatusCode)
            {
                // Redirecionar para a página de índice após adicionar o filme com sucesso
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // Se a solicitação falhou, exibir uma mensagem de erro ou tratar de outra forma
                ModelState.AddModelError(string.Empty, "Erro ao adicionar filme. Por favor, tente novamente.");
                return View(filme);
            }
        }

        // Se o modelo não for válido, retornar a view de adicionar filme com os erros de validação
        return View(filme);
    }

        // GET: Filmes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var filmes = await _httpclient.GetFromJsonAsync<Filmes>($"http://localhost:5146/api/Filme/GetFilme/{id}");
            return View(filmes);
        }

        // POST: Filmes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Filmes filme)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpclient.PutAsJsonAsync($"http://localhost:5146/api/Filme/PutFilme/{filme.Id}", filme);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Erro ao atualizar filme. Por favor, tente novamente.");
                    return View(filme); // ou return RedirectToAction(nameof(Index)); dependendo da lógica do seu aplicativo
                }
            }

            return View(filme);
        }

        // GET: Filmes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpclient.GetAsync($"http://localhost:5146/api/Filme/GetFilme/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var filme = await response.Content.ReadFromJsonAsync<Filmes>();
            return View(filme);
        }

        // POST: Filmes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpclient.DeleteAsync($"http://localhost:5146/api/Filme/DeleteFilme/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Erro ao excluir filme. Por favor, tente novamente.");
                return View(); // ou return RedirectToAction(nameof(Index)); dependendo da lógica do seu aplicativo
            }
        }       


        private bool FilmesExists(int id)
        {
            return _context.Filmes.Any(e => e.Id == id);
        }
    }
}
