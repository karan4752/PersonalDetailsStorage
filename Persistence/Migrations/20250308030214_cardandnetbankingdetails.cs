using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class cardandnetbankingdetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardDetailsId",
                table: "BankDetail");

            migrationBuilder.DropColumn(
                name: "IsCardDetialsAvailable",
                table: "BankDetail");

            migrationBuilder.DropColumn(
                name: "NebankingId",
                table: "BankDetail");

            migrationBuilder.RenameColumn(
                name: "IsNetBankingAvailable",
                table: "BankDetail",
                newName: "BankBalance");

            migrationBuilder.AddColumn<string>(
                name: "BankAccountHolderName",
                table: "BankDetail",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAccountType",
                table: "BankDetail",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankBranch",
                table: "BankDetail",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAddress",
                table: "BankDetail",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "BankDetail",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserPhoneNumber",
                table: "BankDetail",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CardDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    BankDetailId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CardNumber = table.Column<string>(type: "TEXT", nullable: true),
                    CardHolderName = table.Column<string>(type: "TEXT", nullable: true),
                    CardExpiryDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    CardCvv = table.Column<string>(type: "TEXT", nullable: true),
                    CardType = table.Column<string>(type: "TEXT", nullable: true),
                    CardBrand = table.Column<string>(type: "TEXT", nullable: true),
                    CardPinNumber = table.Column<string>(type: "TEXT", nullable: true),
                    CardPinExpiryDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    IsCardDetailsAvailable = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardDetail_BankDetail_BankDetailId",
                        column: x => x.BankDetailId,
                        principalTable: "BankDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NetBankingDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    BankDetailId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BankUserId = table.Column<string>(type: "TEXT", nullable: true),
                    BankPassword = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordExpireDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    TransactionPassword = table.Column<string>(type: "TEXT", nullable: true),
                    TransactionPasswordExpireDate = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetBankingDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NetBankingDetail_BankDetail_BankDetailId",
                        column: x => x.BankDetailId,
                        principalTable: "BankDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardDetail_BankDetailId",
                table: "CardDetail",
                column: "BankDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_NetBankingDetail_BankDetailId",
                table: "NetBankingDetail",
                column: "BankDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardDetail");

            migrationBuilder.DropTable(
                name: "NetBankingDetail");

            migrationBuilder.DropColumn(
                name: "BankAccountHolderName",
                table: "BankDetail");

            migrationBuilder.DropColumn(
                name: "BankAccountType",
                table: "BankDetail");

            migrationBuilder.DropColumn(
                name: "BankBranch",
                table: "BankDetail");

            migrationBuilder.DropColumn(
                name: "UserAddress",
                table: "BankDetail");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "BankDetail");

            migrationBuilder.DropColumn(
                name: "UserPhoneNumber",
                table: "BankDetail");

            migrationBuilder.RenameColumn(
                name: "BankBalance",
                table: "BankDetail",
                newName: "IsNetBankingAvailable");

            migrationBuilder.AddColumn<Guid>(
                name: "CardDetailsId",
                table: "BankDetail",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsCardDetialsAvailable",
                table: "BankDetail",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "NebankingId",
                table: "BankDetail",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
