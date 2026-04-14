using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalentFlow.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Refactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_refreshToken",
                table: "refreshToken");

            migrationBuilder.RenameTable(
                name: "refreshToken",
                newName: "refresh_tokens");

            migrationBuilder.AlterColumn<string>(
                name: "LearnerId",
                table: "user",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "user",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CohortYear",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Discipline",
                table: "user",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NotificationPrefs",
                table: "user",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "user",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePhotoUrl",
                table: "user",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProgressVisibility",
                table: "user",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "FirstLessonId",
                table: "enrollment",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "enrollment",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "course",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_refresh_tokens",
                table: "refresh_tokens",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "otp_codes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsUsed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_otp_codes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lesson_CourseId",
                table: "lesson",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_lesson_course_CourseId",
                table: "lesson",
                column: "CourseId",
                principalTable: "course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lesson_course_CourseId",
                table: "lesson");

            migrationBuilder.DropTable(
                name: "otp_codes");

            migrationBuilder.DropIndex(
                name: "IX_lesson_CourseId",
                table: "lesson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_refresh_tokens",
                table: "refresh_tokens");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "user");

            migrationBuilder.DropColumn(
                name: "CohortYear",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Discipline",
                table: "user");

            migrationBuilder.DropColumn(
                name: "NotificationPrefs",
                table: "user");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "user");

            migrationBuilder.DropColumn(
                name: "ProfilePhotoUrl",
                table: "user");

            migrationBuilder.DropColumn(
                name: "ProgressVisibility",
                table: "user");

            migrationBuilder.DropColumn(
                name: "FirstLessonId",
                table: "enrollment");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "enrollment");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "course");

            migrationBuilder.RenameTable(
                name: "refresh_tokens",
                newName: "refreshToken");

            migrationBuilder.AlterColumn<Guid>(
                name: "LearnerId",
                table: "user",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_refreshToken",
                table: "refreshToken",
                column: "Id");
        }
    }
}
