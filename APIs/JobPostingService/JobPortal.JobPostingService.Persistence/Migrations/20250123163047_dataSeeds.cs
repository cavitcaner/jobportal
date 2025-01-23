using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobPortal.JobPostingService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class dataSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Benefits",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Özel Sağlık Sigortası" },
                    { 2, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yemek Kartı" },
                    { 3, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Servis" },
                    { 4, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Esnek Çalışma Saatleri" },
                    { 5, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uzaktan Çalışma" },
                    { 6, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yıllık İzin" },
                    { 7, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eğitim Desteği" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yazılım Geliştirici" },
                    { 2, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kıdemli Yazılım Geliştirici" },
                    { 3, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "İş Analisti" },
                    { 4, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Proje Yöneticisi" },
                    { 5, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "DevOps Mühendisi" },
                    { 6, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "UI/UX Tasarımcı" },
                    { 7, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test Mühendisi" }
                });

            migrationBuilder.InsertData(
                table: "WorkingMethods",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tam Zamanlı" },
                    { 2, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yarı Zamanlı" },
                    { 3, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uzaktan" },
                    { 4, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hibrit" },
                    { 5, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stajyer" },
                    { 6, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Proje Bazlı" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Benefits",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Benefits",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Benefits",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Benefits",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Benefits",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Benefits",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Benefits",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "WorkingMethods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkingMethods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkingMethods",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorkingMethods",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WorkingMethods",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WorkingMethods",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
