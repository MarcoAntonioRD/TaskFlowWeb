using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskFlowWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddPrioridadeToTarefa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "prioridade",
                table: "Tarefas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "prioridade",
                table: "Tarefas");
        }
    }
}
