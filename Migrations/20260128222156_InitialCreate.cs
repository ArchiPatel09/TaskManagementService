using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagementService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 650, nullable: false),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EstimatedHours = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "Id", "CreatedAt", "Description", "DueDate", "EstimatedHours", "Priority", "Status", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 26, 22, 21, 55, 774, DateTimeKind.Utc).AddTicks(8462), "Create house price prediction model using supervised machine learning techniques.", new DateTime(2026, 2, 1, 22, 21, 55, 774, DateTimeKind.Utc).AddTicks(8449), 13, 1, 2, "Learn Supervised Machine Learning", new DateTime(2026, 1, 27, 22, 21, 55, 774, DateTimeKind.Utc).AddTicks(8463) },
                    { 2, new DateTime(2026, 1, 27, 22, 21, 55, 774, DateTimeKind.Utc).AddTicks(8470), "Analyze sales data using Python libraries such as Pandas and Matplotlib. Then use the data in one of frontend projects.", new DateTime(2026, 2, 4, 22, 21, 55, 774, DateTimeKind.Utc).AddTicks(8469), 20, 2, 1, "Complete Python Data Analysis Project", null },
                    { 3, new DateTime(2026, 1, 28, 22, 21, 55, 774, DateTimeKind.Utc).AddTicks(8476), "Develop a full-stack web application using ASP.NET Core for the backend and React for the frontend. Implement CRUD operations and user authentication.", new DateTime(2026, 1, 31, 22, 21, 55, 774, DateTimeKind.Utc).AddTicks(8474), 15, 3, 1, "Create one full-stack project by using ASP.NET Core and React!", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskItems");
        }
    }
}
