using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Staj.Migrations
{
    /// <inheritdoc />
    public partial class metahan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Content",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "Cover",
                table: "Content",
                newName: "UniName");

            migrationBuilder.RenameColumn(
                name: "Article",
                table: "Content",
                newName: "UniCover");

            migrationBuilder.AddColumn<string>(
                name: "Birimi",
                table: "Content",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Departmant",
                table: "Content",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Content",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Content",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IsyeriAdresi",
                table: "Content",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsyeriAdı",
                table: "Content",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsyeriEposta",
                table: "Content",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsyeriFax",
                table: "Content",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Isyeritelefon",
                table: "Content",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Content",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StajName",
                table: "Content",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StajNo",
                table: "Content",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StajPlace",
                table: "Content",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StajYeriSorumlusuAdı",
                table: "Content",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StajYeriSorumlusuSoyAdı",
                table: "Content",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StajYeriSorumlusuUnvanı",
                table: "Content",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SurName",
                table: "Content",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birimi",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "Departmant",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "End",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "IsyeriAdresi",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "IsyeriAdı",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "IsyeriEposta",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "IsyeriFax",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "Isyeritelefon",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "StajName",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "StajNo",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "StajPlace",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "StajYeriSorumlusuAdı",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "StajYeriSorumlusuSoyAdı",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "StajYeriSorumlusuUnvanı",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "SurName",
                table: "Content");

            migrationBuilder.RenameColumn(
                name: "UniName",
                table: "Content",
                newName: "Cover");

            migrationBuilder.RenameColumn(
                name: "UniCover",
                table: "Content",
                newName: "Article");

            migrationBuilder.RenameColumn(
                name: "Start",
                table: "Content",
                newName: "Date");
        }
    }
}
