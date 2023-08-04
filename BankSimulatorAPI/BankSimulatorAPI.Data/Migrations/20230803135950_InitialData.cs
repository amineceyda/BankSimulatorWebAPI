using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankSimulatorAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "dbo",
                columns: table => new
                {
                    CustomerNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsertUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerNumber);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "dbo",
                columns: table => new
                {
                    AccountNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OpenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false, defaultValue: 0m),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsertUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountNumber);
                    table.ForeignKey(
                        name: "FK_Account_Customer_CustomerNumber",
                        column: x => x.CustomerNumber,
                        principalSchema: "dbo",
                        principalTable: "Customer",
                        principalColumn: "CustomerNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    CreditAmount = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false, defaultValue: 0m),
                    DebitAmount = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false, defaultValue: 0m),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsertUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "dbo",
                        principalTable: "Account",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountNumber",
                schema: "dbo",
                table: "Account",
                column: "AccountNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_CustomerNumber",
                schema: "dbo",
                table: "Account",
                column: "CustomerNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CustomerNumber",
                schema: "dbo",
                table: "Customer",
                column: "CustomerNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_AccountId",
                schema: "dbo",
                table: "Transaction",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ReferenceNumber",
                schema: "dbo",
                table: "Transaction",
                column: "ReferenceNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "dbo");
        }
    }
}
