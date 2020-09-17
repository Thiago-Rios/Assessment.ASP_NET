using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using Repository.Context;

namespace Assessment.API.Controllers
{
    [Route("api/livros")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ApiContext _context;

        public LivrosController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivros()
        {
            return await _context.Livros.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetLivro(int id)
        {
            var livro = await _context.Livros.FindAsync(id);

            if (livro == null)
            {
                return NotFound();
            }

            return livro;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivro(int id, Livro livroEditado)
        {
            var livro = _context.Livros.Find(id);

            livro.Titulo = livroEditado.Titulo;
            livro.ISBN = livroEditado.ISBN;
            livro.Ano = livroEditado.Ano;

            _context.Livros.Update(livro);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Livro>> PostLivro(LivroResponse response)
        {
            var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == response.Autor.Id);
            response.Autor = autor;

            Livro novoLivro = new Livro { Titulo = response.Titulo, ISBN = response.ISBN, Ano = response.Ano, Autor = response.Autor };

            _context.Livros.Add(novoLivro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLivro", new { id = novoLivro.Id }, novoLivro);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Livro>> DeleteLivro(int id)
        {
            var livro = await _context.Livros.FindAsync(id);

            if (livro == null)
            {
                return NotFound();
            }

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();

            return livro;
        }

        private bool LivroExists(int id)
        {
            return _context.Livros.Any(e => e.Id == id);
        }
    }
}
