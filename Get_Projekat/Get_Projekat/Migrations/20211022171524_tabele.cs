using Microsoft.EntityFrameworkCore.Migrations;

namespace Get_Projekat.Migrations
{
    public partial class tabele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "stolovi",
                columns: table => new
                {
                    StoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cena = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stolovi", x => x.StoId);
                });

            migrationBuilder.CreateTable(
                name: "termini",
                columns: table => new
                {
                    TerminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnikId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    End = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_termini", x => x.TerminId);
                    table.ForeignKey(
                        name: "FK_termini_AspNetUsers_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_termini_stolovi_StoId",
                        column: x => x.StoId,
                        principalTable: "stolovi",
                        principalColumn: "StoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_termini_KorisnikId",
                table: "termini",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_termini_StoId",
                table: "termini",
                column: "StoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "termini");

            migrationBuilder.DropTable(
                name: "stolovi");
        }
    }
}
