using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlockChain.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Blocks_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    block_id = table.Column<int>(type: "integer", nullable: false),
                    cur_hash = table.Column<string>(type: "text", nullable: false),
                    prev_hash = table.Column<string>(type: "text", nullable: false),
                    is_genesis = table.Column<bool>(type: "boolean", nullable: false),
                    valid_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blocks");
        }
    }
}
