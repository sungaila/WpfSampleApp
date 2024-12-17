using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqliteDb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    BirthYear = table.Column<string>(type: "TEXT", nullable: false),
                    EyeColor = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    HairColor = table.Column<string>(type: "TEXT", nullable: false),
                    Height = table.Column<uint>(type: "INTEGER", nullable: false),
                    Mass = table.Column<uint>(type: "INTEGER", nullable: false),
                    SkinColor = table.Column<string>(type: "TEXT", nullable: false),
                    Homeworld = table.Column<string>(type: "TEXT", nullable: false),
                    Films = table.Column<string>(type: "TEXT", nullable: false),
                    Species = table.Column<string>(type: "TEXT", nullable: false),
                    Starships = table.Column<string>(type: "TEXT", nullable: false),
                    Vehicles = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Edited = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
