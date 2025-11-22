using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedAndUpdatedFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "LeaveRequests",
                newName: "StartDateTime");

            migrationBuilder.RenameColumn(
                name: "RequestDate",
                table: "LeaveRequests",
                newName: "RequestDateTime");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "LeaveRequests",
                newName: "EndDateTime");

            migrationBuilder.RenameColumn(
                name: "ApprovalDate",
                table: "LeaveRequests",
                newName: "ApprovalDateTime");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Employees",
                newName: "IsOnLeave");

            migrationBuilder.RenameColumn(
                name: "LastAuditDate",
                table: "Departments",
                newName: "LastAuditDateTime");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Departments",
                newName: "IsHiring");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "HireDate",
                table: "Employees",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "Employees",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PerformanceScore",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Departments",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PerformanceScore",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "StartDateTime",
                table: "LeaveRequests",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "RequestDateTime",
                table: "LeaveRequests",
                newName: "RequestDate");

            migrationBuilder.RenameColumn(
                name: "EndDateTime",
                table: "LeaveRequests",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "ApprovalDateTime",
                table: "LeaveRequests",
                newName: "ApprovalDate");

            migrationBuilder.RenameColumn(
                name: "IsOnLeave",
                table: "Employees",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "LastAuditDateTime",
                table: "Departments",
                newName: "LastAuditDate");

            migrationBuilder.RenameColumn(
                name: "IsHiring",
                table: "Departments",
                newName: "IsActive");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HireDate",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "Departments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
