

using Microsoft.EntityFrameworkCore;
using TaskFlowWeb.Models;

namespace TaskFlowWeb.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Tarefa> Tarefas { get; set; } = null!;
}
