using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdquisicionesBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddRequerimientoAdquisicion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RequerimientosAdquisiciones",
                table: "RequerimientosAdquisiciones");

            migrationBuilder.RenameTable(
                name: "RequerimientosAdquisiciones",
                newName: "RequerimientosAdquisicion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequerimientosAdquisicion",
                table: "RequerimientosAdquisicion",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RequerimientosAdquisicion",
                table: "RequerimientosAdquisicion");

            migrationBuilder.RenameTable(
                name: "RequerimientosAdquisicion",
                newName: "RequerimientosAdquisiciones");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequerimientosAdquisiciones",
                table: "RequerimientosAdquisiciones",
                column: "Id");
        }
    }
}
