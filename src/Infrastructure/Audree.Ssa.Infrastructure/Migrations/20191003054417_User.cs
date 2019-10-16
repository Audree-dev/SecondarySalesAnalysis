using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Audree.Ssa.Infrastructure.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                schema: "Master",
                table: "Customer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProfilesMastersId",
                schema: "Admin",
                table: "Menu",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MenuMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Menu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedIP = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIP = table.Column<int>(nullable: true),
                    ApprovedBy = table.Column<int>(nullable: true),
                    ApprovedDate = table.Column<DateTime>(nullable: true),
                    ApprovedIP = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Submenus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    MenuMasterId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Submenus_MenuMasters_MenuMasterId",
                        column: x => x.MenuMasterId,
                        principalTable: "MenuMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submenus_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Master",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersInRoleses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInRoleses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersInRoleses_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Master",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersInRoleses_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Admin",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_ProfilesMastersId",
                schema: "Admin",
                table: "Menu",
                column: "ProfilesMastersId");

            migrationBuilder.CreateIndex(
                name: "IX_Submenus_MenuMasterId",
                table: "Submenus",
                column: "MenuMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Submenus_RoleId",
                table: "Submenus",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInRoleses_RoleId",
                table: "UsersInRoleses",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInRoleses_UserId",
                table: "UsersInRoleses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_ProfilesMaster_ProfilesMastersId",
                schema: "Admin",
                table: "Menu",
                column: "ProfilesMastersId",
                principalSchema: "Admin",
                principalTable: "ProfilesMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_ProfilesMaster_ProfilesMastersId",
                schema: "Admin",
                table: "Menu");

            migrationBuilder.DropTable(
                name: "Submenus");

            migrationBuilder.DropTable(
                name: "UsersInRoleses");

            migrationBuilder.DropTable(
                name: "MenuMasters");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Admin");

            migrationBuilder.DropIndex(
                name: "IX_Menu_ProfilesMastersId",
                schema: "Admin",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "ProfilesMastersId",
                schema: "Admin",
                table: "Menu");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                schema: "Master",
                table: "Customer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
