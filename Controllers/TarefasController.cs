
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TaskFlowWeb.Data;
using TaskFlowWeb.Models;

namespace TaskFlowWeb.Controllers;

public class TarefasController : Controller
{
    private readonly AppDbContext _context;

    public TarefasController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var tarefas = _context.Tarefas.ToList();
        return View(tarefas);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new Tarefa());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Tarefa tarefa)
    {
        if (string.IsNullOrWhiteSpace(tarefa.Titulo))
        {
            ModelState.AddModelError(
                nameof(tarefa.Titulo),
                "Digite o título da tarefa."
            );
        }

        if (!ModelState.IsValid)
        {
            return View(tarefa);
        }

        tarefa.Titulo = tarefa.Titulo.Trim();
        tarefa.Concluida = false;

        _context.Tarefas.Add(tarefa);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AlternarConclusao(int id)
    {
        var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);

        if (tarefa == null)
        {
            return NotFound();
        }

        tarefa.Concluida = !tarefa.Concluida;

        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Excluir(int id)
    {
        var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);

        if (tarefa == null)
        {
            return NotFound();
        }

        _context.Tarefas.Remove(tarefa);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Editar(int id)
    {
        var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);

        if (tarefa == null)
        {
            return NotFound();
        }

        return View(tarefa);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Editar(Tarefa tarefa)
    {
        if (string.IsNullOrWhiteSpace(tarefa.Titulo))
        {
            ModelState.AddModelError(
                nameof(tarefa.Titulo),
                "Digite o título da tarefa."
            );
        }

        if (!ModelState.IsValid)
        {
            return View(tarefa);
        }

        var tarefaExistente = _context.Tarefas
            .FirstOrDefault(t => t.Id == tarefa.Id);

        if (tarefaExistente == null)
        {
            return NotFound();
        }

        tarefaExistente.Titulo = tarefa.Titulo.Trim();

        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}
