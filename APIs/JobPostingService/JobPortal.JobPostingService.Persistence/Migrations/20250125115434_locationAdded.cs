using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.JobPostingService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class locationAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "WorkingMethods",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "WorkingMethods",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Positions",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "JobPosts",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "JobPosts",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "JobPosts",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "JobPosts",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "JobPosts",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Benefits",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Benefits",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.UpdateData(
                table: "Benefits",
                keyColumn: "Id",
                keyValue: new Guid("53c068c9-f42b-41e7-ba66-3042fa76d8ea"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Benefits",
                keyColumn: "Id",
                keyValue: new Guid("6fd71369-623d-42ad-b1b7-bb7c0fb9807b"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Benefits",
                keyColumn: "Id",
                keyValue: new Guid("7d461f4b-7433-4290-9739-62d2c7d0e1cc"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Benefits",
                keyColumn: "Id",
                keyValue: new Guid("846fe540-1e2a-410a-b96b-9125cef65d30"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Benefits",
                keyColumn: "Id",
                keyValue: new Guid("92209f09-387a-49dc-be08-9c5e092b8f72"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Benefits",
                keyColumn: "Id",
                keyValue: new Guid("97ac4390-ee4c-405c-9dfb-d0ceed7cddd0"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Benefits",
                keyColumn: "Id",
                keyValue: new Guid("f1781e55-1a1e-4506-8462-e46f2602f0fa"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("13ff991b-ccbc-4438-9892-0a33ca338950"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("26c5c218-8b8e-4c77-b2d3-0a4e3258ee15"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("81b645c8-f5a5-4568-a556-6364e6ec3b26"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("886fe6a0-41ee-4091-af37-b47f44bb93e4"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("b3357633-d0e4-4360-8cf6-322f3cc2a373"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("d103c194-052a-4796-bd1b-81d70dc87101"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("d76aef2d-2666-4f0f-9ab8-29b3b64bc241"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "WorkingMethods",
                keyColumn: "Id",
                keyValue: new Guid("08a6ecee-2c9e-4939-b2ae-2cb1f8a27ac2"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "WorkingMethods",
                keyColumn: "Id",
                keyValue: new Guid("1da27eef-d85c-41cb-9a89-af5881f3a5c1"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "WorkingMethods",
                keyColumn: "Id",
                keyValue: new Guid("22636d32-03f2-45ff-9519-b8b164fc39b2"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "WorkingMethods",
                keyColumn: "Id",
                keyValue: new Guid("9f930531-9ef9-4d3e-bb49-0ae2bf8129d3"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "WorkingMethods",
                keyColumn: "Id",
                keyValue: new Guid("a6f5f822-51cc-4701-a7c2-eb25d47c9ae5"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "WorkingMethods",
                keyColumn: "Id",
                keyValue: new Guid("b47aef00-3343-4436-9d7f-d52683ce4cf6"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "JobPosts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "WorkingMethods",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "WorkingMethods",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Positions",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Positions",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "JobPosts",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "JobPosts",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "JobPosts",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "JobPosts",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Benefits",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Benefits",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.UpdateData(
                table: "Benefits",
                keyColumn: "Id",
                keyValue: new Guid("53c068c9-f42b-41e7-ba66-3042fa76d8ea"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Benefits",
                keyColumn: "Id",
                keyValue: new Guid("6fd71369-623d-42ad-b1b7-bb7c0fb9807b"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Benefits",
                keyColumn: "Id",
                keyValue: new Guid("7d461f4b-7433-4290-9739-62d2c7d0e1cc"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Benefits",
                keyColumn: "Id",
                keyValue: new Guid("846fe540-1e2a-410a-b96b-9125cef65d30"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Benefits",
                keyColumn: "Id",
                keyValue: new Guid("92209f09-387a-49dc-be08-9c5e092b8f72"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Benefits",
                keyColumn: "Id",
                keyValue: new Guid("97ac4390-ee4c-405c-9dfb-d0ceed7cddd0"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Benefits",
                keyColumn: "Id",
                keyValue: new Guid("f1781e55-1a1e-4506-8462-e46f2602f0fa"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("13ff991b-ccbc-4438-9892-0a33ca338950"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("26c5c218-8b8e-4c77-b2d3-0a4e3258ee15"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("81b645c8-f5a5-4568-a556-6364e6ec3b26"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("886fe6a0-41ee-4091-af37-b47f44bb93e4"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("b3357633-d0e4-4360-8cf6-322f3cc2a373"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("d103c194-052a-4796-bd1b-81d70dc87101"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("d76aef2d-2666-4f0f-9ab8-29b3b64bc241"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "WorkingMethods",
                keyColumn: "Id",
                keyValue: new Guid("08a6ecee-2c9e-4939-b2ae-2cb1f8a27ac2"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "WorkingMethods",
                keyColumn: "Id",
                keyValue: new Guid("1da27eef-d85c-41cb-9a89-af5881f3a5c1"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "WorkingMethods",
                keyColumn: "Id",
                keyValue: new Guid("22636d32-03f2-45ff-9519-b8b164fc39b2"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "WorkingMethods",
                keyColumn: "Id",
                keyValue: new Guid("9f930531-9ef9-4d3e-bb49-0ae2bf8129d3"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "WorkingMethods",
                keyColumn: "Id",
                keyValue: new Guid("a6f5f822-51cc-4701-a7c2-eb25d47c9ae5"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "WorkingMethods",
                keyColumn: "Id",
                keyValue: new Guid("b47aef00-3343-4436-9d7f-d52683ce4cf6"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc));
        }
    }
}
