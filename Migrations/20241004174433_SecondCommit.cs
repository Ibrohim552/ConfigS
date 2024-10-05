using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFcoreWebAPi.Migrations
{
    /// <inheritdoc />
    public partial class SecondCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctor",
                table: "Doctor");

            migrationBuilder.RenameTable(
                name: "Doctor",
                newName: "Doctors");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Doctors",
                type: "character varying(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Doctors",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "BirthDay",
                table: "Doctors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "Doctors");

            migrationBuilder.RenameTable(
                name: "Doctors",
                newName: "Doctor");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Doctor",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(13)",
                oldMaxLength: 13);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Doctor",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctor",
                table: "Doctor",
                column: "Id");
        }
    }
}
