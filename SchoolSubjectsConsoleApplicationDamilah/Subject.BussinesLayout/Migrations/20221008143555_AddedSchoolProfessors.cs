using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Subject.BussinesLayout.Migrations
{
    public partial class AddedSchoolProfessors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearsOfExpirience = table.Column<int>(type: "int", nullable: true),
                    ProfessorDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectProfesors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectProfesors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectProfesors_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectProfesors_SchoolSubject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "SchoolSubject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "FirstName", "LastName", "ProfessorDescription", "YearsOfExpirience" },
                values: new object[,]
                {
                    { 1, "Johnny", "Depp", "Teach one or more university subjects to undergraduate and graduate students. Prepare and deliver lectures to students and conduct laboratory sessions or discussion groups. Prepare, administer and grade examinations, laboratory assignments and reports. Advise students on course and academic matters and career decisions.", 15 },
                    { 2, "Jessica", "Alba", "Teach one or more university subjects to undergraduate and graduate students. Prepare and deliver lectures to students and conduct laboratory sessions or discussion groups. Prepare, administer and grade examinations, laboratory assignments and reports. Advise students on course and academic matters and career decisions.", 12 },
                    { 3, "Angelina", "Joly", "Teach one or more university subjects to undergraduate and graduate students. Prepare and deliver lectures to students and conduct laboratory sessions or discussion groups. Prepare, administer and grade examinations, laboratory assignments and reports. Advise students on course and academic matters and career decisions.", 30 },
                    { 4, "Luise", "Armstrong", "Teach one or more university subjects to undergraduate and graduate students. Prepare and deliver lectures to students and conduct laboratory sessions or discussion groups. Prepare, administer and grade examinations, laboratory assignments and reports. Advise students on course and academic matters and career decisions.", 24 },
                    { 5, "Tony", "Montana", "Teach one or more university subjects to undergraduate and graduate students. Prepare and deliver lectures to students and conduct laboratory sessions or discussion groups. Prepare, administer and grade examinations, laboratory assignments and reports. Advise students on course and academic matters and career decisions.", 32 },
                    { 6, "Tonny", "Stark", "Teach one or more university subjects to undergraduate and graduate students. Prepare and deliver lectures to students and conduct laboratory sessions or discussion groups. Prepare, administer and grade examinations, laboratory assignments and reports. Advise students on course and academic matters and career decisions.", 15 }
                });

            migrationBuilder.InsertData(
                table: "SubjectProfesors",
                columns: new[] { "Id", "ProfessorId", "SubjectId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 6, 4 },
                    { 5, 6, 5 },
                    { 6, 5, 6 },
                    { 7, 3, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectProfesors_ProfessorId",
                table: "SubjectProfesors",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectProfesors_SubjectId",
                table: "SubjectProfesors",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectProfesors");

            migrationBuilder.DropTable(
                name: "Professors");
        }
    }
}
