﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Audree.Ssa.Infrastructure.Migrations
{
    public partial class SupplierTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Supplier",
                schema: "Master",
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
                    SupplierName = table.Column<string>(nullable: true),
                    SupplierCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Supplier",
                schema: "Master");
        }
    }
}
