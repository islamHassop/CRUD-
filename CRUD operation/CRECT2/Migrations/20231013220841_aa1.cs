using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRECT2.Migrations
{
    /// <inheritdoc />
    public partial class aa1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CorseResult_Course_CorsId",
                table: "CorseResult");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Departments_DeptId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Course_CourseId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_Course_DeptId",
                table: "Courses",
                newName: "IX_Courses_DeptId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CorseResult_Courses_CorsId",
                table: "CorseResult",
                column: "CorsId",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DeptId",
                table: "Courses",
                column: "DeptId",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Courses_CourseId",
                table: "Employees",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CorseResult_Courses_CorsId",
                table: "CorseResult");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DeptId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Courses_CourseId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_DeptId",
                table: "Course",
                newName: "IX_Course_DeptId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CorseResult_Course_CorsId",
                table: "CorseResult",
                column: "CorsId",
                principalTable: "Course",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Departments_DeptId",
                table: "Course",
                column: "DeptId",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Course_CourseId",
                table: "Employees",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
