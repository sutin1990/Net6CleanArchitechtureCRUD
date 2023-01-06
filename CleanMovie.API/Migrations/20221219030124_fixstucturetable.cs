using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanMovie.API.Migrations
{
    /// <inheritdoc />
    public partial class fixstucturetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MoviesRentalTransactions_MoviesRentalTransactionId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLoginDtos_MoviesRentalTransactions_MoviesRentalTransactionId",
                table: "UserLoginDtos");

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

            migrationBuilder.AddColumn<int>(
                name: "UserLoginDtoId",
                table: "MoviesRentalTransactions",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MoviesRentalTransactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserLoginDtoId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_MoviesRentalTransactions_MovieId",
                table: "MoviesRentalTransactions",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesRentalTransactions_UserLoginDtoId",
                table: "MoviesRentalTransactions",
                column: "UserLoginDtoId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesRentalTransactions_Movies_MovieId",
                table: "MoviesRentalTransactions",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesRentalTransactions_UserLoginDtos_UserLoginDtoId",
                table: "MoviesRentalTransactions",
                column: "UserLoginDtoId",
                principalTable: "UserLoginDtos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviesRentalTransactions_Movies_MovieId",
                table: "MoviesRentalTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviesRentalTransactions_UserLoginDtos_UserLoginDtoId",
                table: "MoviesRentalTransactions");

            migrationBuilder.DropIndex(
                name: "IX_MoviesRentalTransactions_MovieId",
                table: "MoviesRentalTransactions");

            migrationBuilder.DropIndex(
                name: "IX_MoviesRentalTransactions_UserLoginDtoId",
                table: "MoviesRentalTransactions");

            migrationBuilder.DropColumn(
                name: "UserLoginDtoId",
                table: "MoviesRentalTransactions");

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
    }
}
