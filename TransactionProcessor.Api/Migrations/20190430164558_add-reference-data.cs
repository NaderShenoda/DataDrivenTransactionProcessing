using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransactionProcessor.Api.Migrations
{
    public partial class addreferencedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReferenceDataDefinitions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenceDataDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReferenceDataFieldDefinitions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReferenceDataDefinitionId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenceDataFieldDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferenceDataFieldDefinitions_ReferenceDataDefinitions_ReferenceDataDefinitionId",
                        column: x => x.ReferenceDataDefinitionId,
                        principalTable: "ReferenceDataDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReferenceDataInstances",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReferenceDataDefinitionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenceDataInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferenceDataInstances_ReferenceDataDefinitions_ReferenceDataDefinitionId",
                        column: x => x.ReferenceDataDefinitionId,
                        principalTable: "ReferenceDataDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReferenceDataFieldInstances",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReferenceDataInstanceId = table.Column<long>(nullable: false),
                    ReferenceDataFieldDefinitionId = table.Column<long>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenceDataFieldInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferenceDataFieldInstances_ReferenceDataFieldDefinitions_ReferenceDataFieldDefinitionId",
                        column: x => x.ReferenceDataFieldDefinitionId,
                        principalTable: "ReferenceDataFieldDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReferenceDataFieldInstances_ReferenceDataInstances_ReferenceDataInstanceId",
                        column: x => x.ReferenceDataInstanceId,
                        principalTable: "ReferenceDataInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReferenceDataFieldDefinitions_ReferenceDataDefinitionId",
                table: "ReferenceDataFieldDefinitions",
                column: "ReferenceDataDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenceDataFieldInstances_ReferenceDataFieldDefinitionId",
                table: "ReferenceDataFieldInstances",
                column: "ReferenceDataFieldDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenceDataFieldInstances_ReferenceDataInstanceId",
                table: "ReferenceDataFieldInstances",
                column: "ReferenceDataInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenceDataInstances_ReferenceDataDefinitionId",
                table: "ReferenceDataInstances",
                column: "ReferenceDataDefinitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReferenceDataFieldInstances");

            migrationBuilder.DropTable(
                name: "ReferenceDataFieldDefinitions");

            migrationBuilder.DropTable(
                name: "ReferenceDataInstances");

            migrationBuilder.DropTable(
                name: "ReferenceDataDefinitions");
        }
    }
}
