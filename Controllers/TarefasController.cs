
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TaskFlowWeb.Models;

namespace TaskFlowWeb.Controllers;

public class TarefasController : Controller
{
    public static readonly List<Tarefa> tarefas = new()
    {
        new Tarefa
        {
            Id = 1,
            Titulo = "Estudar C#",
            Concluida = false
        },
        new Tarefa
        {
            Id = 2,
            Titulo = "Aprender ASP.NET Core MVC",
            Concluida = true
        },
        new Tarefa
        {
            Id = 3,
            Titulo = "Criar a tela do TaskFlow",
            Concluida = false
        }
    };

    public IActionResult Index()
    {
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

        tarefa.Id = tarefas.Count == 0
            ? 1
            : tarefas.Max(t => t.Id) + 1;

        tarefa.Titulo = tarefa.Titulo.Trim();
        tarefa.Concluida = false;

        tarefas.Add(tarefa);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AlternarConclusao(int id)
    {
        var tarefa = tarefas.FirstOrDefault(t => t.Id == id);

        if (tarefa == null)
        {
            return NotFound();
        }

        tarefa.Concluida = !tarefa.Concluida;

        return RedirectToAction(nameof(Index));
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Excluir(int id)
    {
        var tarefa = tarefas.FirstOrDefault(t => t.Id == id);

        if (tarefa == null)
        {
            return NotFound();
        }

        tarefas.Remove(tarefa);

        return RedirectToAction(nameof(Index));
    }


    [HttpGet]
    public IActionResult Editar(int id)
    {
        var tarefa = tarefas.FirstOrDefault(t => t.Id == id);

        if (tarefa == null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(tarefa);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Editar(Tarefa tarefa)
    {
        var tarefaExistente = tarefas.FirstOrDefault(t => t.Id == tarefa.Id);

        if (tarefaExistente == null)
        {
            return NotFound();
        }

        if (string.IsNullOrWhiteSpace(tarefa.Titulo))
        {
            ModelState.AddModelError(nameof(tarefa.Titulo),
            "Digite o titulo da terefa"
            );
        }

        if (!ModelState.IsValid)
        {
            return View(tarefa);
        }

        tarefaExistente.Titulo = tarefa.Titulo.Trim();

        return RedirectToAction(nameof(Index));
    }

}
