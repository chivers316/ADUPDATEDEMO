using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADASSESSMENT.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Engineers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    ContactNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<string>(type: "TEXT", nullable: false),
                    VRN = table.Column<string>(type: "TEXT", maxLength: 7, nullable: false),
                    Comments = table.Column<string>(type: "TEXT", nullable: false),
                    EngineerId = table.Column<int>(type: "INTEGER", nullable: true),
                    AddressId = table.Column<int>(type: "INTEGER", nullable: true),
                    TimeSlotId = table.Column<int>(type: "INTEGER", nullable: true),
                    JobCategoryId = table.Column<int>(type: "INTEGER", nullable: true),
                    EngineerAddress = table.Column<string>(type: "TEXT", nullable: false),
                    BookedSlot = table.Column<string>(type: "TEXT", nullable: false),
                    SelectedJob = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engineers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstLine = table.Column<string>(type: "TEXT", nullable: true),
                    SecondLine = table.Column<string>(type: "TEXT", nullable: true),
                    ThirdLine = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    PostCode = table.Column<string>(type: "TEXT", nullable: true),
                    EngineerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Engineers_EngineerId",
                        column: x => x.EngineerId,
                        principalTable: "Engineers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategorySelected = table.Column<string>(type: "TEXT", nullable: false),
                    EngineerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobCategories_Engineers_EngineerId",
                        column: x => x.EngineerId,
                        principalTable: "Engineers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TimeSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    monSlot1 = table.Column<bool>(type: "INTEGER", nullable: false),
                    monSlot2 = table.Column<bool>(type: "INTEGER", nullable: false),
                    monSlot3 = table.Column<bool>(type: "INTEGER", nullable: false),
                    tueSlot1 = table.Column<bool>(type: "INTEGER", nullable: false),
                    tueSlot2 = table.Column<bool>(type: "INTEGER", nullable: false),
                    tueSlot3 = table.Column<bool>(type: "INTEGER", nullable: false),
                    wedSlot1 = table.Column<bool>(type: "INTEGER", nullable: false),
                    wedSlot2 = table.Column<bool>(type: "INTEGER", nullable: false),
                    wedSlot3 = table.Column<bool>(type: "INTEGER", nullable: false),
                    thuSlot1 = table.Column<bool>(type: "INTEGER", nullable: false),
                    thuSlot2 = table.Column<bool>(type: "INTEGER", nullable: false),
                    thuSlot3 = table.Column<bool>(type: "INTEGER", nullable: false),
                    friSlot1 = table.Column<bool>(type: "INTEGER", nullable: false),
                    friSlot2 = table.Column<bool>(type: "INTEGER", nullable: false),
                    friSlot3 = table.Column<bool>(type: "INTEGER", nullable: false),
                    satSlot1 = table.Column<bool>(type: "INTEGER", nullable: false),
                    satSlot2 = table.Column<bool>(type: "INTEGER", nullable: false),
                    satSlot3 = table.Column<bool>(type: "INTEGER", nullable: false),
                    sunSlot1 = table.Column<bool>(type: "INTEGER", nullable: false),
                    sunSlot2 = table.Column<bool>(type: "INTEGER", nullable: false),
                    sunSlot3 = table.Column<bool>(type: "INTEGER", nullable: false),
                    monSlot1String = table.Column<string>(type: "TEXT", nullable: false),
                    monSlot2String = table.Column<string>(type: "TEXT", nullable: false),
                    monSlot3String = table.Column<string>(type: "TEXT", nullable: false),
                    tueSlot1String = table.Column<string>(type: "TEXT", nullable: false),
                    tueSlot2String = table.Column<string>(type: "TEXT", nullable: false),
                    tueSlot3String = table.Column<string>(type: "TEXT", nullable: false),
                    wedSlot1String = table.Column<string>(type: "TEXT", nullable: false),
                    wedSlot2String = table.Column<string>(type: "TEXT", nullable: false),
                    wedSlot3String = table.Column<string>(type: "TEXT", nullable: false),
                    thuSlot1String = table.Column<string>(type: "TEXT", nullable: false),
                    thuSlot2String = table.Column<string>(type: "TEXT", nullable: false),
                    thuSlot3String = table.Column<string>(type: "TEXT", nullable: false),
                    friSlot1String = table.Column<string>(type: "TEXT", nullable: false),
                    friSlot2String = table.Column<string>(type: "TEXT", nullable: false),
                    friSlot3String = table.Column<string>(type: "TEXT", nullable: false),
                    satSlot1String = table.Column<string>(type: "TEXT", nullable: false),
                    satSlot2String = table.Column<string>(type: "TEXT", nullable: false),
                    satSlot3String = table.Column<string>(type: "TEXT", nullable: false),
                    sunSlot1String = table.Column<string>(type: "TEXT", nullable: false),
                    sunSlot2String = table.Column<string>(type: "TEXT", nullable: false),
                    sunSlot3String = table.Column<string>(type: "TEXT", nullable: false),
                    SlotBooked = table.Column<string>(type: "TEXT", nullable: false),
                    EngineerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSlots_Engineers_EngineerId",
                        column: x => x.EngineerId,
                        principalTable: "Engineers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_EngineerId",
                table: "Addresses",
                column: "EngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCategories_EngineerId",
                table: "JobCategories",
                column: "EngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_EngineerId",
                table: "TimeSlots",
                column: "EngineerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "JobCategories");

            migrationBuilder.DropTable(
                name: "TimeSlots");

            migrationBuilder.DropTable(
                name: "Engineers");
        }
    }
}
