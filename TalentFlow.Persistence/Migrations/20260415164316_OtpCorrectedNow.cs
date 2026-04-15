using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalentFlow.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OtpCorrectedNow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Channel",
                table: "otp_codes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "otp_codes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Channel",
                table: "otp_codes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "otp_codes");
        }
    }
}
