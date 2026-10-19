using System.ComponentModel.DataAnnotations;

namespace TaskFlowWeb.Models;

public class Tarefa
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O título é obrigatório.")]
    [StringLength(150, ErrorMessage ="O título deve ter no máximo 150 caracteres.")]

    public String Titulo { get; set; } = string.Empty;

    public bool Concluida { get;  set; }
}
