using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORM_LINQ.Migrations
{
    public partial class DataAnnotationEvaluation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Articles_ArticleId",
                table: "Evaluations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Evaluations",
                table: "Evaluations");

            migrationBuilder.RenameTable(
                name: "Evaluations",
                newName: "evaluations");

            migrationBuilder.RenameColumn(
                name: "Stars",
                table: "evaluations",
                newName: "stars");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "evaluations",
                newName: "evaluation_text");

            migrationBuilder.RenameColumn(
                name: "EvaluationId",
                table: "evaluations",
                newName: "evaluation_id");

            migrationBuilder.RenameIndex(
                name: "IX_Evaluations_ArticleId",
                table: "evaluations",
                newName: "IX_evaluations_ArticleId");

            migrationBuilder.AlterColumn<string>(
                name: "evaluation_text",
                table: "evaluations",
                type: "varchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_evaluations",
                table: "evaluations",
                column: "evaluation_id");

            migrationBuilder.AddForeignKey(
                name: "FK_evaluations_Articles_ArticleId",
                table: "evaluations",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_evaluations_Articles_ArticleId",
                table: "evaluations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_evaluations",
                table: "evaluations");

            migrationBuilder.RenameTable(
                name: "evaluations",
                newName: "Evaluations");

            migrationBuilder.RenameColumn(
                name: "stars",
                table: "Evaluations",
                newName: "Stars");

            migrationBuilder.RenameColumn(
                name: "evaluation_text",
                table: "Evaluations",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "evaluation_id",
                table: "Evaluations",
                newName: "EvaluationId");

            migrationBuilder.RenameIndex(
                name: "IX_evaluations_ArticleId",
                table: "Evaluations",
                newName: "IX_Evaluations_ArticleId");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Evaluations",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2000)",
                oldMaxLength: 2000)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Evaluations",
                table: "Evaluations",
                column: "EvaluationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Articles_ArticleId",
                table: "Evaluations",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
