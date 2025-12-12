using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollabTask.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TodoTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTask_Projects_ProjectId",
                table: "TodoTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoTask",
                table: "TodoTask");

            migrationBuilder.RenameTable(
                name: "TodoTask",
                newName: "TodoTasks");

            migrationBuilder.RenameIndex(
                name: "IX_TodoTask_ProjectId",
                table: "TodoTasks",
                newName: "IX_TodoTasks_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoTasks",
                table: "TodoTasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTasks_Projects_ProjectId",
                table: "TodoTasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTasks_Projects_ProjectId",
                table: "TodoTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoTasks",
                table: "TodoTasks");

            migrationBuilder.RenameTable(
                name: "TodoTasks",
                newName: "TodoTask");

            migrationBuilder.RenameIndex(
                name: "IX_TodoTasks_ProjectId",
                table: "TodoTask",
                newName: "IX_TodoTask_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoTask",
                table: "TodoTask",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTask_Projects_ProjectId",
                table: "TodoTask",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
