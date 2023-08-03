using Microsoft.EntityFrameworkCore.Migrations;

namespace BankSimulatorAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO dbo.\"Customer\"(\"FirstName\", \"LastName\", \"CustomerNumber\", \"Address\", \"IsActive\", \"InsertDate\", \"InsertUser\") " +
                "VALUES ('John', 'Doe', 100001, '123 Main Street', 1, '2023-02-02', 'SystemAdmin');");

            migrationBuilder.Sql("INSERT INTO dbo.\"Customer\"(\"FirstName\", \"LastName\", \"CustomerNumber\", \"Address\", \"IsActive\", \"InsertDate\", \"InsertUser\") " +
                "VALUES ('Jane', 'Smith', 100002, '456 Elm Street', 1, '2023-02-02', 'SystemAdmin');");

            migrationBuilder.Sql("INSERT INTO dbo.\"Customer\"(\"FirstName\", \"LastName\", \"CustomerNumber\", \"Address\", \"IsActive\", \"InsertDate\", \"InsertUser\") " +
                "VALUES ('Michael', 'Johnson', 100003, '789 Oak Street', 1, '2023-02-02', 'SystemAdmin');");

            migrationBuilder.Sql("INSERT INTO dbo.\"Customer\"(\"FirstName\", \"LastName\", \"CustomerNumber\", \"Address\", \"IsActive\", \"InsertDate\", \"InsertUser\") " +
                "VALUES ('Emily', 'Williams', 100004, '321 Pine Street', 1, '2023-02-02', 'SystemAdmin');");

            migrationBuilder.Sql("INSERT INTO dbo.\"Customer\"(\"FirstName\", \"LastName\", \"CustomerNumber\", \"Address\", \"IsActive\", \"InsertDate\", \"InsertUser\") " +
                "VALUES ('Daniel', 'Brown', 100005, '654 Cedar Street', 1, '2023-02-02', 'SystemAdmin');");

            migrationBuilder.Sql("INSERT INTO dbo.\"Customer\"(\"FirstName\", \"LastName\", \"CustomerNumber\", \"Address\", \"IsActive\", \"InsertDate\", \"InsertUser\") " +
                "VALUES ('Olivia', 'Jones', 100006, '987 Maple Street', 1, '2023-02-02', 'SystemAdmin');");

            migrationBuilder.Sql("INSERT INTO dbo.\"Account\"(\"CustomerId\", \"Balance\", \"Name\", \"OpenDate\", \"CurrencyCode\", \"AccountNumber\", \"IsActive\", \"InsertDate\", \"InsertUser\") " +
                "VALUES (1, 1000, 'Savings Account', '2023-04-04', 'TRY', 500001, 1, '2023-07-07', 'SystemAdmin');");

            migrationBuilder.Sql("INSERT INTO dbo.\"Account\"(\"CustomerId\", \"Balance\", \"Name\", \"OpenDate\", \"CurrencyCode\", \"AccountNumber\", \"IsActive\", \"InsertDate\", \"InsertUser\") " +
                "VALUES (2, 5000, 'Checking Account', '2023-04-04', 'TRY', 500002, 1, '2023-07-07', 'SystemAdmin');");

            migrationBuilder.Sql("INSERT INTO dbo.\"Account\"(\"CustomerId\", \"Balance\", \"Name\", \"OpenDate\", \"CurrencyCode\", \"AccountNumber\", \"IsActive\", \"InsertDate\", \"InsertUser\") " +
                "VALUES (3, 2500, 'Savings Account', '2023-04-04', 'TRY', 500003, 1, '2023-07-07', 'SystemAdmin');");

            migrationBuilder.Sql("INSERT INTO dbo.\"Account\"(\"CustomerId\", \"Balance\", \"Name\", \"OpenDate\", \"CurrencyCode\", \"AccountNumber\", \"IsActive\", \"InsertDate\", \"InsertUser\") " +
                "VALUES (4, 8000, 'Checking Account', '2023-04-04', 'TRY', 500004, 1, '2023-07-07', 'SystemAdmin');");

            migrationBuilder.Sql("INSERT INTO dbo.\"Account\"(\"CustomerId\", \"Balance\", \"Name\", \"OpenDate\", \"CurrencyCode\", \"AccountNumber\", \"IsActive\", \"InsertDate\", \"InsertUser\") " +
                "VALUES (5, 1500, 'Savings Account', '2023-04-04', 'TRY', 500005, 1, '2023-07-07', 'SystemAdmin');");

            migrationBuilder.Sql("INSERT INTO dbo.\"Account\"(\"CustomerId\", \"Balance\", \"Name\", \"OpenDate\", \"CurrencyCode\", \"AccountNumber\", \"IsActive\", \"InsertDate\", \"InsertUser\") " +
                "VALUES (6, 3000, 'Checking Account', '2023-04-04', 'TRY', 500006, 1, '2023-07-07', 'SystemAdmin');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // This is empty because the Down method is not needed for the seed data.
            // If you want to revert the seed data, you can manually delete the records
            // from the Customer and Account tables.
        }
    }
}
