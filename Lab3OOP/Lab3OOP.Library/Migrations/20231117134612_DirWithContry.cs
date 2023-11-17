using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab3OOP.Library.Migrations
{
    /// <inheritdoc />
    public partial class DirWithContry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Director",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Director", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Studio",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studio", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Genre = table.Column<long>(type: "INTEGER", nullable: false),
                    Studio = table.Column<long>(type: "INTEGER", nullable: false),
                    Director = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Film_Director_Director",
                        column: x => x.Director,
                        principalTable: "Director",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Film_Genre_Genre",
                        column: x => x.Genre,
                        principalTable: "Genre",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Film_Studio_Studio",
                        column: x => x.Studio,
                        principalTable: "Studio",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Director_ID",
                table: "Director",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Film_Director",
                table: "Film",
                column: "Director");

            migrationBuilder.CreateIndex(
                name: "IX_Film_Genre",
                table: "Film",
                column: "Genre");

            migrationBuilder.CreateIndex(
                name: "IX_Film_ID",
                table: "Film",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Film_Studio",
                table: "Film",
                column: "Studio");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_ID",
                table: "Genre",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Studio_ID",
                table: "Studio",
                column: "ID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "Director");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Studio");
        }
    }
}
