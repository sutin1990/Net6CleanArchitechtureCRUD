using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanMovie.API.Migrations
{
    /// <inheritdoc />
    public partial class tableMoviesRentalTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MoviesRentalTransactionId",
                table: "UserLoginDtos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MoviesRentalTransactionId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MoviesRentalTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LateFines = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CutomerId = table.Column<int>(type: "int", nullable: false),
                    StaffRentId = table.Column<int>(type: "int", nullable: false),
                    StaffReturnId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesRentalTransactions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MoviesRentalTransactions",
                columns: new[] { "Id", "CutomerId", "ExpiryDate", "LateFines", "MovieId", "RentDate", "ReturnDate", "StaffRentId", "StaffReturnId" },
                values: new object[] { 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 8, new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 });

            migrationBuilder.UpdateData(
                table: "UserLoginDtos",
                keyColumn: "Id",
                keyValue: 1,
                column: "MoviesRentalTransactionId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginDtos_MoviesRentalTransactionId",
                table: "UserLoginDtos",
                column: "MoviesRentalTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MoviesRentalTransactionId",
                table: "Movies",
                column: "MoviesRentalTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MoviesRentalTransactions_MoviesRentalTransactionId",
                table: "Movies",
                column: "MoviesRentalTransactionId",
                principalTable: "MoviesRentalTransactions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLoginDtos_MoviesRentalTransactions_MoviesRentalTransactionId",
                table: "UserLoginDtos",
                column: "MoviesRentalTransactionId",
                principalTable: "MoviesRentalTransactions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MoviesRentalTransactions_MoviesRentalTransactionId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLoginDtos_MoviesRentalTransactions_MoviesRentalTransactionId",
                table: "UserLoginDtos");

            migrationBuilder.DropTable(
                name: "MoviesRentalTransactions");

            migrationBuilder.DropIndex(
                name: "IX_UserLoginDtos_MoviesRentalTransactionId",
                table: "UserLoginDtos");

            migrationBuilder.DropIndex(
                name: "IX_Movies_MoviesRentalTransactionId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MoviesRentalTransactionId",
                table: "UserLoginDtos");

            migrationBuilder.DropColumn(
                name: "MoviesRentalTransactionId",
                table: "Movies");
        }
    }
}
