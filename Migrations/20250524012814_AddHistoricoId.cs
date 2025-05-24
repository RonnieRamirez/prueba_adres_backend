using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdquisicionesBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddHistoricoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdRequerimientoAdquisicion",
                table: "RequerimientoAdquisicionHistoricos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdRequerimientoAdquisicion",
                table: "RequerimientoAdquisicionHistoricos");
        }
    }
}
