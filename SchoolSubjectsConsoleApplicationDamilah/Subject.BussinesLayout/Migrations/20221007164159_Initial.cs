using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Subject.BussinesLayout.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SchoolSubject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfWeeklyClasses = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolSubject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Literature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolSubjectId = table.Column<int>(type: "int", nullable: false),
                    LiteratureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Literature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Literature_SchoolSubject_SchoolSubjectId",
                        column: x => x.SchoolSubjectId,
                        principalTable: "SchoolSubject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SchoolSubject",
                columns: new[] { "Id", "Description", "NumberOfWeeklyClasses", "SubjectName" },
                values: new object[,]
                {
                    { 1, "Mathematics is the science and study of quality, structure, space, and change. Mathematicians seek out patterns, formulate new conjectures, and establish truth by rigorous deduction from appropriately chosen axioms and definitions.", 3, "Math" },
                    { 2, "The subject shall help build up general language proficiency through listening,speaking,reading and writing,and provide the opportunity to acquire information and specialised knowledge through the English language.", 3, "English" },
                    { 3, "The term subjects in art refers to the main idea that is represented in the artwork. The subject in art is basically the essence of the piece. To determine subject matter in a particular piece of art, ask yourself: What is actually depicted in this artwork?", 2, "Art" },
                    { 4, "Geography is the study of places and the relationships between people and their environments. Geographers explore both the physical properties of Earth's surface and the human societies spread across it.", 2, "Geography" },
                    { 5, "History is the study of life in society in the past, in all its aspect, in relation to present developments and future hopes. It is the story of man in time, an inquiry into the past based on evidence. Indeed, evidence is the raw material of history teaching and learning.", 4, "History" },
                    { 6, "This course is a study of theory and research of the normal personality including basic concepts, techniques of measurement, and relevant findings. This course surveys the major theories of personality, including trait, psychodynamic, humanistic, cognitive, and behavioral perspectives.", 2, "Psychology" }
                });

            migrationBuilder.InsertData(
                table: "Literature",
                columns: new[] { "Id", "AuthorName", "LiteratureName", "SchoolSubjectId" },
                values: new object[,]
                {
                    { 1, "Chris McMullen", "Essential Calculus Skills Practice Workbook with Full Solutions", 1 },
                    { 2, "Chris McMullen", "Algebra Essentials Practice Workbook with Answers: Linear & Quadratic Equations, Cross Multiplying, and Systems of Equations: Improve Your Math Fluency Series", 1 },
                    { 3, "Oxford", "Oxford Advanced Learner’s Dictionary (OALD)", 2 },
                    { 4, "3dtotal Publishing", "Artists’ Master Series: Color and Light", 3 },
                    { 5, "Victor Perard", "Anatomy and Drawing (Dover Art Instruction)", 3 },
                    { 6, "Robert D. Kaplan", "Adriatic: A Concert of Civilizations at the End of the Modern Age", 4 },
                    { 7, "Edward Hallett Carr", "What Is History?", 5 },
                    { 8, "Charles C. Mann", "1491", 5 },
                    { 9, "Asaad Almohammad", "An Ishmael of Syria (Paperback)", 6 },
                    { 10, "Alex Michaelides", "The Silent Patient (Hardcover)", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Literature_SchoolSubjectId",
                table: "Literature",
                column: "SchoolSubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Literature");

            migrationBuilder.DropTable(
                name: "SchoolSubject");
        }
    }
}
