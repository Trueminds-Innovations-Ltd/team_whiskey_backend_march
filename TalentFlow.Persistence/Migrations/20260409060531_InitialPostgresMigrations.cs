using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalentFlow.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialPostgresMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_enrollment_course_CourseId",
                table: "enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_enrollment_course_CourseId1",
                table: "enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_enrollment_user_UserId",
                table: "enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_notification_user_UserId",
                table: "notification");

            migrationBuilder.DropForeignKey(
                name: "FK_user_role_RoleId",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_video",
                table: "video");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_team",
                table: "team");

            migrationBuilder.DropPrimaryKey(
                name: "PK_role",
                table: "role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_refreshToken",
                table: "refreshToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_question",
                table: "question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_progress",
                table: "progress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_notification",
                table: "notification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_lesson",
                table: "lesson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_instructor",
                table: "instructor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_enrollment",
                table: "enrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_course",
                table: "course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_certificate",
                table: "certificate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_auditLog",
                table: "auditLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_assessment",
                table: "assessment");

            migrationBuilder.RenameTable(
                name: "video",
                newName: "videos");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "team",
                newName: "teams");

            migrationBuilder.RenameTable(
                name: "role",
                newName: "roles");

            migrationBuilder.RenameTable(
                name: "refreshToken",
                newName: "refreshTokens");

            migrationBuilder.RenameTable(
                name: "question",
                newName: "questions");

            migrationBuilder.RenameTable(
                name: "progress",
                newName: "progresss");

            migrationBuilder.RenameTable(
                name: "notification",
                newName: "notifications");

            migrationBuilder.RenameTable(
                name: "lesson",
                newName: "lessons");

            migrationBuilder.RenameTable(
                name: "instructor",
                newName: "instructors");

            migrationBuilder.RenameTable(
                name: "enrollment",
                newName: "enrollments");

            migrationBuilder.RenameTable(
                name: "course",
                newName: "courses");

            migrationBuilder.RenameTable(
                name: "certificate",
                newName: "certificates");

            migrationBuilder.RenameTable(
                name: "auditLog",
                newName: "auditLogs");

            migrationBuilder.RenameTable(
                name: "assessment",
                newName: "assessments");

            migrationBuilder.RenameIndex(
                name: "IX_user_RoleId",
                table: "users",
                newName: "IX_users_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_user_LearnerId",
                table: "users",
                newName: "IX_users_LearnerId");

            migrationBuilder.RenameIndex(
                name: "IX_notification_UserId",
                table: "notifications",
                newName: "IX_notifications_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_enrollment_UserId",
                table: "enrollments",
                newName: "IX_enrollments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_enrollment_CourseId1",
                table: "enrollments",
                newName: "IX_enrollments_CourseId1");

            migrationBuilder.RenameIndex(
                name: "IX_enrollment_CourseId",
                table: "enrollments",
                newName: "IX_enrollments_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_videos",
                table: "videos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_teams",
                table: "teams",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_refreshTokens",
                table: "refreshTokens",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_questions",
                table: "questions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_progresss",
                table: "progresss",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_notifications",
                table: "notifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_lessons",
                table: "lessons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_instructors",
                table: "instructors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_enrollments",
                table: "enrollments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_courses",
                table: "courses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_certificates",
                table: "certificates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_auditLogs",
                table: "auditLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_assessments",
                table: "assessments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_enrollments_courses_CourseId",
                table: "enrollments",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_enrollments_courses_CourseId1",
                table: "enrollments",
                column: "CourseId1",
                principalTable: "courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_enrollments_users_UserId",
                table: "enrollments",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_users_UserId",
                table: "notifications",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_roles_RoleId",
                table: "users",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_enrollments_courses_CourseId",
                table: "enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_enrollments_courses_CourseId1",
                table: "enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_enrollments_users_UserId",
                table: "enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_notifications_users_UserId",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_RoleId",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_videos",
                table: "videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_teams",
                table: "teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_refreshTokens",
                table: "refreshTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_questions",
                table: "questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_progresss",
                table: "progresss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_notifications",
                table: "notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_lessons",
                table: "lessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_instructors",
                table: "instructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_enrollments",
                table: "enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_courses",
                table: "courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_certificates",
                table: "certificates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_auditLogs",
                table: "auditLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_assessments",
                table: "assessments");

            migrationBuilder.RenameTable(
                name: "videos",
                newName: "video");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "teams",
                newName: "team");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "role");

            migrationBuilder.RenameTable(
                name: "refreshTokens",
                newName: "refreshToken");

            migrationBuilder.RenameTable(
                name: "questions",
                newName: "question");

            migrationBuilder.RenameTable(
                name: "progresss",
                newName: "progress");

            migrationBuilder.RenameTable(
                name: "notifications",
                newName: "notification");

            migrationBuilder.RenameTable(
                name: "lessons",
                newName: "lesson");

            migrationBuilder.RenameTable(
                name: "instructors",
                newName: "instructor");

            migrationBuilder.RenameTable(
                name: "enrollments",
                newName: "enrollment");

            migrationBuilder.RenameTable(
                name: "courses",
                newName: "course");

            migrationBuilder.RenameTable(
                name: "certificates",
                newName: "certificate");

            migrationBuilder.RenameTable(
                name: "auditLogs",
                newName: "auditLog");

            migrationBuilder.RenameTable(
                name: "assessments",
                newName: "assessment");

            migrationBuilder.RenameIndex(
                name: "IX_users_RoleId",
                table: "user",
                newName: "IX_user_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_users_LearnerId",
                table: "user",
                newName: "IX_user_LearnerId");

            migrationBuilder.RenameIndex(
                name: "IX_notifications_UserId",
                table: "notification",
                newName: "IX_notification_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_enrollments_UserId",
                table: "enrollment",
                newName: "IX_enrollment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_enrollments_CourseId1",
                table: "enrollment",
                newName: "IX_enrollment_CourseId1");

            migrationBuilder.RenameIndex(
                name: "IX_enrollments_CourseId",
                table: "enrollment",
                newName: "IX_enrollment_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_video",
                table: "video",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_team",
                table: "team",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_role",
                table: "role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_refreshToken",
                table: "refreshToken",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_question",
                table: "question",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_progress",
                table: "progress",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_notification",
                table: "notification",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_lesson",
                table: "lesson",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_instructor",
                table: "instructor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_enrollment",
                table: "enrollment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_course",
                table: "course",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_certificate",
                table: "certificate",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_auditLog",
                table: "auditLog",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_assessment",
                table: "assessment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_enrollment_course_CourseId",
                table: "enrollment",
                column: "CourseId",
                principalTable: "course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_enrollment_course_CourseId1",
                table: "enrollment",
                column: "CourseId1",
                principalTable: "course",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_enrollment_user_UserId",
                table: "enrollment",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_notification_user_UserId",
                table: "notification",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_role_RoleId",
                table: "user",
                column: "RoleId",
                principalTable: "role",
                principalColumn: "Id");
        }
    }
}
