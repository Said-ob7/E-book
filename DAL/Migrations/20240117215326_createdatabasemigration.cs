using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class createdatabasemigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "T_Livre",
                schema: "dbo",
                columns: table => new
                {
                    LivreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Couverture = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Livre", x => x.LivreId);
                });

            migrationBuilder.CreateTable(
                name: "T_Avis",
                schema: "dbo",
                columns: table => new
                {
                    AvisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LivreId = table.Column<int>(type: "int", nullable: false),
                    Commentaire = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Note = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Avis", x => x.AvisId);
                    table.ForeignKey(
                        name: "FK_T_Avis_T_Livre_LivreId",
                        column: x => x.LivreId,
                        principalSchema: "dbo",
                        principalTable: "T_Livre",
                        principalColumn: "LivreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_Chapitre",
                schema: "dbo",
                columns: table => new
                {
                    ChapitreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LivreId = table.Column<int>(type: "int", nullable: false),
                    Titre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Contenu = table.Column<string>(type: "nvarchar(max)", maxLength: 400000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Chapitre", x => x.ChapitreId);
                    table.ForeignKey(
                        name: "FK_T_Chapitre_T_Livre_LivreId",
                        column: x => x.LivreId,
                        principalSchema: "dbo",
                        principalTable: "T_Livre",
                        principalColumn: "LivreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Avis_LivreId",
                schema: "dbo",
                table: "T_Avis",
                column: "LivreId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Chapitre_LivreId",
                schema: "dbo",
                table: "T_Chapitre",
                column: "LivreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Avis",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "T_Chapitre",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "T_Livre",
                schema: "dbo");
        }
    }
}
