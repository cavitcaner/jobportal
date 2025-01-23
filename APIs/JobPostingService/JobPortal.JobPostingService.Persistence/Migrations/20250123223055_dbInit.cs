﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobPortal.JobPostingService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class dbInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Benefits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingMethods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    EmployerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    Salary = table.Column<decimal>(type: "numeric", nullable: true),
                    PositionId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    PositionId = table.Column<int>(type: "integer", nullable: true),
                    WorkingMethodId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    WorkingMethodId = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPosts_Positions_PositionId1",
                        column: x => x.PositionId1,
                        principalTable: "Positions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobPosts_WorkingMethods_WorkingMethodId1",
                        column: x => x.WorkingMethodId1,
                        principalTable: "WorkingMethods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BenefitJobPost",
                columns: table => new
                {
                    BenefitsId = table.Column<Guid>(type: "uuid", nullable: false),
                    JobPostsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitJobPost", x => new { x.BenefitsId, x.JobPostsId });
                    table.ForeignKey(
                        name: "FK_BenefitJobPost_Benefits_BenefitsId",
                        column: x => x.BenefitsId,
                        principalTable: "Benefits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BenefitJobPost_JobPosts_JobPostsId",
                        column: x => x.JobPostsId,
                        principalTable: "JobPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Benefits",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("53c068c9-f42b-41e7-ba66-3042fa76d8ea"), new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Yıllık İzin", null },
                    { new Guid("6fd71369-623d-42ad-b1b7-bb7c0fb9807b"), new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Uzaktan Çalışma", null },
                    { new Guid("7d461f4b-7433-4290-9739-62d2c7d0e1cc"), new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Servis", null },
                    { new Guid("846fe540-1e2a-410a-b96b-9125cef65d30"), new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Yemek Kartı", null },
                    { new Guid("92209f09-387a-49dc-be08-9c5e092b8f72"), new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Esnek Çalışma Saatleri", null },
                    { new Guid("97ac4390-ee4c-405c-9dfb-d0ceed7cddd0"), new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Eğitim Desteği", null },
                    { new Guid("f1781e55-1a1e-4506-8462-e46f2602f0fa"), new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Özel Sağlık Sigortası", null }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("13ff991b-ccbc-4438-9892-0a33ca338950"), new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Kıdemli Yazılım Geliştirici", null },
                    { new Guid("26c5c218-8b8e-4c77-b2d3-0a4e3258ee15"), new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Test Mühendisi", null },
                    { new Guid("81b645c8-f5a5-4568-a556-6364e6ec3b26"), new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Yazılım Geliştirici", null },
                    { new Guid("886fe6a0-41ee-4091-af37-b47f44bb93e4"), new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), "UI/UX Tasarımcı", null },
                    { new Guid("b3357633-d0e4-4360-8cf6-322f3cc2a373"), new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), "DevOps Mühendisi", null },
                    { new Guid("d103c194-052a-4796-bd1b-81d70dc87101"), new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), "İş Analisti", null },
                    { new Guid("d76aef2d-2666-4f0f-9ab8-29b3b64bc241"), new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Proje Yöneticisi", null }
                });

            migrationBuilder.InsertData(
                table: "WorkingMethods",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("08a6ecee-2c9e-4939-b2ae-2cb1f8a27ac2"), new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Proje Bazlı", null },
                    { new Guid("1da27eef-d85c-41cb-9a89-af5881f3a5c1"), new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Tam Zamanlı", null },
                    { new Guid("22636d32-03f2-45ff-9519-b8b164fc39b2"), new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Stajyer", null },
                    { new Guid("9f930531-9ef9-4d3e-bb49-0ae2bf8129d3"), new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Uzaktan", null },
                    { new Guid("a6f5f822-51cc-4701-a7c2-eb25d47c9ae5"), new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Hibrit", null },
                    { new Guid("b47aef00-3343-4436-9d7f-d52683ce4cf6"), new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Yarı Zamanlı", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BenefitJobPost_JobPostsId",
                table: "BenefitJobPost",
                column: "JobPostsId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_PositionId1",
                table: "JobPosts",
                column: "PositionId1");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_WorkingMethodId1",
                table: "JobPosts",
                column: "WorkingMethodId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BenefitJobPost");

            migrationBuilder.DropTable(
                name: "Benefits");

            migrationBuilder.DropTable(
                name: "JobPosts");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "WorkingMethods");
        }
    }
}
