
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


    public IActionResult Index(string? busca, string? prioridade, string? status, int pagina)
    {
        // Indicadores gerais do dashboard
        ViewBag.TotalTarefas = _context.Tarefas.Count();

        ViewBag.Pendentes = _context.Tarefas
            .Count(t => !t.Concluida);

        ViewBag.Concluidas = _context.Tarefas
            .Count(t => t.Concluida);

        ViewBag.PrioridadeAlta = _context.Tarefas
            .Count(t => t.Prioridade == PrioridadeTarefa.Alta);

        // Consulta usada para listar e filtrar as tarefas
        var consulta = _context.Tarefas.AsQueryable();

        // Pesquisa pelo título
        if (!string.IsNullOrWhiteSpace(busca))
        {
            consulta = consulta.Where(t =>
                t.Titulo.Contains(busca.Trim()));
        }

        // Filtro por prioridade
        if (Enum.TryParse<PrioridadeTarefa>(
            prioridade, true, out var prioridadeSelecionada)
            && Enum.IsDefined(typeof(PrioridadeTarefa), prioridadeSelecionada))
        {
            consulta = consulta.Where(t =>
                t.Prioridade == prioridadeSelecionada);
        }

        // Filtro por situação
        if (status == "pendente")
        {
            consulta = consulta.Where(t => !t.Concluida);
        }
        else if (status == "concluida")
        {
            consulta = consulta.Where(t => t.Concluida);
        }

        // Mantém os valores selecionados na tela
        ViewBag.Busca = busca;
        ViewBag.Prioridade = prioridade;
        ViewBag.Status = status;

        const int itensPorPagina = 10;

        int totalTarefasFiltradas = consulta.Count();
        ViewBag.TotalTarefasFiltradas = totalTarefasFiltradas;

        int totalPaginas = Math.Max(
            1,
            (int)Math.Ceiling(totalTarefasFiltradas / (double)itensPorPagina));

        pagina = Math.Clamp(pagina, 1, totalPaginas);
        ViewBag.PaginaAtual = pagina;
        ViewBag.TotalPaginas = totalPaginas;

        var tarefas = consulta
            .OrderBy(t => t.Id)
            .Skip((pagina - 1) * itensPorPagina)
            .Take(itensPorPagina)
            .ToList();
        
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
    public IActionResult AlternarConclusao(
        int id,
        int pagina = 1,
        string? busca = null,
        string? prioridade = null,
        string? status = null)
    {
        var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);

        if (tarefa == null)
        {
            return NotFound();
        }

        tarefa.Concluida = !tarefa.Concluida;

        _context.SaveChanges();

        return RedirectToAction(nameof(Index), new { busca, prioridade, status, pagina });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Excluir(
        int id,
        int pagina = 1,
        string? busca = null,
        string? prioridade = null,
        string? status = null)
    {
        var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);

        if (tarefa == null)
        {
            return NotFound();
        }

        _context.Tarefas.Remove(tarefa);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index), new { busca, prioridade, status, pagina });
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
        tarefaExistente.Prioridade = tarefa.Prioridade;

        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}
