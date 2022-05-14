using Microsoft.EntityFrameworkCore.Migrations;

namespace RoleBasedSalarySystem.DataAccess.Migrations
{
    public partial class UpdateWorkTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TaskId",
                table: "Work",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Work",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Work_EmployeeId",
                table: "Work",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Work_TaskId",
                table: "Work",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Work_Employees_EmployeeId",
                table: "Work",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Work_Tasks_TaskId",
                table: "Work",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Work_Employees_EmployeeId",
                table: "Work");

            migrationBuilder.DropForeignKey(
                name: "FK_Work_Tasks_TaskId",
                table: "Work");

            migrationBuilder.DropIndex(
                name: "IX_Work_EmployeeId",
                table: "Work");

            migrationBuilder.DropIndex(
                name: "IX_Work_TaskId",
                table: "Work");

            migrationBuilder.AlterColumn<int>(
                name: "TaskId",
                table: "Work",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Work",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
