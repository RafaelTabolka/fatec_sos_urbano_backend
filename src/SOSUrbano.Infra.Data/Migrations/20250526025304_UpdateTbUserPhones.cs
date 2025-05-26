using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOSUrbano.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTbUserPhones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPhoneSet_tb_users_UserId",
                table: "UserPhoneSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPhoneSet",
                table: "UserPhoneSet");

            migrationBuilder.RenameTable(
                name: "UserPhoneSet",
                newName: "tb_user_phones");

            migrationBuilder.RenameIndex(
                name: "IX_UserPhoneSet_UserId",
                table: "tb_user_phones",
                newName: "IX_tb_user_phones_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "tb_user_phones",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_user_phones",
                table: "tb_user_phones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_user_phones_tb_users_UserId",
                table: "tb_user_phones",
                column: "UserId",
                principalTable: "tb_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_user_phones_tb_users_UserId",
                table: "tb_user_phones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_user_phones",
                table: "tb_user_phones");

            migrationBuilder.RenameTable(
                name: "tb_user_phones",
                newName: "UserPhoneSet");

            migrationBuilder.RenameIndex(
                name: "IX_tb_user_phones_UserId",
                table: "UserPhoneSet",
                newName: "IX_UserPhoneSet_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "UserPhoneSet",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPhoneSet",
                table: "UserPhoneSet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPhoneSet_tb_users_UserId",
                table: "UserPhoneSet",
                column: "UserId",
                principalTable: "tb_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
