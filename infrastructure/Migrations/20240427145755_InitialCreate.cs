using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChassisEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Material = table.Column<string>(type: "TEXT", nullable: false),
                    Weight = table.Column<decimal>(type: "TEXT", nullable: false),
                    Length = table.Column<decimal>(type: "TEXT", nullable: false),
                    Width = table.Column<decimal>(type: "TEXT", nullable: false),
                    Height = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChassisEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EngineEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Capacity = table.Column<decimal>(type: "TEXT", nullable: false),
                    CylinderNo = table.Column<byte>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OptionPackEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionPackEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrderNo = table.Column<long>(type: "INTEGER", nullable: false),
                    SerialNo = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComponentEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OptionPackId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ChassisId = table.Column<Guid>(type: "TEXT", nullable: true),
                    OrderEntityId = table.Column<Guid>(type: "TEXT", nullable: true),
                    EngineId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    SerialNo = table.Column<string>(type: "TEXT", nullable: false),
                    OrderId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Warehouse = table.Column<string>(type: "TEXT", nullable: false),
                    Manufactured = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BlueprintId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UsedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComponentEntity_ChassisEntity_ChassisId",
                        column: x => x.ChassisId,
                        principalTable: "ChassisEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ComponentEntity_EngineEntity_EngineId",
                        column: x => x.EngineId,
                        principalTable: "EngineEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ComponentEntity_OptionPackEntity_OptionPackId",
                        column: x => x.OptionPackId,
                        principalTable: "OptionPackEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ComponentEntity_OrderEntity_OrderEntityId",
                        column: x => x.OrderEntityId,
                        principalTable: "OrderEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComponentEntity_ChassisId",
                table: "ComponentEntity",
                column: "ChassisId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentEntity_EngineId",
                table: "ComponentEntity",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentEntity_OptionPackId",
                table: "ComponentEntity",
                column: "OptionPackId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentEntity_OrderEntityId",
                table: "ComponentEntity",
                column: "OrderEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponentEntity");

            migrationBuilder.DropTable(
                name: "ChassisEntity");

            migrationBuilder.DropTable(
                name: "EngineEntity");

            migrationBuilder.DropTable(
                name: "OptionPackEntity");

            migrationBuilder.DropTable(
                name: "OrderEntity");
        }
    }
}
