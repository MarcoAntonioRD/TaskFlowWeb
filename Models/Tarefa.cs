using System.ComponentModel.DataAnnotations;

namespace TaskFlowWeb.Models;

public enum PrioridadeTarefa
{
    Media = 0,
    Baixa = 1,
    Alta = 2,
}

public class Tarefa
{
    public int Id {get;  set;}

    [Required(ErrorMessage = "Digite o titúlo da tarefa.")]
    [StringLength(150)]
    public string Titulo {get; set;} = string.Empty;

    public bool Concluida {get; set;}

    public PrioridadeTarefa Prioridade {get; set;} = PrioridadeTarefa.Media;

}