using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOSUrbano.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterNameTbUserType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncidentSet_tb_user_UserId",
                table: "IncidentSet");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_user_UserTypeSet_UserTypeId",
                table: "tb_user");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_user_tb_user_status_UserStatusId",
                table: "tb_user");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPhoneSet_tb_user_UserId",
                table: "UserPhoneSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTypeSet",
                table: "UserTypeSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_user_status",
                table: "tb_user_status");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_user",
                table: "tb_user");

            migrationBuilder.RenameTable(
                name: "UserTypeSet",
                newName: "tb_user_types");

            migrationBuilder.RenameTable(
                name: "tb_user_status",
                newName: "tb_user_statuses");

            migrationBuilder.RenameTable(
                name: "tb_user",
                newName: "tb_users");

            migrationBuilder.RenameIndex(
                name: "IX_tb_user_UserTypeId",
                table: "tb_users",
                newName: "IX_tb_users_UserTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_user_UserStatusId",
                table: "tb_users",
                newName: "IX_tb_users_UserStatusId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "tb_user_types",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "tb_user_statuses",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_user_types",
                table: "tb_user_types",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_user_statuses",
                table: "tb_user_statuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_users",
                table: "tb_users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentSet_tb_users_UserId",
                table: "IncidentSet",
                column: "UserId",
                principalTable: "tb_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_users_tb_user_statuses_UserStatusId",
                table: "tb_users",
                column: "UserStatusId",
                principalTable: "tb_user_statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_users_tb_user_types_UserTypeId",
                table: "tb_users",
                column: "UserTypeId",
                principalTable: "tb_user_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPhoneSet_tb_users_UserId",
                table: "UserPhoneSet",
                column: "UserId",
                principalTable: "tb_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncidentSet_tb_users_UserId",
                table: "IncidentSet");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_users_tb_user_statuses_UserStatusId",
                table: "tb_users");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_users_tb_user_types_UserTypeId",
                table: "tb_users");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPhoneSet_tb_users_UserId",
                table: "UserPhoneSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_users",
                table: "tb_users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_user_types",
                table: "tb_user_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_user_statuses",
                table: "tb_user_statuses");

            migrationBuilder.RenameTable(
                name: "tb_users",
                newName: "tb_user");

            migrationBuilder.RenameTable(
                name: "tb_user_types",
                newName: "UserTypeSet");

            migrationBuilder.RenameTable(
                name: "tb_user_statuses",
                newName: "tb_user_status");

            migrationBuilder.RenameIndex(
                name: "IX_tb_users_UserTypeId",
                table: "tb_user",
                newName: "IX_tb_user_UserTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_users_UserStatusId",
                table: "tb_user",
                newName: "IX_tb_user_UserStatusId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserTypeSet",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "tb_user_status",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_user",
                table: "tb_user",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTypeSet",
                table: "UserTypeSet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_user_status",
                table: "tb_user_status",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentSet_tb_user_UserId",
                table: "IncidentSet",
                column: "UserId",
                principalTable: "tb_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_user_UserTypeSet_UserTypeId",
                table: "tb_user",
                column: "UserTypeId",
                principalTable: "UserTypeSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_user_tb_user_status_UserStatusId",
                table: "tb_user",
                column: "UserStatusId",
                principalTable: "tb_user_status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPhoneSet_tb_user_UserId",
                table: "UserPhoneSet",
                column: "UserId",
                principalTable: "tb_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
