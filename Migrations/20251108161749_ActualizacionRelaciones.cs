using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profesors_Users_UserId",
                table: "Profesors");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_Email",
                table: "Students",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_Code",
                table: "Students",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_Lastname",
                table: "Students",
                column: "Lastname");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesors_Users_UserId",
                table: "Profesors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profesors_Users_UserId",
                table: "Profesors");

            migrationBuilder.DropIndex(
                name: "IX_Estudiante_Email",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Student_Code",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Student_Lastname",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesors_Users_UserId",
                table: "Profesors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
